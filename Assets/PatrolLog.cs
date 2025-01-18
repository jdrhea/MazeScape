using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatrolLog : MonoBehaviour
{
    public GameObject pointa;
    public GameObject pointb;
    public Rigidbody2D rb;
    public Transform currentPoint;
    public float speed;
    public Image healthBar;
    public float healthAmount = 100f;
    

    public Text power;

    public bool isCollision = false;
    
   
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointb.transform;
        ObjectCollector.currentPowerValue = 1;
        

    }

    
    public void Update()
    {
        if (gameObject.CompareTag("enemy"))
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
            HealthBarUpdate();
        

        }
        if (gameObject.CompareTag("verticalenemy"))
        {
            Vector2 point = currentPoint.position - transform.position;
            if(currentPoint == pointb.transform)
            { 
                rb.velocity = new Vector2(0, speed);
            }
            else
            {
                rb.velocity = new Vector2(0, -speed);
            }
        
            if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointb.transform)
            {
                currentPoint = pointa.transform;
            }
            if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointa.transform)
            {
                currentPoint = pointb.transform;
            }

            HealthBarUpdate();  
        }
    }
    void HealthBarUpdate()
    {
        if (healthAmount <= 0)
        {
            
            Destroy(gameObject);
            
        }
        if (ObjectCollector.currentPowerValue == 1 && isCollision)
        {
            TakeDamage(10);
            
        
        
        }
        if (ObjectCollector.currentPowerValue == 2 && Input.GetKeyDown(KeyCode.Space) && isCollision)
        {
            TakeDamage(20);
            
        }
        if (ObjectCollector.currentPowerValue == 3 && Input.GetKeyDown(KeyCode.Space) && isCollision)
        {
            TakeDamage(50);
            
        }
    
       
    
           
    }
     private void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.CompareTag("player"))
        {
            isCollision = true;
        }
     }

    private void OnTriggerExit2D(Collider2D collision)
     {
        if (collision.CompareTag("player"))
        {
            isCollision = false;
        }
     }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;


    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
    
}
