using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour
{
    public float bullet_speed = 30;

    // needed to be able to move the bullets
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // we make the bullet move up 
        //rb.velocity = Vector2.up * bullet_speed;

    }


    private void Update()
    {
        transform.Translate(new Vector3(0, bullet_speed * Time.deltaTime, 0));
    }

    // when the bullet hits the cieling, get rid of it
    // this event is a child of monobehaviour
    void OnTriggerEnter2D(Collider2D items)
    {
        // when the pallet hits the wall, destroy it.
        if (items.tag == "walls")
        {
            Destroy(gameObject);
        }

        // when the pallet hits the virus
        if (items.tag == "virus")
        {
            Destroy(gameObject);
            //SoundManager.instance.play_Requested_Audio(SoundManager.instance.virus_hit);
        }
    }

    //Just in case the bullet ever leaves the screen, destroy it
    //This event is also a child of Monobehavior
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

   
}
