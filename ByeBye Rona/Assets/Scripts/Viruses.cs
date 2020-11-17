using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will be the base class for the viruses
public class Viruses : MonoBehaviour
{

    //used to check if the virus has been hit
    public int original_health;
    public int current_health;

    Vector2 target;

    float min_speed;
    float max_speed;
    float virus_speed;

    private SpriteRenderer spriteRenderer;
    public VirusHealthBar healthBar;

    //fields to animate when the virus gets hit
    private Material mat_flash;
    private Material mat_default;
    private Object explosionRef;

    Vector2 size;

    //only used for upgradable viruses
    [SerializeField]
    private Animator upgrade_anim;

    [SerializeField]
    private ParticleSystem expire_anim;

    //false when virus dies natural death
    public bool killed;

    bool virus_can_move;

    //permanenly false once the virus is hit
    bool virus_can_upgrade;

    [SerializeField]
    //true for all except boss and minions
    bool upgradable_virus;

    // stronger viruses take longer to upgrade
    [SerializeField]
    float time_to_upgrade;

    [SerializeField]
    GameObject upgrade;
    bool upgrading;

    // stronger viruses take longer to expire (aka lifespan)
    [SerializeField]
    float time_to_expire;

    //Fields for boss and minion
    [SerializeField]
    bool is_boss;

    [SerializeField]
    GameObject minion;

    [SerializeField]
    bool is_minion;

    float next_spawn_time;
    [SerializeField]
    float minion_spawn_rate;

    // Start is called before the first frame update
    void Start()
    {
        // Begin each game by giving each virus a position to move to
        target = GetRandomTarget();
        killed = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        upgrading = false;
      
        if (upgradable_virus && VirusController.instance.viruses_can_upgrade && !GameController.instance.game_over)
        {
            StartCoroutine(Upgrader());
        }
        if (VirusController.instance.viruses_can_expire && !GameController.instance.game_over)
        {
            StartCoroutine(VirusExpiration());
        }
        mat_flash = Resources.Load("Flasher", typeof(Material)) as Material;
        mat_default = spriteRenderer.material;
        explosionRef = Resources.Load("Virus Explosion");

        expire_anim.Stop();

        if (!is_minion)
        {
            healthBar.SetHealth(current_health, original_health);
        }

        virus_can_upgrade = true;
        virus_can_move = true;

        size = GetComponent<Collider2D>().bounds.size;
    }

    void Update()
    {
        if (!is_boss && virus_can_move)
        {
            Movement();
        }

        if (is_boss && ShouldSpawnMinion())
        {
            SpawnMinion();
        }
    }


    void OnTriggerEnter2D(Collider2D items)
    {
        // when the pallet hits the wall, destroy it.
        if (items.gameObject.CompareTag("bullet"))
        {
            current_health--;
            //SoundManager.instance.play_Requested_Audio(SoundManager.instance.virus_hit);
            spriteRenderer.material = mat_flash; //to display hit animation
            virus_can_upgrade = false;  //once the sanitizer has hit the virus, it can never upgrade

            if (current_health <= 0)
            {
                StartCoroutine(Death());
            }
            else
            {
                Invoke("ResetMaterial", .1f);
                if (!is_minion) {
                    healthBar.SetHealth(current_health, original_health);
                }
            }
        }

        else if (items.gameObject.CompareTag("vaccine_shot"))
        {
            StartCoroutine(Death());
        }
    }

    void ResetMaterial()
    {
        spriteRenderer.material = mat_default;
    }

    public void CallDeath()
    {
        StartCoroutine(Death());
    }

    public IEnumerator Death()
    {
        if (!upgrading)
        {
            if (killed)
            {
                GameObject explosion = (GameObject)(Instantiate(explosionRef));
                explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
            else //virus expiring
            {
                virus_can_move = false;
                expire_anim.Play();
                yield return new WaitForSeconds(1.5f);
            }
        }

        VirusController.instance.alive_viruses.Remove(gameObject);
        if(gameObject!= null)
        {
            Destroy(gameObject);
        }
    }

    void Movement()
    {
        if (VirusController.instance.viruses_can_move)
        {
            if (!is_boss)
            {
                virus_speed = Mathf.Lerp(VirusController.instance.min_virus_speed, VirusController.instance.max_virus_speed,
                GameController.instance.GetDifficultyPercent());
            }
            else
            {
                virus_speed = 10;
            }

            //if the virus has not reach its desired position move there, otherwise calculate a new position
            if ((Vector2)transform.position != target)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, virus_speed * Time.deltaTime);
            }
            else
            {
                target = GetRandomTarget();
            }
        }
    }

    //Method to calculate a random position for the virus
    Vector2 GetRandomTarget()
    {
        float leftmost = VirusController.instance.left_edge + (.5f * size.x);
        float rightmost = VirusController.instance.right_edge - (.5f * size.x);
        float bottommost= VirusController.instance.bottom_edge + (.5f * size.y);
        float topmost = VirusController.instance.top_edge - (.5f * size.y);

        float random_xpos = Random.Range(leftmost, rightmost);
        float random_ypos = Random.Range(bottommost, topmost);
        return new Vector2(random_xpos, random_ypos);
    }

    IEnumerator Upgrader()
    {
        yield return new WaitForSeconds(time_to_upgrade);
        if (virus_can_upgrade && VirusController.instance.viruses_can_upgrade)
        {
            GameObject test = this.gameObject;
            upgrade_anim.SetTrigger("upgrader");
            yield return new WaitForSeconds(.6f);//give animtion time
            GameObject upgraded_virus = Instantiate(upgrade, transform.position, Quaternion.identity);
            VirusController.instance.alive_viruses.AddLast(upgraded_virus); //enqueue
            upgrading = true;
            if (test != null)
            {
                StartCoroutine(Death());
            }
        }
    }

    IEnumerator VirusExpiration() //when viruses die a natural death
    {
        yield return new WaitForSeconds(time_to_expire);
        if (VirusController.instance.viruses_can_expire )
        {            
            killed = false;
            CallDeath();
        }
    }
   
    private void SpawnMinion()
    {
        next_spawn_time = Time.time + minion_spawn_rate;
        GameObject spawned_minion = Instantiate(minion, transform.position, Quaternion.identity);
        VirusController.instance.alive_viruses.AddLast(spawned_minion); //enqueue
    }

    private bool ShouldSpawnMinion()
    {
        return Time.time >= next_spawn_time && VirusController.instance.viruses_can_spawn;
    }

}
