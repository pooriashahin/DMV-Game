using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDB characterDB;
    public Text carName;
    public SpriteRenderer carSprite;

    private int selectedOption = 0;
    void Start()
    {
        // if (!PlayerPrefs.HasKey("selectedOption"))
        // {
        //     selectedOption = 0;
        // }
        // else
        // {
        Load();
        // }
        updateCharacter(PersistentData.Instance.GetOption());
    }
    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }
        updateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        updateCharacter(selectedOption);
        Save();
    }

    private void updateCharacter(int selectedOption)
    {
        Character character = characterDB.getCharacter(selectedOption);
        carSprite.sprite = character.characterSprite;
        // carName.text = character.ToString();
    }

    private void Load()
    {
        // selectedOption = PlayerPrefs.GetInt("selectedOption");
        selectedOption = PersistentData.Instance.GetOption();
        Character character = characterDB.getCharacter(selectedOption);
        carSprite.sprite = character.characterSprite;
    }
    private void Save()
    {
        // PlayerPrefs.SetInt("selectedOption", selectedOption);
        PersistentData.Instance.SetOption(selectedOption);
    }
    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
