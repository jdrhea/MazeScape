using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    private int scoreValue = 3;
    Vector2 startPos;
    public Text health;
    private int healthValue = 100;

    

    private void Start()
    {
         startPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
       if (collision.CompareTag("innerEnemy") && !Input.GetKeyDown(KeyCode.Space))
       {
            healthValue -= 20;
            SetHealth();
           
       }
       if (collision.CompareTag("spike"))
       {
            healthValue -= 40;
            SetHealth();
           
       } 
       if (healthValue <= 0) // for health !
       {
            Die();
            healthValue = 100;
            SetHealth();
       } 
       if (scoreValue == 0) // for lives !
       {
            healthValue = 100;
            resetLives();
            SetScore();
       }
       if (collision.CompareTag("xp"))
        {
            Debug.Log("derp");
            collision.gameObject.SetActive(false);
            healthValue += 20;
            SetHealth();
        } 
    }
    void Die()
    {
        Deathscreen();
        Debug.Log("D'oh!");
        scoreValue -= 1;
        SetScore();
        SetHealth();
        
    }
    void Deathscreen(){
        SceneManager.LoadSceneAsync("Game Over");
    }
    void SetScore(){
        score.text = "L: " + scoreValue;
    }
    void SetHealth(){
        health.text = "HP: " + healthValue;
    }
    void resetLives(){
        healthValue = 100;
        scoreValue = 3;
        
    }
}
