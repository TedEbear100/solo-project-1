using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConrtoller : MonoBehaviour
{

    public float speed = 5.0f;
    public float jumpheight = 10.0f;
    public float jumpdetectdistance;

    PlayerInput input;
    Rigidbody2D rb;

    Ray jumpRay2D;

    public Vector2 moveInput = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        jumpRay2D = new Ray2D();
    }

    // Update is called once per frame
    void Update()
    {
        jumpRay2D.origin = transform.position;
        jumpRay2D.direction = -transform.up;

        rb.linearVelocityX = moveInput.x * speed;
  
    
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput.x = context.ReadValue<Vector2>().x;
    }

    public void Jump()
    {
       
        if (Physics2D.Raycast(jumpRay.orgin, jumpRay.direction, jumpDetectDistance))
            rb.AddForceY(jumpheight, ForceMode2D.Impulse);
    }



}

