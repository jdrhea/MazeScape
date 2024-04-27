using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTest : MonoBehaviour
{
    public float Collect = 0f;
    public Image healthBar;
    public bool isCollision = false;

    void Update()
    {
        if (isCollision)
        {
            Fill(100);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("sword"))
        {
            isCollision = true;
        }
    }

    public void Fill(float amount)
    {
        Collect += amount;
        healthBar.fillAmount = Collect / 100f;


    }
}
