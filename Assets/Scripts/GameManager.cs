using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour,ITakeCoin
{
    public static GameManager Instance { get; private set; }
    public float coin = 0;
    public string KEY_COIN = "Coin";
    private void Awake()
    {
        if (Instance == null)Instance = this;
        else Destroy(gameObject);
        coin = PlayerPrefs.GetFloat(KEY_COIN,0);
    }
 
    public void AddCoin(float coin)
    {
        this.coin += coin;
    }

    public void RemoveCoin(float coin)
    {
        this.coin -= coin;
    }
    public void SaveGame()
    {
        PlayerPrefs.SetFloat(KEY_COIN, coin);
    }
}
