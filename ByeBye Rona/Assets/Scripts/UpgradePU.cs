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
    [SerializeField]
    TextMeshProUGUI Ad_message;

    void Start()
    {
        Ad_message.gameObject.SetActive(false);
        UpdateCurrents();
        CheckAllUpgraded();

        mask_max_text.text = "Max: "+mask_max.ToString() + "s";
        vaccine_max_text.text = "Max: " +vaccine_max.ToString()+"s";
        soap_max_text.text = "Max: "+(((int)(100/soap_max)).ToString())+"%";
    }

    void UpdateCurrents()
    {
        mask_current = PlayerPrefs.GetFloat("MaskTime");
        vaccine_current = PlayerPrefs.GetFloat("VaccineTime");
        soap_current = PlayerPrefs.GetFloat("SoapPercentage");

        mask_current_text.text = "Current: "+mask_current.ToString("0.00")+"s";
        vaccine_current_text.text = "Current: " + vaccine_current.ToString("0.00")+"s";
        soap_current_text.text = "Current: " + (((int)(100 / soap_current)).ToString("00")) + "%";
    }

    bool CheckMaskFull()
    {
        if ((mask_current + mask_upgrade_rate) > mask_max)
        {
            mask_status_text.color = Color.red;
            mask_status_text.text = "Mask fully upgraded";
            return true;
        }
        return false;
    }

    bool CheckVaccineFull()
    {
        if ((vaccine_current+vaccine_upgrade_rate) > vaccine_max)
        {
            vaccine_status_text.color = Color.red;
            vaccine_status_text.text = "Vaccine fully upgraded";
            return true;
        }
        return false;
    }

    bool CheckSoapFull()
    {
        if ((soap_current - soap_upgrade_rate) < soap_max)
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
            PlayerPrefs.SetInt("PUsFull", 1);
        }
    }

    public void WatchMaskAd()
    {
        AdManager.ShowRewardedAd(UpgradeMask, AdSkipped, AdFailed);
    }

    public void WatchVaccineAd()
    {
        AdManager.ShowRewardedAd(UpgradeVaccine, AdSkipped, AdFailed);
    }

    public void WatchSoapAd()
    {
        AdManager.ShowRewardedAd(UpgradeSoap, AdSkipped, AdFailed);
    }

    void UpgradeMask()
    { 
        if (!CheckMaskFull()) {
            float new_time = mask_current += mask_upgrade_rate;
            PlayerPrefs.SetFloat("MaskTime", new_time);
            UpdateCurrents();
            CheckAllUpgraded();
            StartCoroutine(DisplayAdMessage());
            Ad_message.text = "Mask + " + mask_upgrade_rate.ToString() + "sec";
        }
    }

    void UpgradeVaccine()
    {
        if (!CheckVaccineFull())
        {
            float new_time = vaccine_current += vaccine_upgrade_rate;
            PlayerPrefs.SetFloat("VaccineTime", new_time);
            UpdateCurrents();
            CheckAllUpgraded();
            StartCoroutine(DisplayAdMessage());
            Ad_message.text = "Vaccine + " + vaccine_upgrade_rate.ToString() + "sec";
        }
    }

    void UpgradeSoap()
    {
        if (!CheckSoapFull())
        {
            float old_ratio = soap_current;
            float new_ratio = soap_current -= soap_upgrade_rate;
            PlayerPrefs.SetFloat("SoapPercentage", new_ratio);
            UpdateCurrents();
            CheckAllUpgraded();
            StartCoroutine(DisplayAdMessage());
            int display_change = (int)(100 / new_ratio) - (int)(100 / old_ratio);
            Ad_message.text = "Soap + " + display_change.ToString() + "%";
        }
    }

    void AdSkipped()
    {
        StartCoroutine(DisplayAdMessage());
        Ad_message.text = "Ad skipped; Failed to Unlock Background";
    }

    void AdFailed()
    {
        StartCoroutine(DisplayAdMessage());
        Ad_message.text = "Ad failed to load";
    }

    IEnumerator DisplayAdMessage()
    {
        Ad_message.gameObject.SetActive(true);
        Ad_message.text = "Ad skipped; Failed to Unlock Background";
        yield return new WaitForSeconds(3);
        Ad_message.gameObject.SetActive(false);
    }
}
