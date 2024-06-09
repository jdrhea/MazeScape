using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControl : MonoBehaviour
{

    public Transform destination;
    GameObject player;


    void Update()
    {
        transform.Rotate (0f,0f,200f*Time.deltaTime, Space.Self); //rotates 50 degrees per second around z axis
    }

    private void Awake()
    {
         player = GameObject.FindGameObjectWithTag("player");
    }
       


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 0.3f)
            {
                player.transform.position = destination.transform.position;
            }
        }
    }
    
}    
