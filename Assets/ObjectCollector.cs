using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectType
{
    public string objectName;
    public int scoreValue;
    public int powerValue;
    public int quantity;

}

public class ObjectCollector : MonoBehaviour
{
    public Hashtable inventory = new Hashtable();
    public Text currentObjectName;
    public Text currentPower;
    public Image slot0;
    public Image slot0b;

    public float AppearAmount = 0f;
    public float AppearAmount2 = 0f;
    public static int currentPowerValue = 1;
    private int currentScoreValue = 0;

    public bool isCollisionSword = false;

    public bool isCollisionBlock = false;

    public Transform childBlock;

    public Transform parent;

    public Transform newParent;

    public Transform childSword;

    public bool isNewParentSword = false;

    public bool isNewParentBlock = false;

    


    

    void Update()
    {
        if (isCollisionSword) // sword is collected
        {
            TakeSword(100);
            if (isCollisionBlock) //isCollioison block refers to colliding with player
            {
                BlockNewParent(newParent);
                //isCollisionBlock = false;
                
                
            }
            if (isNewParentBlock == true)
            {
                //SwordNewParent(newParent);
                SwordParent(parent);
                isNewParentBlock = false;    
            }
            
    
        }
        if (isCollisionBlock)
        {
            TakeBlock(100);
            if (isCollisionSword)
            {
                SwordNewParent(newParent);
                //isCollisionSword = false;
            }
            if (isNewParentSword == true)
            {
                // BlockNewParent(parent);
                BlockParent(parent);
                isNewParentSword = false;
                
            }
        }
        
        
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            slot0.gameObject.SetActive(false);
        }
    }
        
    

    private void OnTriggerEnter2D(Collider2D collision)

    {
        
        if (collision.gameObject.tag == "sword") //if sword is collected, put in inventory
        {

            isCollisionSword = true;
            collision.gameObject.SetActive(false);//make it gone
            if(inventory.ContainsKey("sword")){//if it already in there, put another
                ((ObjectType)inventory["sword"]).quantity += 1;
            
            } else {
                inventory.Add("sword", new ObjectType());
                Debug.Log("collect");
            }
            SetCurrentObjectType("sword", 2, 1);
        }
        else if (collision.gameObject.tag == "block")
        {
            
            isCollisionBlock = true;
            collision.gameObject.SetActive(false);
            if(inventory.ContainsKey("block")){
                ((ObjectType)inventory["block"]).quantity += 1;
            } else {
                inventory.Add("block", new ObjectType());
                Debug.Log("collect");
            }
            SetCurrentObjectType("block", 1, 1);
        }
        
    }


    void SetCurrentObjectType( string objectName, int objectPower, int objectScore){
        currentObjectName.text = "Inventory: " + objectName;
        currentPowerValue = objectPower;
        currentPower.text = "SP" + objectPower;
        currentScoreValue += objectScore;
    }
    public void TakeSword(float Collect)
    {
        AppearAmount = Collect;
        slot0.fillAmount = AppearAmount / 100f;


    }
    public void TakeBlock(float Collect2)
    {
        AppearAmount2 = Collect2;
        slot0b.fillAmount = AppearAmount2 / 100f;


    }
    public void BlockNewParent(Transform newParentB)
    {
        childBlock.transform.SetParent(newParent);
        childBlock.position = newParentB.position;
        isNewParentBlock = true;
        
    }
    public void SwordNewParent(Transform newParentA)
    {
        childSword.transform.SetParent(newParent);
        childSword.position = newParentA.position;
        isNewParentSword = true;

        
    }
    public void BlockParent(Transform Slot)
    {
        childBlock.transform.SetParent(parent);
        childBlock.position = Slot.position;
        //Debug.Log("works3");
    }
    public void SwordParent(Transform Slot2)
    {
        childSword.transform.SetParent(parent);
        childSword.position = Slot2.position;
        //Debug.Log("works4");
    }
    
    


    
}