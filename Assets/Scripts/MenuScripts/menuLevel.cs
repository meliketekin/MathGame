using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class menuLevel : MonoBehaviour
{
[SerializeField]
private GameObject startButton, exitButton;
    
    void Start()
    {
        fadeOut();
    }

    public void fadeOut() {
        startButton.GetComponent<CanvasGroup>().DOFade(1,0.8f);
        exitButton.GetComponent<CanvasGroup>().DOFade(1,0.8f).SetDelay(0.5f);
    }

    public void startGame() {
        SceneManager.LoadScene("GameScene");
    }

    public void exitGame() {
        Application.Quit();
    }
}
