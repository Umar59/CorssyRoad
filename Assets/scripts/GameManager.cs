using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    
    public int score;

    public int record;

    public int balance;

    public static bool GameState = true;
    
    public Text scoreUI;
    public Text coinsCount;
    private void Start()
    {
        playerMovement.onAddMoney += AddMoney;
        playerMovement.onAddScore += AddScore;
        playerMovement.gameOver += GameOver;
        GetData();
    }


    public void SetData()
    {
        PlayerPrefs.SetInt("Record", record);
        PlayerPrefs.SetInt("Balance", balance);
        coinsCount.text = balance.ToString();
    }

    public void GetData()
    {
        record = PlayerPrefs.GetInt("Record");
        balance = PlayerPrefs.GetInt("Balance");
        coinsCount.text = balance.ToString();
    }

    private void AddMoney(int money)
    {
        balance += money;
        SetData();

    }

    private void AddScore(int score)
    {
        this.score = ++score;
        UpdateRecord();
        scoreUI.text = score.ToString();
    }

    private void UpdateRecord()
    {
        if (score >= record)
        {
            record = score;
        }
    }

    private void GameOver()
    {
        GameState = false;

        SetData();
    }

}