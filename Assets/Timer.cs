using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

        [SerializeField] TextMeshProUGUI timerText;
        [SerializeField] float remainingTime;

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60); // when to increment minutes of # of seconds
        int seconds = Mathf.FloorToInt(remainingTime % 60); // % is how much seconds to get 1 min
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(remainingTime <= 1)
        {
            Death();
        }
    }
    public void Death()
    {
        SceneManager.LoadSceneAsync("GameOver");
    }
}
