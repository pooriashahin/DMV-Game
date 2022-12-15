using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayName : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] string playerName;

    public static PlayName Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        playerName = "";
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    public string GetName()
    {
        return playerName;
    }

    public void SaveName()
    {
        playerName = nameInput.text;
    }
}

// Edited by Edward Lee

