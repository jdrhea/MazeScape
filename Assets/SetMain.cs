using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetMain : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
