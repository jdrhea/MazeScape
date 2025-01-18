using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CharacterCreationMenu : MonoBehaviour
{
    public CostumeChanger characterCustomization;
    
    public List<CostumeChanger> outfitChangers = new List<CostumeChanger>();
    public GameObject character;

    public GameObject modelAsset;

    public void RandomizeCharacter()
    {    
        foreach (CostumeChanger changer in outfitChangers)
        {
            changer.Randomize();

        }

    }
    public void Submit()
    {   
        #if UNITY_EDITOR
        var character = Instantiate(modelAsset);
        PrefabUtility.SaveAsPrefabAsset(character, "Assets/Editor/Player.prefab");
        // PrefabUtility.SaveAsPrefabAsset(hat, "Assets/Hat.prefab");
        DestroyImmediate (character);
        SceneManager.LoadScene(0);
        Debug.Log("scene loaded");
        #endif
    }
}
