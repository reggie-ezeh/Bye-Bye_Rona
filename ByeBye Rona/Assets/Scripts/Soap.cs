using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Soap : MonoBehaviour
{
    Sanitizer sanitizer;
    //first convert the linked list of all the viruses to a list
    private List<GameObject> viruses_to_kill = new List<GameObject>();

    readonly float wait_to_start_kills = 3;
    readonly float soap_speed = 14;
    Vector2 target;
    bool attack_now = false;
    private Object bubblesRef;
    GameObject bubbles;

    float target_population;

    void Start()
    {
        sanitizer = FindObjectOfType<Sanitizer>();
        bubblesRef = Resources.Load("Soap Bubbles");
        bubbles = (GameObject)(Instantiate(bubblesRef));
        target_population= PlayerPrefs.GetFloat("SoapPercentage");

        //////Tester///////
        //target_population = (1.3f);

        CopyAliveViruses();
        QuickSort(viruses_to_kill, 0, viruses_to_kill.Count - 1);

        float len_viruses = (viruses_to_kill.Count + 1);
        viruses_to_kill = viruses_to_kill.GetRange(0, (int) (len_viruses/target_population));

        StartCoroutine(Main_Action());
    }

    void CopyAliveViruses()
    {
        var currentNode = VirusController.instance.alive_viruses.First;

        while (currentNode != null)
        {
            if (currentNode.Value != null)
            {
                viruses_to_kill.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }

    void Update()
    {
        Movement();
        bubbles.transform.position =
            new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Swap<Viruses>(List<Viruses> arr, int pos1, int pos2)
    {
        Viruses temp = arr[pos1];
        arr[pos1] = arr[pos2];
        arr[pos2] = temp;
    }

    private int Partition(List<GameObject> viruses, int start, int end)
    {
        int pivot_pointer = start; //the pivot will always be the first element in the subarry
        int end_pointer = end;

        while (pivot_pointer < end_pointer)
        {
            //sort in descending order
            if (viruses[pivot_pointer + 1].GetComponent<Viruses>().current_health >=
                viruses[pivot_pointer].GetComponent<Viruses>().current_health)
            {
                Swap(viruses, pivot_pointer, pivot_pointer + 1);
                pivot_pointer++;
            }
            else
            {
                Swap(viruses, pivot_pointer + 1, end_pointer);
                end_pointer--;
            }
        }

        return pivot_pointer;
    }

    //the quicksort algorithm will be used to sort the array of viruses based on their health in decending order
    void QuickSort(List<GameObject> viruses, int start, int end)
    {
        if (start >= end)
        {
            return;
        }

        int partition_index = Partition(viruses, start, end);
        QuickSort(viruses, start, partition_index - 1);
        QuickSort(viruses, partition_index + 1, end);
    }

    IEnumerator Main_Action()
    {
        //indicate that soap is active so dont increase difficulty
        sanitizer.enable_shooter = false;
        VirusController.instance.viruses_can_move = false;
        VirusController.instance.viruses_can_expire = false;
        VirusController.instance.viruses_can_spawn = false;
        VirusController.instance.viruses_can_upgrade = false;
        GameController.instance.playing = false;

        yield return new WaitForSeconds(wait_to_start_kills);

        foreach (GameObject virus in viruses_to_kill)
        {
            if (virus != null){
                target = virus.transform.position;
                yield return new WaitUntil(() => attack_now == true);
                virus.GetComponent<Viruses>().CallDeath();
                attack_now = false;
            }
        }

        yield return new WaitForSeconds(.5f);
        GameController.instance.playing = true;
        sanitizer.enable_shooter = true;
        VirusController.instance.viruses_can_move = true;
        VirusController.instance.viruses_can_expire = true;
        VirusController.instance.viruses_can_spawn = true;
        VirusController.instance.viruses_can_upgrade = true;
        PowerUpController.instance.power_up_currently_active = false;
        GameEvents.instance.SoapExitAction();
        Destroy(bubbles);
        Destroy(gameObject);
    }

    void Movement()
    {
        if ((Vector2)transform.position != target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, soap_speed * Time.deltaTime);
        }
        else
        {
            attack_now = true;
        }
    }
}
