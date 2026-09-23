using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerController : MonoBehaviour
{
    public int health = 5;
    public int maxHealth = 5;
    public float speed = 5.0f;
    public float jumpHeight = 5f;
    public float jumpDetectDistance = 1.1f;
    
    Ray2D jumpRay;
    Vector2 moveInput = Vector2.zero;

    public GameObject currentWeaponObj;
   
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
        jumpRay.origin = transform.position;
        jumpRay.direction = -transform.up;


        rb.linearVelocityX = moveInput.x * speed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput.x = context.ReadValue<Vector2>().x;
    }

    public void Jump()
    {
        if (Physics2D.Raycast(jumpRay.origin, jumpRay.direction, jumpDetectDistance))
            rb.AddForceY(jumpHeight, ForceMode2D.Impulse);
    }

}