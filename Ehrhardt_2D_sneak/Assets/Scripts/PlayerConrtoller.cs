using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConrtoller : MonoBehaviour
{

    public float speed = 5.0f;
    public float jumpheight = 10.0f;

    PlayerInput input;
    Rigidbody rb; 

    public Vector2 moveInput = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
