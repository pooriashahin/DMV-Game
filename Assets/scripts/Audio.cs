using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio instance;
    [SerializeField] AudioSource audio;
    [SerializeField] bool isMusicMuted;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }

    }

    void Start() {

    }

    void Update() {
        isMusicMuted = PersistentData.Instance.GetMusicOption();

        if (isMusicMuted) {
            audio.mute = true;
        } else {
            audio.mute = false;
        }


    }
}
