using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    float masktime;
    float starttime;

    void Start()
    {
        StartCoroutine(Main_Action());
        masktime = 8;
    }


    IEnumerator Main_Action()
    {
        yield return new WaitForSeconds(starttime);

        VirusController.instance.viruses_can_move = false;
        VirusController.instance.viruses_can_spawn = false;
        VirusController.instance.viruses_can_upgrade = false;


        yield return new WaitForSeconds(masktime);


        VirusController.instance.viruses_can_move = true;
        VirusController.instance.viruses_can_spawn = true;
        VirusController.instance.viruses_can_upgrade = true;

        PowerUpController.instance.power_up_currently_active = false;
        Destroy(gameObject);
    }

}
