using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePU : MonoBehaviour
{
    [SerializeField]
    float mask_max;
    [SerializeField]
    float mask_upgrade_rate;
    [SerializeField]
    float vaccine_max;
    [SerializeField]
    float vaccine_upgrade_rate;
    [SerializeField]
    float soap_max;
    [SerializeField]
    float soap_upgrade_rate;

    float mask_current;
    float vaccine_current;
    float soap_current;

    [SerializeField]
    TextMeshProUGUI mask_status_text;
    [SerializeField]
    TextMeshProUGUI mask_current_text;
    [SerializeField]
    TextMeshProUGUI mask_max_text;
    [SerializeField]
    TextMeshProUGUI vaccine_status_text;
    [SerializeField]
    TextMeshProUGUI vaccine_current_text;
    [SerializeField]
    TextMeshProUGUI vaccine_max_text;
    [SerializeField]
    TextMeshProUGUI soap_status_text;
    [SerializeField]
    TextMeshProUGUI soap_current_text;
    [SerializeField]
    TextMeshProUGUI soap_max_text;

    [SerializeField]
    TextMeshProUGUI upgrade_notification_text;

    //[SerializeField]
    //Button mask_Ad_button;
    //[SerializeField]
    //Button vaccine_Ad_button;
    //[SerializeField]
    //Button soap_Ad_button;

    void Start()
    {
        UpdateCurrents();
        CheckAllUpgraded();

        mask_max_text.text = "Max: "+mask_max.ToString() + "s";
        vaccine_max_text.text = "Max: " +vaccine_max.ToString()+"s";
        soap_max_text.text = "Max: "+(((int)(100/soap_max)).ToString())+"%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateCurrents()
    {
        mask_current = PlayerPrefs.GetFloat("MaskTime");
        vaccine_current = PlayerPrefs.GetFloat("VaccineTime");
        soap_current = PlayerPrefs.GetFloat("SoapPercentage");

        mask_current_text.text = "Current: "+mask_current.ToString("0.00")+"s";
        vaccine_current_text.text = "Current: " + vaccine_current.ToString("0.00")+"s";
        soap_current_text.text = "Current: " + (((int)(100 / 2.5)).ToString("00")) + "%";

    }

    bool CheckMaskFull()
    {
        if (mask_current >= mask_max)
        {
            mask_status_text.color = Color.red;
            mask_status_text.text = "Mask fully upgraded";
            return true;
        }
        return false;
    }

    bool CheckVaccineFull()
    {
        if (vaccine_current >= vaccine_max)
        {
            vaccine_status_text.color = Color.red;
            vaccine_status_text.text = "Vaccine fully upgraded";
            return true;
        }
        return false;
    }

    bool CheckSoapFull()
    {
        if (soap_current <= soap_max)
        {
            soap_status_text.color = Color.red;
            soap_status_text.text = "Soap fully upgraded";
            return true;
        }
        return false;
    }
    void CheckAllUpgraded()
    {
        if (CheckMaskFull() && CheckVaccineFull()&& CheckSoapFull())
        {
            upgrade_notification_text.text = "All PowerUps Have been fully Upgraded!";
        }
    }

    void UpgradeMask()
    {
        float new_time = mask_current += mask_upgrade_rate;
        PlayerPrefs.SetFloat("MaskTime", new_time);
        UpdateCurrents();
    }

    void UpgradeVaccine()
    {
        float new_time = vaccine_current += vaccine_upgrade_rate;
        PlayerPrefs.SetFloat("VaccineTime", new_time);
        UpdateCurrents();
    }

    void UpgradeSoap()
    {
        float new_ratio = soap_current -= soap_upgrade_rate;
        PlayerPrefs.SetFloat("SoapPercentage", new_ratio);
        UpdateCurrents();
    }
}
