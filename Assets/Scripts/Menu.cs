using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject shopPanel, SoundButton;
    public AudioSource BGMusicAudioSource;
    public Sprite AudioOn, AudioOff;

    private void Start()
    {
        AudioSettings();
    }

    public void Play()
    {
        if (SaveData.instance.m_Count == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SaveData.instance.m_Count);
        }
    }

    public void Exit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

    public void Shop()
    {
        shopPanel.SetActive(true);
    }

    public void AudioSettings()
    {
        if (/*BGMusicAudioSource.isPlaying && */SaveData.instance.SettingsCount == 0)
        {
            SoundButton.GetComponent<Image>().sprite = AudioOn;
            BGMusicAudioSource.Play();
            SaveData.instance.SettingsCount = 1;
        }
        else
        {
            SoundButton.GetComponent<Image>().sprite = AudioOff;
            BGMusicAudioSource.Stop();
            SaveData.instance.SettingsCount = 0;            
        }
        SaveData.instance.SettingsCounter();
    }


}