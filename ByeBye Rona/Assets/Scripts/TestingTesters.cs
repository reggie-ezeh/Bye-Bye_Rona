using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingTesters : MonoBehaviour
{
    public float phase1_min_mutate;
    public float phase1_max_mutate;
    public float phase1_min_expire;
    public float phase1_max_expire;

    public float phase2_min_mutate;
    public float phase2_max_mutate;
    public float phase2_min_expire;
    public float phase2_max_expire;

    public float phase3_min_mutate;
    public float phase3_max_mutate;
    public float phase3_min_expire;
    public float phase3_max_expire;


    // Start is called before the first frame update
    void Awake()
    {
    phase1_min_mutate = PlayerPrefs.GetFloat("test_phase1_min_mutate");
    phase1_max_mutate = PlayerPrefs.GetFloat("test_phase1_max_mutate");
    phase1_min_expire = PlayerPrefs.GetFloat("test_phase1_min_expire");
    phase1_max_expire = PlayerPrefs.GetFloat("test_phase1_max_expire");

    phase2_min_mutate = PlayerPrefs.GetFloat("test_phase2_min_mutate");
    phase2_max_mutate = PlayerPrefs.GetFloat("test_phase2_max_mutate");
    phase2_min_expire = PlayerPrefs.GetFloat("test_phase2_min_expire");
    phase2_max_expire = PlayerPrefs.GetFloat("test_phase2_max_expire");

    phase3_min_mutate = PlayerPrefs.GetFloat("test_phase3_min_mutate");
    phase3_max_mutate = PlayerPrefs.GetFloat("test_phase3_max_mutate");
    phase3_min_expire = PlayerPrefs.GetFloat("test_phase3_min_expire");
    phase3_max_expire = PlayerPrefs.GetFloat("test_phase3_max_expire");
    }


}
