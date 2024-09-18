using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    
    Vector2 startPos;
    public Text health;
    public static int healthValue = 100;

    public float WaterValue = 100;

    public GameObject DeathScreenUI;
    public GameObject WaterBarUI;
    public GameObject player;
    public Image WaterBar;
    public float WaterTimer;
    public bool isWater = false;
    public static bool LoseCoins = false;
    
    AudioManager AudioManager;

    private void Awake()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }



    private void Start()
    {
         startPos = transform.position;
         player.SetActive(true);
         WaterBarUI.SetActive(false);
        
    }
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {    
            isWater = true;
            WaterBarUI.SetActive(true);
        }
        
      
       if (collision.CompareTag("innerEnemy") && !Input.GetKeyDown(KeyCode.Space))
       {
            healthValue -= 20;
            SetHealth();
           
       }
       if (collision.CompareTag("fasterinnerEnemy") && !Input.GetKeyDown(KeyCode.Space))
       {
            healthValue -= 25;
            SetHealth();
           
       }
       if (collision.CompareTag("spike"))
       {
            healthValue -= 40;
            SetHealth();
           
       }
       if (collision.CompareTag("lava"))
        {
            
            healthValue -= 100;
            SetHealth();
        }  
        if (collision.CompareTag("bullet"))
        {
            collision.gameObject.SetActive(false);
            healthValue -= 50;
            SetHealth();
        } 
       if (healthValue <= 0) // for health !
       {
            Die();
            healthValue = 100;
            SetHealth();
       } 
       if (collision.CompareTag("xp"))
        {
            collision.gameObject.SetActive(false);
            healthValue += 20;
            SetHealth();
        } 
        if (collision.CompareTag("???"))
        {
            collision.gameObject.SetActive(false);
            healthValue += 0;
            SceneManager.LoadSceneAsync("Secret");
            SetHealth();
        }
    
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {    
            isWater = false;
            WaterBarUI.SetActive(false);
            WaterTimer = 0;
            
        }
    }
    void Update()
    {
        if(isWater == true)
        {
            WaterTimer += Time.deltaTime;

            if(WaterTimer >= 4)
            {
                LoseAir(20);
                WaterTimer = 0;
                if(WaterValue == 0)
                {
                    Die();
                }
            }
        }
        else if(isWater == false)
        {
            WaterValue = 100;
        }
        
        
    }
    void Die()
    {
        AudioManager.PlaySFX(AudioManager.oof);
        startPos = transform.position;
        player.SetActive(false);
        LoseCoins = true;
        Deathscreen();
        SetHealth();
        
    }
    void Deathscreen(){
        
        DeathScreenUI.SetActive(true);
        SetHealth();
    }

    void SetHealth(){
        health.text = "HP: " + healthValue;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        DeathScreenUI.SetActive(false);
        player.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoseAir(float damage)
    {
        WaterValue -= damage;
        WaterBar.fillAmount = WaterValue / 100f;


    }

   
}
