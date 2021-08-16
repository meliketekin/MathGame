using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalManager : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void backToHome()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
