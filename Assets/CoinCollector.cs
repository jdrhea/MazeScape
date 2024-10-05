using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public Text health;
    public Text score;
    static protected int scoreValue = 0;

    public Text Item1CostText;
    public Text Item2CostText;
    public Text Item3CostText;
    public Text Item4CostText;

    public int Item1Cost = 10;
    public int Item2Cost = 20;
    public int Item3Cost = 25;
    public int Item4Cost = 30;
    public int Item5Cost = 50;
    public static bool IsStripedSkinAdded = false;
    public static bool IsCapsuleSkinAdded = false;
    public static bool GameIsPaused = false;
    public Image StaminaBar;


    public void OpenShop()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            collision.gameObject.SetActive(false);
            scoreValue += 1;
            SetScore();
        }
    }
    void FixedUpdate()
    {
        Item1CostText.text = "+10 Health Points: $" + Item1Cost;
        Item2CostText.text = "+20 Stamina Points: $" + Item2Cost;
    }
    void Update()
    {
        if(PlayerHealth.LoseCoins == true)
        {
            scoreValue = 0;
            PlayerHealth.LoseCoins = false;
            SetScore();
            
        }

    }
    public void Upgrade1Buy()
    {
        
       if(scoreValue >= Item1Cost)
        {
            scoreValue -= 10;
            PlayerHealth.healthValue += 20;
            GameIsPaused = true;
            Time.timeScale = 0f;
            SetScore();
            SetHealth();
        }
        else
        {
            Time.timeScale = 0f;
        }
        
    }
    public void Upgrade2Buy()
    {
        
       if(scoreValue >= Item2Cost)
        {
            scoreValue -= 20;
            DecreaseHunger(20);
            GameIsPaused = true;
            Time.timeScale = 0f;
            SetScore();
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
    public void Upgrade3Buy()
    {
        
       if(scoreValue >= Item3Cost)
        {
            scoreValue -= 25;
            PlayerHealth.healthValue = 200;
            GameIsPaused = true;
            Time.timeScale = 0f;
            SetScore();
            SetHealth();
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
    public void Upgrade4Buy()
    {
        
       if(scoreValue >= Item4Cost)
        {
            scoreValue -= 30;
            GameIsPaused = true;
            Time.timeScale = 0f;
            IsStripedSkinAdded = true;
            SetScore();
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
    public void Upgrade5Buy()
    {
        
       if(scoreValue >= Item5Cost)
        {
            scoreValue -= 50;
            GameIsPaused = true;
            Time.timeScale = 0f;
            IsCapsuleSkinAdded = true;
            SetScore();
        }
        else
        {
            Time.timeScale = 0f;
        }
    }


    void SetScore()
    {
        score.text = "$" + scoreValue;
    }
    void SetHealth()
    {
        health.text = "HP: " + PlayerHealth.healthValue;
    }
    public void DecreaseHunger(float fill)
    {
        PlayerMove.EnergyAmount += fill;
        StaminaBar.fillAmount = PlayerMove.EnergyAmount / 100f;


    }
}
