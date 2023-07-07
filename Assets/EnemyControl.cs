using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 startPos;

    private void Start()
    {
         startPos = transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("enemy"))
       {
            Die();
       } 
    }
    void Die()
    {
        Respawn();
        Debug.Log("D'oh!");
    }
    void Respawn()
    {
        transform.position = startPos;
    }
}
