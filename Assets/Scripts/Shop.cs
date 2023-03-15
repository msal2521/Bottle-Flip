using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public enum Skins
    {
        Skin_1,
        Skin_2,
        Skin_3,
        Skin_4,
        Skin_5,
        Skin_6,
        Skin_7,
    }

    public Skins CurrentSkin;

    public List<GameObject> items;
    public int m_Skin;

    private void Start()
    {
        GetSkin();
        items[m_Skin].SetActive(true);
        CurrentSkin = (Skins)m_Skin;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    NextItem();
        //}

        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    PreviousItem();
        //}
    }


    public void NextItem()
    {
        items[m_Skin].SetActive(false);
        m_Skin++;
        if (m_Skin >= items.Count)
        {
            m_Skin = 0;
        }
        items[m_Skin].SetActive(true);
        CurrentSkin = (Skins)m_Skin;
    }

    public void PreviousItem()
    {
        items[m_Skin].SetActive(false);
        m_Skin--;
        if (m_Skin < 0)
        {
            m_Skin = items.Count - 1;
        }
        items[m_Skin].SetActive(true);
        CurrentSkin = (Skins)m_Skin;
    }

    public void SetSkin()
    {
        PlayerPrefs.SetInt("Skin", m_Skin);
    }

    public void GetSkin()
    {
        m_Skin = PlayerPrefs.GetInt("Skin");
    }

    private void OnDisable()
    {
        SetSkin();
    }
}