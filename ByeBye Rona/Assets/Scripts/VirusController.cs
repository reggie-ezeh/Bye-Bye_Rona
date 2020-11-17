using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class VirusController : Singleton<VirusController>
{
    //[leve1, level1, level1, level2, level2, level3]
    [SerializeField]
    GameObject[] unique_viruses;

    /*This field gets shuffled after every 6 iterations. reason why virus indices is used to access 
     the viruses in the unique_viruses array is that because an array with non integervalues cannot be shuffled
    * The objective is that in the first iteration I can spawn viruses in their increasing order 1-1-1-2-2-3 but after that
     I want to shuffle to shuffle the order in which the viruses are spawned.
    eg: 3-1-2-1-1-2, 1-3-2-1-2-1, etc .....  */
    List<int> virus_indices = new List<int> { 0, 1, 2, 3, 4, 5 };


    [SerializeField]
    Image left_boundary;
    [SerializeField]
    Image right_boundary;
    [SerializeField]
    Image bottom_boundary;
    [SerializeField]
    Image top_boundary;

    public float top_edge { get; set; }
    public float bottom_edge { get; set; }
    public float left_edge { get; set; }
    public float right_edge { get; set; }
    int index = 0;

    float virus_spawn_rate;
    [SerializeField]
    float min_spawn_rate;
    [SerializeField]
    float max_spawn_rate;
    [SerializeField]
    float virus_expire_rate;

    public float min_virus_speed;
    public float max_virus_speed;

    //wait this amount of time before the very first spawn
    int start_wait = 2;

    public bool viruses_can_spawn { get; set; }
    public bool viruses_can_expire { get; set; }
    public bool viruses_can_move { get; set; }
    public bool viruses_can_upgrade { get; set; }

    /* A doubly linked list is used to contain the viruses because it is efficient remove items from the list
     * Also, a queue can be easily implemented using a linked list and the que would allow us to efficiently
     remove viruses from the list in the order in which they were created after a certain amount of time (indicating a natural death)
     Also, the static allows us to easily acces this field from another class, this way we wouldn't have to write
    GameObject.Find("Virus Controller").GetComponent<VirusController>().alive_viruses). In other words,...
    the field would not be attached to a specific object (virus controller) and can be easily accessed by scripts
    from other objects
    */
    public LinkedList<GameObject> alive_viruses = new LinkedList<GameObject>();

    void Start()
    {
        viruses_can_spawn = true;
        viruses_can_move = true;
        viruses_can_upgrade = true;
        viruses_can_expire = true;

        top_edge = top_boundary.rectTransform.position.y;
        left_edge = left_boundary.rectTransform.position.x;
        right_edge = right_boundary.rectTransform.position.x;
        bottom_edge = bottom_boundary.rectTransform.position.y;

        StartCoroutine(VirusSpawner());
    }

    void Update()
    {
        virus_spawn_rate = Mathf.Lerp(min_spawn_rate, max_spawn_rate, GameController.instance.GetDifficultyPercent());
    }

    IEnumerator VirusSpawner()
    {
        yield return new WaitForSeconds(start_wait);

        while (!GameController.instance.game_over)
        {
            // this create a random location for the virus to spawn to
            Vector2 spawnlocation = new Vector2(Random.Range(left_edge, right_edge), Random.Range(bottom_edge+1, top_edge));

            //spawn the new virus and add it to the linked_list of viruses
            if (viruses_can_spawn)
            {
                int virusIndex_to_use = virus_indices[index % 6];
                GameObject new_virus = Instantiate(unique_viruses[virusIndex_to_use], spawnlocation, Quaternion.identity);
                alive_viruses.AddLast(new_virus); //enqueue
                index++;
            }

            if (index % 6 == 0) // reorder the virus spawn order afer each set of 3 viruses has been created
            {
                virus_indices = virus_indices.OrderBy(x => Random.value).ToList();
            }
            yield return new WaitForSeconds(1);
        }
    }

}
