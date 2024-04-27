using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotImage : MonoBehaviour
{
    public Sprite sword;
    public Sprite block;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sword") //if sword is collected, put in inventory
        {
            GetComponent<Image>().sprite = sword;
        }
        else if ( collision.gameObject.tag == "block")
        {
            GetComponent<Image>().sprite = block;
        }
        
    }
}
