using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConrtoller : MonoBehaviour
{
    public int health = 5;
    public int maxHealth = 5;

    public float speed = 5.0f;
    public float jumpheight = 10.0f;
    public float jumpDetectDistance = 1f;
    Ray2D jumpRay;
    Vector2 moveInput = Vector2.zero;

    PlayerInput input;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        jumpRay = new Ray2D();
    }

    // Update is called once per frame
    void Update()
    {

        rb.linearVelocityX = moveInput.x * speed;

        if (health <= 0) ;
        {


        }
        
        jumpRay.origin = transform.position;
        jumpRay.direction = -transform.up;

    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput.x = context.ReadValue<Vector2>().x;
    }

    public void Jump()
    {

        if (Physics2D.Raycast(jumpRay.origin, jumpRay.direction, jumpDetectDistance))
            rb.AddForceY(jumpheight, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            health--;
        }
    }


  
   


}