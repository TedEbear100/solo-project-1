using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    public int health = 5;
    public int maxHealth = 5;
    public float speed = 5.0f;
    public float sprintBoost = 2.0f;
    public float stamina = 100f;
    public float maxStamina = 100f;
    public float sprintCost = 10f;
    public float sprintCooldown = 2;
    public float staminaRegen = 5;
    public float jumpHeight = 5f;
    public float jumpDetectDistance = 1.1f;
    public float attackTime = .5f;
    public float attackCooldownTime = 1f;
    public float PhysicMaterial;

    public bool onGround = true;
    public bool sprinting = false;
    public bool canSprint = true;
    public bool sprintLock = false;
    public bool regenStamina = false;
    public bool toggleSprint = false;
    public bool isAttacking = false;
    public bool canAttack = false;
    
    Ray2D jumpRay;
    Vector2 moveInput = Vector2.zero;

    public GameObject currentWeaponObj;
    Transform weaponSlot;
    PlayerInput input;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        jumpRay = new Ray2D();
        weaponSlot = transform.GetChild(0);
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
         onGround = Physics2D.Raycast(jumpRay.origin, jumpRay.direction, jumpDetectDistance);
        jumpRay.origin = transform.position;
        jumpRay.direction = -transform.up;

        Vector2 tempMove = rb.linearVelocity;

        tempMove.x = moveInput.x * speed;

        if (sprinting)
        {

            tempMove.x *= sprintBoost;

            stamina -= sprintCost * Time.deltaTime;

            StopCoroutine("sprintReset");
            regenStamina = false;

            if (stamina <= 0)
            {
                canSprint = false;
                sprinting = false;
                stamina = 0;
            }
        }
        if (moveInput.x < .75 && moveInput.x > -.75f)
        {
            canSprint = false;
            sprinting = false;

        }
    
        if (!sprinting)
        {
            if (!canSprint && !sprintLock)
            {
                StartCoroutine("sprintReset");
            }
        
            if (canSprint && !regenStamina)
            {
                regenStamina = true;
            }
        
            if (regenStamina)
            {
                stamina += staminaRegen * Time.deltaTime;

                if (stamina >= maxStamina)
                {
                    stamina = maxStamina;
                    regenStamina = false;
                }
            }
        
        }

        rb.linearVelocityX = tempMove.x;
    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput.x = context.ReadValue<Vector2>().x;
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if (canSprint && (moveInput.x >= .75f || moveInput.x <= -.75f) && onGround)
        {
            if (!toggleSprint)
            {
                if (context.ReadValueAsButton())
                    sprinting = true;
                else
                    sprinting = false;

                if (!sprinting)
                    canSprint = false;
            }
            else
            {
                if (context.performed)
                    sprinting = !sprinting;
            }
        }
    }
    public void Jump()
    {
        if (onGround)
            rb.AddForceY(jumpHeight, ForceMode2D.Impulse);
    }

    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.tag == "Hazard")
        {
            health--;
        }
        if (collision.gameObject.tag == "Insta death")
        {
            health = 0;
        }
        

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelOver")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().LoadNextNevel();
        }
        if (other.gameObject.tag == "Power up")
        {
            
        
        }
    }
    
    
    IEnumerator sprintReset()
    {
        sprintLock = true;
        regenStamina = false;

        yield return new WaitForSeconds(sprintCooldown);

        canSprint = true;
        regenStamina = true;
        sprintLock = false;
    }


}