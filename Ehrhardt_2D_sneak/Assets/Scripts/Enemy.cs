using UnityEngine;

public class Enemy : MonoBehaviour

    public PlayerConrtoller player;

public bool isFollowing = false;

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerConrtoller>();


    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)



    }

    



}
