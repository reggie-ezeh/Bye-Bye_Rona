using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : Singleton<PowerUpController>
{
    [SerializeField]
    private GameObject soap;
    [SerializeField]
    private GameObject mask;

    [SerializeField]
    Button soap_button;
    [SerializeField]
    Button mask_button;
    [SerializeField]
    Button vaccine_button;

    float mask_counter;
    float vaccine_counter;
    float soap_counter;

    [SerializeField]
    public int mask_reward_treshold;

    [SerializeField]
    public int vaccine_reward_treshold;

    [SerializeField]
    public int soap_reward_treshold;

    public bool power_up_currently_active { get; set; }

    void Start()
    {
        //////Tester//////
        //mask_reward_treshold = PlayerPrefs.GetInt("test_mask_recharge_treshold");
        //vaccine_reward_treshold = PlayerPrefs.GetInt("test_vaccine_recharge_treshold");
        //soap_reward_treshold = PlayerPrefs.GetInt("test_soap_recharge_treshold");
        
        power_up_currently_active = false;
        vaccine_button.interactable = true;
        soap_button.interactable = true;
        mask_button.interactable = true;
    }

    public void CreateSoap()
    {
        if (!GameController.instance.game_over &&  !power_up_currently_active)
        {
            soap_counter = 0;
            power_up_currently_active = true;
            AudioManager.instance.Play("PowerUp");
            Instantiate(soap);
            soap_button.interactable = false;
        }
    }

    public void CreateMask()
    {
        if (!GameController.instance.game_over && !power_up_currently_active)
        {
            mask_counter = 0;
            power_up_currently_active = true;
            AudioManager.instance.Play("PowerUp");
            Instantiate(mask);
            mask_button.interactable = false;
        }
    }

    public void CreateVaccine()
    {
        if (!GameController.instance.game_over && !power_up_currently_active)
        {
            vaccine_counter = 0;
            power_up_currently_active = true;
            AudioManager.instance.Play("PowerUp");
            vaccine_button.interactable = false;
            StartCoroutine(Sanitizer.instance.SummonVaccine());
        }
    }

    public void CheckReward()
    {
        if (mask_counter >= mask_reward_treshold)
        {
            mask_counter = 0;
            RewardMask();
        }

        if (vaccine_counter >= vaccine_reward_treshold)
        {
            vaccine_counter = 0;
            RewardVaccine();
        }

        if (soap_counter >=  soap_reward_treshold)
        {
            soap_counter = 0;
            RewardSoap();
        }
    }

    public void AddKills()
    {
        if (!power_up_currently_active)
        {
            mask_counter += 1;
            vaccine_counter += 1;
            soap_counter += 1;
        }
    }
    
    void RewardMask()
    {
        if (mask_button.interactable == false)
        {
            mask_button.interactable = true;     
        }
    }

    void RewardVaccine()
    {
        if (vaccine_button.interactable == false)
        {
            vaccine_button.interactable = true;
        }
    }

    void RewardSoap()
    {
        if (soap_button.interactable == false)
        {
            soap_button.interactable = true;
        }
    }
}
