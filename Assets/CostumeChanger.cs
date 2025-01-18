using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostumeChanger : MonoBehaviour
{
    [Header("Sprite to Change")]
    public SpriteRenderer costumePart;
    public SpriteRenderer costumePartGame;
    public SpriteRenderer StripedBlueSkin;
    public Sprite Sprefab;
    public SpriteRenderer CapsuleSkin;
    public Sprite Cprefab;


    [Header("Sprites to Cycle Through")]
    public List<Sprite> options = new List<Sprite>();

    private int CurrentOption = 0;

    
    public void NextOption()
    {
        Debug.Log("works");
        CurrentOption++;
        if(CurrentOption >= options.Count)
        {
            CurrentOption = 0;
        }
        costumePart.sprite = options[CurrentOption];
        costumePartGame.sprite = options[CurrentOption];
    }
    public void PreviousOption()
    {
        CurrentOption--;
        if(CurrentOption <= 0)
        {
            CurrentOption = options.Count - 1;
        }
        costumePart.sprite = options[CurrentOption];
        costumePartGame.sprite = options[CurrentOption];
    }
    public void Randomize()
    {
        CurrentOption = Random.Range(0, options.Count - 1);
        costumePart.sprite = options[CurrentOption];
    }
    void Update()
    {
        if(CoinCollector.IsStripedSkinAdded == true)
        {
            Sprite StripedBlueSkin = Instantiate(Sprefab);
            options.Add(StripedBlueSkin);
        }
        if(CoinCollector.IsCapsuleSkinAdded == true)
        {
            Sprite CapsuleSkin = Instantiate(Cprefab);
            options.Add(CapsuleSkin);
        }
    }


    
}
