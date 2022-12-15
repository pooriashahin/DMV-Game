using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image SoundOnIcon;
    [SerializeField] Image SoundOffIcon;
    [SerializeField] Slider slider;

    private bool muted = false;

    void Start()
    {
        muted = PersistentData.Instance.GetMusicOption();

        if (slider == null) {
        slider = GetComponent<Slider>();
        }

        slider.value = PersistentData.Instance.GetVolume();
        AudioListener.volume = slider.value;

        UpdateBtnIcon();
    }

    public void OnButtonPress()
    {
        muted = !muted;
        Save();
        UpdateBtnIcon();
    }

    private void UpdateBtnIcon()
    {
        if (muted == false)
        {
            SoundOnIcon.enabled = true;
            SoundOffIcon.enabled = false;
        }
        else
        {
            SoundOnIcon.enabled = false;
            SoundOffIcon.enabled = true;
        }
    }

    public void ChangeVolume() {
        AudioListener.volume = slider.value;
        PersistentData.Instance.SetVolume(slider.value);
    }

    private void Load()
    {
        // muted = PlayerPrefs.GetInt("muted") == 1; 
        muted = PersistentData.Instance.GetMusicOption();
    }
    private void Save()
    {
        // PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        PersistentData.Instance.SetMusicOption(muted == true ? true : false);
    }
}
