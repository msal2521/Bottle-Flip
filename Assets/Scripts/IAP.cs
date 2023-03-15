using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAP : MonoBehaviour
{
    [SerializeField] private GameObject iapButton;

    //private GPGS _gpgs;
    private void Start()
    {
        //_gpgs = GameObject.Find("GPGS").GetComponent<GPGS>();
        CheckStatus();
    }

    public void PurchaseComplete(Product product)
    {
        PlayerPrefs.SetString("addFree",true.ToString());
        //_gpgs.UnlockAchievement();
        CheckStatus();
    }

    public void CheckStatus()
    {
        if (PlayerPrefs.HasKey("addFree"))
            iapButton.SetActive(false);
    }
}
