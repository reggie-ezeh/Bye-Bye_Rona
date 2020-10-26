﻿using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Sanitizer : MonoBehaviour
{
    [SerializeField]
    PausedMenu pausedMenu;

    private Rigidbody2D rb;

    public GameObject bullet;
   
    public static GameObject projectile;

    private bool can_fire;

    [SerializeField]
    float fire_rate;
    // dont endable when the soap comes
    public bool enable_shooter= true;

    public static SpriteRenderer spriteRenderer;

    private Vector3 touchPosition;
    private Vector3 direction;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    Image left_boundary;
    [SerializeField]
    Image right_boundary;
    [SerializeField]
    Image bottom_boundary;
    [SerializeField]
    Image screen_bottom;

    float fixed_y_movement;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // provides access to the rigid body componenet of the sanitizer
        rb = GetComponent<Rigidbody2D>();
        projectile = bullet;
        can_fire = true;

        fixed_y_movement = (bottom_boundary.rectTransform.position.y
        + screen_bottom.rectTransform.position.y)/1.75f ;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (enable_shooter)
        {
            Shooter();
        }

    }


    public void Movement()
    {
        if (!pausedMenu.is_paused && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPosition.x > left_boundary.rectTransform.position.x && touchPosition.x < right_boundary.rectTransform.position.x)
            {
                touchPosition.z = 0;
                direction = (touchPosition - transform.position);
                transform.position = new Vector2(transform.position.x, fixed_y_movement);
                rb.velocity = new Vector2(direction.x, 0) * moveSpeed;

                if (touch.phase == TouchPhase.Ended)
                    rb.velocity = Vector2.zero;
            }

        }

    }


    public void Shooter()
    {
        if (!pausedMenu.is_paused && Input.touchCount > 0 && can_fire  )
        {
            Touch user_touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(user_touch.position);

            if (touchPos.x > left_boundary.rectTransform.position.x && touchPos.x < right_boundary.rectTransform.position.x)
            {
                GameObject bull = Instantiate(projectile);
                bull.transform.position = new Vector3(transform.position.x, transform.position.y + 1.4f, transform.position.z);
                //AudioManager.instance.Play("SanitizerShoot");
                StartCoroutine(FireRateController());
            }
        }
    }

    //This method controls how often the sanitizer can fire a bullet
    IEnumerator FireRateController()
    {
        can_fire = false;
        yield return new WaitForSeconds(fire_rate);
        can_fire=true;
    }

    public void DisplaySyringe()
    {
        transform.position = bottom_boundary.rectTransform.position;
    }
}
    


    