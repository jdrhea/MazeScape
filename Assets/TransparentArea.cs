using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentArea : MonoBehaviour
{

    public bool isTransparent = false;

    public SpriteRenderer TransparentAreaR;

    Color TransparentAreaColor;

    public bool isCollision = false;

    public float transitionSpeed;

    public bool Transparent = false;


    void Update()
    {
        if (isCollision == true)
        {
            TransparentAreaColor.a = Mathf.Lerp (TransparentAreaColor.a,  0f, transitionSpeed);

            TransparentAreaR.color = TransparentAreaColor;
        }  
        else
        {
            TransparentAreaColor.a = Mathf.Lerp (TransparentAreaColor.a, 255f, transitionSpeed);

            TransparentAreaR.color = TransparentAreaColor;
        }  
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transparent")
        {
            isCollision = true;
        } 
        
    }
       
       
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Transparent")
        {
            isCollision = false;
        } 
    } 
       
    
}
