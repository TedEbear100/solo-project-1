using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    SpriteRenderer sr;
    Animator Anim;
    public PlayerController Player;
   
    public bool isFollowing = false;

    public int health = 3;
    public int maxHealth = 5;
    public float speed = 5;
    public float detectionDistance = 5;
    public float stoppingDistance = 1;
    public float attackTime = 1f;
    public float attackCooldownTime = 5.5f;
    public bool attackCooldown = false;

    public bool isAttacking = false;
    public bool canAttack = true;
    public bool waitToAttack = false;

    public int damage = 1;


    
    public PlayerController player;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Anim = GetComponent<Animator>();

    }
        // Update is called once per frame
        void Update()
        {
            float targetDistance = Vector2.Distance(player.transform.position, transform.position);

            isFollowing = targetDistance <= detectionDistance;

            Anim.SetBool("isWalking", isFollowing);
            Anim.speed = speed / 3.5f;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
            if (isAttacking == true)
            {
                waitToAttack = true;
                canAttack = false;
                attackCooldown = true;
            }
            if (isFollowing)
            {

                if (player.transform.position.x > transform.position.x)
                {
                    sr.flipX = false;
                    rb.linearVelocityX = speed;
                }
                else if (player.transform.position.x < transform.position.x)
                {
                    rb.linearVelocityX = -speed;
                    sr.flipX = true;
                }

                if (targetDistance <= stoppingDistance)
                    rb.linearVelocityX = 0;
                   Anim.SetBool("isWalking", false);
                if (isAttacking == true)
                {
                    player.health--;
                }
            }
                else
                rb.linearVelocityX = 0;
        }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MeleeZone")
        {
            health--;

        }
        if (collision.gameObject.tag == "Player")
        {
            isAttacking = true;
            
        }
        if (collision.gameObject.tag == "Hazard")
        {
            health--;
        }
        if (collision.gameObject.tag == "Insta death")
        { 
            health = 0;
        
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { 
            
              
            
        }
    }
    
}
