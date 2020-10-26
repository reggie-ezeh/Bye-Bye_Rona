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
    private Sprite sanitizer_image;
    [SerializeField]
    private Sprite vaccine_image;

    [SerializeField]
    GameObject sanitizer_pallet;
    [SerializeField]
    GameObject vaccineShot;

    [SerializeField]
    Button soap_button;
    [SerializeField]
    Button mask_button;
    [SerializeField]
    Button vaccine_button;

    Sanitizer sanitizer;
    public bool power_up_currently_active { get; set; }


    [SerializeField]
    float vaccine_time;

    void Start()
    {
        power_up_currently_active = false;
        vaccine_button.interactable = true;
        soap_button.interactable = true;
        mask_button.interactable = true;
        sanitizer = FindObjectOfType<Sanitizer>();
    }

    public void CreateSoap()
    {
        if (!GameController.instance.game_over &&  !power_up_currently_active)
        {
            power_up_currently_active = true;
            Instantiate(soap);
            soap_button.interactable = false;
        }

    }

    public void CreateMask()
    {
        if (!GameController.instance.game_over && !power_up_currently_active)
        {
            power_up_currently_active = true;
            Instantiate(mask);
            mask_button.interactable = false;
        }

    }


    public void TrySummonVaccine()
    {
        if (!GameController.instance.game_over && !power_up_currently_active)
        {
            power_up_currently_active = true;
            vaccine_button.interactable = false;
            StartCoroutine(SummonVaccine());
        }
    }

    IEnumerator SummonVaccine()
    {
        Sanitizer.spriteRenderer.sprite = vaccine_image;
        Sanitizer.projectile = vaccineShot;
        sanitizer.DisplaySyringe();
        yield return new WaitForSeconds(vaccine_time);
        Sanitizer.spriteRenderer.sprite = sanitizer_image;
        Sanitizer.projectile = sanitizer_pallet;
        power_up_currently_active = false;
    }
}
