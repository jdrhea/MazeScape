using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolLog : MonoBehaviour
{
    public GameObject pointa;
    public GameObject pointb;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointb.transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointb.transform)
        { 
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointb.transform)
        {
            currentPoint = pointa.transform;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointa.transform)
        {
            currentPoint = pointb.transform;
        }
        
        
    }
}
