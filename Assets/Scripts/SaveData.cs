using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public int m_Count, SettingsCount;
    public static SaveData instance;

    private void Awake()
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
    }

    // Start is called before the first frame update
    void Start()
    {
        GetSettingsCounter();
        GetCount();
    }

    private void Update()
    {
        
    }

    public void SetCount()
    {
        PlayerPrefs.SetInt("Count", m_Count);
        PlayerPrefs.Save();
        Debug.Log(m_Count);
    }

    public void GetCount()
    {
        m_Count = PlayerPrefs.GetInt("Count");
    }

    public void SettingsCounter()
    {
        PlayerPrefs.SetInt("SettingsCount", SettingsCount);
        PlayerPrefs.Save();
        Debug.Log(SettingsCount);
    }

    public void GetSettingsCounter()
    {
        SettingsCount = PlayerPrefs.GetInt("SettingsCount");
    }
}
