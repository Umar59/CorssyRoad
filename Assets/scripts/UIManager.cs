
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager _controller;
    
    
    public Text record;
    public GameObject gameOverUI;
    private float _state = 0;
    public Image transitionImg;
    public GameObject transition;
    
    public void SoundControll(/*bool isSoundOn*/)
    {
       AudioListener.volume = _state;
        if (_state == 0)
        {
            _state = 1;
          
        }
        else
        {
            Debug.Log("выкл");
            
        }
       

    }


    private void Update()
    {
        record.text = _controller.record.ToString();

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
        transition.SetActive(true);
       
        Transition(100);
        SceneManager.LoadScene("Main");
        GameManager.GameState = true;
        Transition(0);
        transition.SetActive(false);

    }

    public void Transition(float fadeTo)
    {
        transitionImg.DOFade(fadeTo, 5);
        StartCoroutine(sait());
        
    }

    IEnumerator sait()
    {

        yield return new WaitForSeconds(5);
    }
}
