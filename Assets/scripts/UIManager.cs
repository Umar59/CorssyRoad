
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _controller;
    

   
    
    public Text currentScore;
    public Text record;
    public Text balance;
    public GameObject gameOverUI;
    
    

    private void Update()
    {
        balance.text = _controller.balance.ToString();
        record.text = _controller.record.ToString();
        currentScore.text = _controller.score.ToString();

        if (!GameManager.GameState)
        {
            GameOverUI();
        }
    }

    private void GameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    public void StartGameUI()
    {
        GameManager.GameState = true;
        SceneManager.LoadScene("Main");
    }
}
