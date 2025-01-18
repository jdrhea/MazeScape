using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartDeathUI : MonoBehaviour
{
    public GameObject DeathScreenUI;

    
    public void PlayGame()
    {
        DeathScreenUI.gameObject.SetActive(false);
    }
}
