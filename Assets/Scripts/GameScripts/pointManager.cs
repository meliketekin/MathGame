using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointManager : MonoBehaviour
{
    [SerializeField]
    private Text pointText;
    private int point;
    private int pointIncrease;
    void Start()
    {
        pointText.text = point.ToString();
    }

    public void managePointIncrease(string difficulty)
    {
        if (difficulty == "easy")
        {
            pointIncrease = 5;
        }
       else if (difficulty == "medium")
        {
            pointIncrease = 10;
        }
        else if (difficulty == "hard")
        {
            pointIncrease = 15;
        }
        point += pointIncrease;
        pointText.text = point.ToString();
    }
}
