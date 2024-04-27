using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMine : MonoBehaviour
{
    void OnMouseDown()
    { 
        Destroy(gameObject);
    }
}
