using UnityEngine;

public class AdvancedEnemy : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector2.Distance(player.transform.position, transform.position);

        isFollowing = targetDistance <= detectionDistance;

        if (isFollowing)
        {
            if (player.transform.position.x > transform.position.x)
            {
                rb.linearVelocityX = speed;
            }
            else if (player.transform.position.x < transform.position.x)
            {
                rb.linearVelocityX = -speed;
            }

            if (player.transform.position.y > transform.position.y)
            {
                rb.linearVelocityY = speed;
            }

            if (targetDistance <= stoppingDistance)
                rb.linearVelocityX = 0;
        } 



    }


    

}

