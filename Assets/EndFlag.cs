using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public GameObject pointc;
    public GameObject pointd;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointd.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointd.transform)
        { 
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointd.transform)
        {
            currentPoint = pointc.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointc.transform)
        {
            currentPoint = pointd.transform;
        }
        
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("player"))
       {
            Debug.Log("YOU WIN!!");
            SceneManager.LoadSceneAsync("WinScreen");
       } 
    }
}

