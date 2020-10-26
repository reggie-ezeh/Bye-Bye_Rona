using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : Singleton<GameManger>
{

    [SerializeField]
    float mask_min;
  
    [SerializeField]
    float soap_min;

    [SerializeField]
    float vaccine_min;

   
    void Start()
    {
        InitVaccineTime();
        InitSoapTime();
        InitMaskTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitMaskTime()
    {
        if (!PlayerPrefs.HasKey("MaskTime"))
        {
            PlayerPrefs.SetFloat("MaskTime", mask_min);
        }
    }

    void InitSoapTime()
    {
        if (!PlayerPrefs.HasKey("SoapPercentage"))
        {
            PlayerPrefs.SetFloat("SoapPercentage", soap_min);
        }
    }

    void InitVaccineTime()
    {
        if (!PlayerPrefs.HasKey("VaccineTime"))
        {
            PlayerPrefs.SetFloat("VaccineTime", vaccine_min);
        }
    }



}
