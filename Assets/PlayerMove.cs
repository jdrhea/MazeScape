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
    public float EnergyAmount = 100f;
    public Rigidbody2D rb = new Rigidbody2D();
    private float activeMoveSpeed;
    public float dashSpeed;
    public float dashLength = .5f, dashCoolDown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    public bool HungerOn = false;

    Vector2 movement;

    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb2d.velocity = movement * activeMoveSpeed;

        if (Input.GetKeyDown("left shift"))
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
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
        
            if (collision.CompareTag("apple"))
                {
                    collision.gameObject.SetActive(false);
                    DecreaseHunger(20);
                
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
        SceneManager.LoadSceneAsync("GameOver");
    }
}
