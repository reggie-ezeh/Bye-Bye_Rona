using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestingScript : MonoBehaviour
{
    public TextMeshProUGUI error_msg;

    public string secs_to_max;
    public GameObject secs_to_max_field;
    public GameObject secs_to_max_display;

    public string sanitizer_fire_rate;
    public GameObject sanitizer_fire_rate_field;
    public GameObject sanitizer_fire_rate_display;

    public string vaccine_fire_rate;
    public GameObject vaccine_fire_rate_field;
    public GameObject vaccine_fire_rate_display;

    public string min_virus_speed;
    public GameObject min_virus_speed_field;
    public GameObject min_virus_speed_display;

    public string max_virus_speed;
    public GameObject max_virus_speed_field;
    public GameObject max_virus_speed_display;

    public string min_spawn_rate;
    public GameObject min_spawn_rate_field;
    public GameObject min_spawn_rate_display;

    public string max_spawn_rate;
    public GameObject max_spawn_rate_field;
    public GameObject max_spawn_rate_display;

    public string mask_max_time;
    public GameObject mask_max_time_field;
    public GameObject mask_max_time_display;

    public string mask_recharge_treshold;
    public GameObject mask_recharge_treshold_field;
    public GameObject mask_recharge_treshold_display;

    public string vaccine_max_time;
    public GameObject vaccine_max_time_field;
    public GameObject vaccine_max_time_display;

    public string vaccine_recharge_treshold;
    public GameObject vaccine_recharge_treshold_field;
    public GameObject vaccine_recharge_treshold_display;

    public string soap_recharge_treshold;
    public GameObject soap_recharge_treshold_field;
    public GameObject soap_recharge_treshold_display;

    public string minon_spawn_rate;
    public GameObject minon_spawn_rate_field;
    public GameObject minon_spawn_rate_display;

    public string boss_speed;
    public GameObject boss_speed_field;
    public GameObject boss_speed_display;

    public string phase1_min_mutate;
    public GameObject phase1_min_mutate_field;
    public GameObject phase1_min_mutate_display;

    public string phase1_max_mutate;
    public GameObject phase1_max_mutate_field;
    public GameObject phase1_max_mutate_display;

    public string phase1_min_expire;
    public GameObject phase1_min_expire_field;
    public GameObject phase1_min_expire_display;

    public string phase1_max_expire;
    public GameObject phase1_max_expire_field;
    public GameObject phase1_max_expire_display;

    public string phase2_min_mutate;
    public GameObject phase2_min_mutate_field;
    public GameObject phase2_min_mutate_display;

    public string phase2_max_mutate;
    public GameObject phase2_max_mutate_field;
    public GameObject phase2_max_mutate_display;

    public string phase2_min_expire;
    public GameObject phase2_min_expire_field;
    public GameObject phase2_min_expire_display;

    public string phase2_max_expire;
    public GameObject phase2_max_expire_field;
    public GameObject phase2_max_expire_display;

    public string phase3_min_mutate;
    public GameObject phase3_min_mutate_field;
    public GameObject phase3_min_mutate_display;

    public string phase3_max_mutate;
    public GameObject phase3_max_mutate_field;
    public GameObject phase3_max_mutate_display;

    public string phase3_min_expire;
    public GameObject phase3_min_expire_field;
    public GameObject phase3_min_expire_display;

    public string phase3_max_expire;
    public GameObject phase3_max_expire_field;
    public GameObject phase3_max_expire_display;

    public string phase4_min_expire;
    public GameObject phase4_min_expire_field;
    public GameObject phase4_min_expire_display;

    public string phase4_max_expire;
    public GameObject phase4_max_expire_field;
    public GameObject phase4_max_expire_display;

    public string phase5_min_expire;
    public GameObject phase5_min_expire_field;
    public GameObject phase5_min_expire_display;

    public string phase5_max_expire;
    public GameObject phase5_max_expire_field;
    public GameObject phase5_max_expire_display;

    public string population_max;
    public GameObject population_max_field;
    public GameObject population_max_display;

    void Start()
    {
        secs_to_max_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_secs_to_max").ToString();
        sanitizer_fire_rate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_sanitizer_fire_rate").ToString();
        vaccine_fire_rate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_vaccine_fire_rate").ToString();
        min_virus_speed_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_min_virus_speed").ToString();
        max_virus_speed_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_max_virus_speed").ToString();
        min_spawn_rate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_min_spawn_rate").ToString();
        max_spawn_rate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_max_spawn_rate").ToString();
        mask_max_time_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_mask_max_time").ToString();
        mask_recharge_treshold_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("test_mask_recharge_treshold").ToString();
        vaccine_max_time_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_vaccine_max_time").ToString();
        vaccine_recharge_treshold_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("test_vaccine_recharge_treshold").ToString();
        soap_recharge_treshold_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("test_soap_recharge_treshold").ToString();
        minon_spawn_rate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_minion_spawn_rate").ToString();
        boss_speed_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_boss_speed").ToString();

        phase1_min_mutate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase1_min_mutate").ToString();
        phase1_max_mutate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase1_max_mutate").ToString();
        phase1_min_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase1_min_expire").ToString();
        phase1_max_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase1_max_expire").ToString();

        phase2_min_mutate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase2_min_mutate").ToString();
        phase2_max_mutate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase2_max_mutate").ToString();
        phase2_min_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase2_min_expire").ToString();
        phase2_max_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase2_max_expire").ToString();

        phase3_min_mutate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase3_min_mutate").ToString();
        phase3_max_mutate_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase3_max_mutate").ToString();
        phase3_min_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase3_min_expire").ToString();
        phase3_max_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase3_max_expire").ToString();

        phase3_min_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase3_min_expire").ToString();
        phase3_max_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase3_max_expire").ToString();

        phase4_min_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase4_min_expire").ToString();
        phase4_max_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase4_max_expire").ToString();

        phase5_min_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase5_min_expire").ToString();
        phase5_max_expire_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetFloat("test_phase5_max_expire").ToString();

        population_max_display.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("test_population_max").ToString();
    }

    public void Goback()
    {
        gameObject.SetActive(false);
    }

    IEnumerator MessageDisplay(bool success)
    {
        if (success)
        {
            error_msg.color = Color.green;
            error_msg.text = "Submitted! btw Randolph got a little meat";
            yield return new WaitForSeconds(1.8f);
            error_msg.text = "";
        }
        else
        {
            error_msg.color = Color.red;
            error_msg.text = "Invalid input";
            yield return new WaitForSeconds(1.5f);
            error_msg.text = "";
        }
    }

    public void SetSecsToMax()
    {
        secs_to_max = secs_to_max_field.GetComponent<TextMeshProUGUI>().text;
        secs_to_max = secs_to_max.Substring(0, secs_to_max.Length - 1);

        if (float.TryParse(secs_to_max, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_secs_to_max", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void SanitizerFireRate()
    {
        sanitizer_fire_rate = sanitizer_fire_rate_field.GetComponent<TextMeshProUGUI>().text;
        sanitizer_fire_rate = sanitizer_fire_rate.Substring(0, sanitizer_fire_rate.Length - 1);

        if (float.TryParse(sanitizer_fire_rate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_sanitizer_fire_rate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void VaccineFireRate()
    {
        vaccine_fire_rate = vaccine_fire_rate_field.GetComponent<TextMeshProUGUI>().text;
        vaccine_fire_rate = vaccine_fire_rate.Substring(0, vaccine_fire_rate.Length - 1);

        if (float.TryParse(vaccine_fire_rate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_vaccine_fire_rate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void MinVirusSpeed()
    {
        min_virus_speed = min_virus_speed_field.GetComponent<TextMeshProUGUI>().text;
        min_virus_speed = min_virus_speed.Substring(0, min_virus_speed.Length - 1);

        if (float.TryParse(min_virus_speed, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_min_virus_speed", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void MaxVirusSpeed()
    {
        max_virus_speed = max_virus_speed_field.GetComponent<TextMeshProUGUI>().text;
        max_virus_speed = max_virus_speed.Substring(0, max_virus_speed.Length - 1);

        if (float.TryParse(max_virus_speed, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_max_virus_speed", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void MinSpawnRate()
    {
        min_spawn_rate = min_spawn_rate_field.GetComponent<TextMeshProUGUI>().text;
        min_spawn_rate = min_spawn_rate.Substring(0, min_spawn_rate.Length - 1);

        if (float.TryParse(min_spawn_rate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_min_spawn_rate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void MaxSpawnRate()
    {
        max_spawn_rate = max_spawn_rate_field.GetComponent<TextMeshProUGUI>().text;
        max_spawn_rate = max_spawn_rate.Substring(0, max_spawn_rate.Length - 1);

        if (float.TryParse(max_spawn_rate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_max_spawn_rate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void MaskMaxTime()
    {
        mask_max_time = mask_max_time_field.GetComponent<TextMeshProUGUI>().text;
        mask_max_time = mask_max_time.Substring(0, mask_max_time.Length - 1);

        if (float.TryParse(mask_max_time, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_mask_max_time", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void MaskRechargeTreshold()
    {
        mask_recharge_treshold = mask_recharge_treshold_field.GetComponent<TextMeshProUGUI>().text;
        mask_recharge_treshold = mask_recharge_treshold.Substring(0, mask_recharge_treshold.Length - 1);

        if (int.TryParse(mask_recharge_treshold, out int flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetInt("test_mask_recharge_treshold", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void VaccineMaxTime()
    {
        vaccine_max_time = vaccine_max_time_field.GetComponent<TextMeshProUGUI>().text;
        vaccine_max_time = vaccine_max_time.Substring(0, vaccine_max_time.Length - 1);

        if (float.TryParse(vaccine_max_time, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_vaccine_max_time", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void VaccineRechargeTreshold()
    {
        vaccine_recharge_treshold = vaccine_recharge_treshold_field.GetComponent<TextMeshProUGUI>().text;
        vaccine_recharge_treshold = vaccine_recharge_treshold.Substring(0, vaccine_recharge_treshold.Length - 1);

        if (int.TryParse(vaccine_recharge_treshold, out int flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetInt("test_vaccine_recharge_treshold", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void SoapRechargeTreshold()
    {
        soap_recharge_treshold = soap_recharge_treshold_field.GetComponent<TextMeshProUGUI>().text;
        soap_recharge_treshold = soap_recharge_treshold.Substring(0, soap_recharge_treshold.Length - 1);

        if (int.TryParse(soap_recharge_treshold, out int flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetInt("test_soap_recharge_treshold", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void MinonSpawnRate()
    {
        minon_spawn_rate = minon_spawn_rate_field.GetComponent<TextMeshProUGUI>().text;
        minon_spawn_rate = minon_spawn_rate.Substring(0, minon_spawn_rate.Length - 1);

        if (float.TryParse(minon_spawn_rate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_minion_spawn_rate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void BossSpeed()
    {
        boss_speed = boss_speed_field.GetComponent<TextMeshProUGUI>().text;
        boss_speed = boss_speed.Substring(0, boss_speed.Length - 1);

        if (float.TryParse(boss_speed, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_boss_speed", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase1MinMutate()
    {
        phase1_min_mutate = phase1_min_mutate_field.GetComponent<TextMeshProUGUI>().text;
        phase1_min_mutate = phase1_min_mutate.Substring(0, phase1_min_mutate.Length - 1);

        if (float.TryParse(phase1_min_mutate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase1_min_mutate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase1MaxMutate()
    {
        phase1_max_mutate = phase1_max_mutate_field.GetComponent<TextMeshProUGUI>().text;
        phase1_max_mutate = phase1_max_mutate.Substring(0, phase1_max_mutate.Length - 1);

        if (float.TryParse(phase1_max_mutate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase1_max_mutate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase1MinExpire()
    {
        phase1_min_expire = phase1_min_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase1_min_expire = phase1_min_expire.Substring(0, phase1_min_expire.Length - 1);

        if (float.TryParse(phase1_min_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase1_min_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase1MaxExpire()
    {
        phase1_max_expire = phase1_max_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase1_max_expire = phase1_max_expire.Substring(0, phase1_max_expire.Length - 1);

        if (float.TryParse(phase1_max_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase1_max_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase2MinMutate()
    {
        phase2_min_mutate = phase2_min_mutate_field.GetComponent<TextMeshProUGUI>().text;
        phase2_min_mutate = phase2_min_mutate.Substring(0, phase2_min_mutate.Length - 1);

        if (float.TryParse(phase2_min_mutate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase2_min_mutate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase2MaxMutate()
    {
        phase2_max_mutate = phase2_max_mutate_field.GetComponent<TextMeshProUGUI>().text;
        phase2_max_mutate = phase2_max_mutate.Substring(0, phase2_max_mutate.Length - 1);

        if (float.TryParse(phase2_max_mutate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase2_max_mutate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase2MinExpire()
    {
        phase2_min_expire = phase2_min_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase2_min_expire = phase2_min_expire.Substring(0, phase2_min_expire.Length - 1);

        if (float.TryParse(phase2_min_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase2_min_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase2MaxExpire()
    {
        phase2_max_expire = phase2_max_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase2_max_expire = phase2_max_expire.Substring(0, phase2_max_expire.Length - 1);

        if (float.TryParse(phase2_max_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase2_max_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase3MinMutate()
    {
        phase3_min_mutate = phase3_min_mutate_field.GetComponent<TextMeshProUGUI>().text;
        phase3_min_mutate = phase3_min_mutate.Substring(0, phase3_min_mutate.Length - 1);

        if (float.TryParse(phase3_min_mutate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase3_min_mutate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase3MaxMutate()
    {
        phase3_max_mutate = phase3_max_mutate_field.GetComponent<TextMeshProUGUI>().text;
        phase3_max_mutate = phase3_max_mutate.Substring(0, phase3_max_mutate.Length - 1);

        if (float.TryParse(phase3_max_mutate, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase3_max_mutate", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase3MinExpire()
    {
        phase3_min_expire = phase3_min_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase3_min_expire = phase3_min_expire.Substring(0, phase3_min_expire.Length - 1);

        if (float.TryParse(phase3_min_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase3_min_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase3MaxExpire()
    {
        phase3_max_expire = phase3_max_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase3_max_expire = phase3_max_expire.Substring(0, phase3_max_expire.Length - 1);

        if (float.TryParse(phase3_max_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase3_max_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }


    public void Phase4MinExpire()
    {
        phase4_min_expire = phase4_min_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase4_min_expire = phase4_min_expire.Substring(0, phase4_min_expire.Length - 1);

        if (float.TryParse(phase4_min_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase4_min_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase4MaxExpire()
    {
        phase4_max_expire = phase4_max_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase4_max_expire = phase4_max_expire.Substring(0, phase4_max_expire.Length - 1);

        if (float.TryParse(phase4_max_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase4_max_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }


    public void Phase5MinExpire()
    {
        phase5_min_expire = phase5_min_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase5_min_expire = phase5_min_expire.Substring(0, phase5_min_expire.Length - 1);

        if (float.TryParse(phase5_min_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase5_min_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void Phase5MaxExpire()
    {
        phase5_max_expire = phase5_max_expire_field.GetComponent<TextMeshProUGUI>().text;
        phase5_max_expire = phase5_max_expire.Substring(0, phase5_max_expire.Length - 1);

        if (float.TryParse(phase5_max_expire, out float flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetFloat("test_phase5_max_expire", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }

    public void PopulationMax()
    {
        population_max = population_max_field.GetComponent<TextMeshProUGUI>().text;
        population_max = population_max.Substring(0, population_max.Length - 1);

        if (int.TryParse(population_max, out int flt_ver))
        {
            error_msg.text = "";
            PlayerPrefs.SetInt("test_population_max", flt_ver);
            StartCoroutine(MessageDisplay(true));
        }
        else
        {
            StartCoroutine(MessageDisplay(false));
        }
    }
}
