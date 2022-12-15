using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] int difficultyLevel;
    [SerializeField] int option;
    [SerializeField] bool isMusicMuted;
    [SerializeField] bool isNotificationsOn;
    [SerializeField] float volume;

    public static PersistentData Instance;
    void Awake() {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
        difficultyLevel = 0;
        option = 0;
        isNotificationsOn = true;
        volume = 1.0f;
        isMusicMuted = false;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void SetName (string name) {
        playerName = name;
    }
    public void SetDifficulty (int difficulty) {
        difficultyLevel = difficulty;
    }
    public void SetOption(int selectedOption) {
        option = selectedOption;
    }
    public int GetOption() {
        return option;
    }
    public void SetNotificationsOption(bool notificationOption) {
        isNotificationsOn = notificationOption;
    }
    public bool GetNotificationsOption() {
        return isNotificationsOn;
    }
    public void SetScore (int score) {
        playerScore = score;
    }
    public string GetName () {
        return playerName;
    }
    public int GetScore () {
        return playerScore;
    }
    public float GetVolume () {
        return volume;
    }
    public string GetDifficulty () {
        return difficultyLevel == 1 ? "Difficult" : "Easy";
    }

    public bool GetMusicOption () {
        return isMusicMuted;
    }
    public void SetMusicOption (bool option) {
        isMusicMuted = option;
    }
    public void SetVolume (float volumeValue) {
        volume = volumeValue;
    }
}
