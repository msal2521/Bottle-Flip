using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject GameOverPanel;
    public TextMeshProUGUI LevelText;


    void Awake()
    {
        instance = new GameManager();
        //If we don't currently have a GameManager...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);

        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        AudioSettings();
        LevelText.text = "Level: " + SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void Pause()
    //{
    //    Time.timeScale = 0;
    //    PausePanel.SetActive(true);
    //    PauseButton.SetActive(false);
    //}

    //public void Resume()
    //{
    //    Time.timeScale = 1;
    //    PausePanel.SetActive(false);
    //    PauseButton.SetActive(true);
    //}

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveData.instance.m_Count = (SceneManager.GetActiveScene().buildIndex + 1);
        SaveData.instance.SetCount();
        GPGS.instance.localScore = SaveData.instance.m_Count;
        GPGS.instance.AddScoreToLeaderboard();
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void AudioSettings()
    {
        if (SaveData.instance.SettingsCount == 0)
        {
            //SoundButton.GetComponent<Image>().sprite = AudioOff;
            //BGMusicAudioSource.Stop();
            SaveData.instance.SettingsCount = 1;
        }
        else
        {
            //SoundButton.GetComponent<Image>().sprite = AudioOn;
            //BGMusicAudioSource.Play();
            SaveData.instance.SettingsCount = 0;
        }
        SaveData.instance.SettingsCounter();
    }
}
