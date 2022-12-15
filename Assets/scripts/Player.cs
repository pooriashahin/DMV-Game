using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDB characterDB;

    public SpriteRenderer carSprite;

    private int selectedOption = 0;

    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        updateCharacter(selectedOption);
    }
    
    private void updateCharacter(int selectedOption)
    {
        Character character = characterDB.getCharacter(selectedOption);
        carSprite.sprite = character.characterSprite;
        //carName.text = character.characterName;
    }
    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

}
