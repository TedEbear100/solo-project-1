using UnityEngine;

public class AdvancedEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
   
                
    }

    public void Jump()
    {
        if (Physics2D.Raycast(jumpRay.origin, jumpRay.direction, jumpDetectDistance))
            rb.AddForceY(jumpHeight, ForceMode2D.Impulse);
    }


    private void OnCollisionEnter2D(Collision collision)
    {
        if(collision.gameObject == "Player")
        {
            
        }

    }
}

