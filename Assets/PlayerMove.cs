using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float moveSpeed = 5f;
    public Image StaminaBar;
    public static float EnergyAmount = 100f;
    public Rigidbody2D rb = new Rigidbody2D();
    [SerializeField] private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCoolDown = 1f;
    private float dashCounter;
    private float dashCoolCounter;
    public bool HungerOn = false;
    public GameObject DeathScreenUI;
    public GameObject player;
    public float acceleration = 15f;
    public float maxSpeed = 10f; 
    public float dagMaxSpeed = 0.6f; 

    public float decceleration = 1f;



    

    [SerializeField] float vertical;
    [SerializeField] float horizontal;

    void Start()
    {
        activeMoveSpeed = moveSpeed;
        player.SetActive(true);
        acceleration = 15f;
    
    }
    void Update()
    {
        Move();
    }
    public void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");


        rb.velocity = new Vector2(horizontal * activeMoveSpeed, vertical * activeMoveSpeed);


        if(activeMoveSpeed < maxSpeed)
        {
            activeMoveSpeed += Time.deltaTime * acceleration;

        }
        if (vertical == 0 && horizontal == 0)
        {
            
            activeMoveSpeed = 0f;
        }
        if (vertical == 0 && horizontal == 0)
        {
            
            activeMoveSpeed -= decceleration * Time.deltaTime;
        }
        
        if (vertical != 0 && horizontal != 0)
        {
            horizontal += dagMaxSpeed;
            vertical += dagMaxSpeed;
        }

        if (Input.GetKeyDown("left shift"))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                HungerOn = false;
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
            if (HungerOn == false)
            {
                TakeHunger(10);
            }
            
        
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        if (EnergyAmount <= 0)
        {
            Death();
            
        }

    }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Water"))
            {
                activeMoveSpeed = dashSpeed;
                acceleration = 5f;
                
            }
            if (collision.CompareTag("switch gravity"))
            {
                rb2d.gravityScale += 25;

                
            }
            if (collision.CompareTag("switch gravity back"))
            {
                rb2d.gravityScale = 0;
                
                
            }

        
            if (collision.CompareTag("apple"))
            {
                collision.gameObject.SetActive(false);
                DecreaseHunger(20);
                
            }
        
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Water"))
            {
                activeMoveSpeed = moveSpeed;
                acceleration = 15f;

                
            }
        
        }
        // if (Input.GetKeyUp(KeyCode.X))
        // {
        //     moveSpeed-=5;
        // }
        
    

    public void TakeHunger(float hunger)
    {
        EnergyAmount -= hunger;
        StaminaBar.fillAmount = EnergyAmount / 100f;


    }
    public void DecreaseHunger(float fill)
    {
        EnergyAmount += fill;
        StaminaBar.fillAmount = EnergyAmount / 100f;


    }
    public void Death()
    {
        DeathScreenUI.SetActive(true);
        player.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        DeathScreenUI.SetActive(false);
        player.SetActive(true);
        
        
    }
}
