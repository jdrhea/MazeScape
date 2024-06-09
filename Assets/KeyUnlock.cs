using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUnlock : MonoBehaviour
{
    public bool hasKey = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "key")
        {
            collision.gameObject.SetActive(false);
            hasKey = true;
        }
        if(collision.gameObject.tag == "door" && hasKey == true)
        {
            collision.gameObject.SetActive(false);
            hasKey = false;
            

        }
    }
    

}
