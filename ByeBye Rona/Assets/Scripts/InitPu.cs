using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPu : MonoBehaviour
{
    [SerializeField]
    float mask_min;

    [SerializeField]
    float soap_min;

    [SerializeField]
    float vaccine_min;

    void Start()
    {
        InitPowerUps();
    }

    void InitPowerUps()
    {
        if (!PlayerPrefs.HasKey("SoapPercentage"))
        {
            PlayerPrefs.SetFloat("SoapPercentage", soap_min);
        }

        if (!PlayerPrefs.HasKey("MaskTime"))
        {
            PlayerPrefs.SetFloat("MaskTime", mask_min);
        }

        if (!PlayerPrefs.HasKey("VaccineTime"))
        {
            PlayerPrefs.SetFloat("VaccineTime", vaccine_min);
        }
    }
}
