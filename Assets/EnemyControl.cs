using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
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

    // Update is called once per frame which idc ahaahhahahahhha
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("enemy"))
       {
            healthValue -= 20;
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
            Respawn();
            resetLives();
            SetScore();
       } 
    }
    void Die()
    {
        Respawn();
        Debug.Log("D'oh!");
        scoreValue -= 1;
        SetScore();
        SetHealth();
        
    }
    void Respawn(){
        transform.position = startPos;
    }
    void SetScore(){
        score.text = "L: " + scoreValue;
    }
    void SetHealth(){
        health.text = "HP " + healthValue;
    }
    void resetLives(){
        healthValue = 100;
        scoreValue = 3;
        
    }
}
