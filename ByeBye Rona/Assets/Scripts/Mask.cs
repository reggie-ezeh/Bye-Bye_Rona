using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mask : MonoBehaviour
{
    float masktime;

    void Start()
    {
        masktime = PlayerPrefs.GetFloat("MaskTime");



        //////Tester///////
        masktime = PlayerPrefs.GetFloat("test_mask_max_time");




        StartCoroutine(Main_Action());
    }

    IEnumerator Main_Action()
    {
        yield return new WaitForSeconds(0.3f);

        VirusController.instance.viruses_can_move = false;
        VirusController.instance.viruses_can_spawn = false;
        VirusController.instance.viruses_can_upgrade = false;

        yield return new WaitForSeconds(masktime);

        VirusController.instance.viruses_can_move = true;
        VirusController.instance.viruses_can_spawn = true;
        VirusController.instance.viruses_can_upgrade = true;
        GameEvents.instance.MaskExitAction();

        PowerUpController.instance.power_up_currently_active = false;
        Destroy(gameObject);
    }

}
