using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Transform squarePanel;

     [SerializeField]
    private GameObject squarePrefab;

    [SerializeField]
    private Transform questionPanel;

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Sprite[] toySprites;

    [SerializeField]
    private GameObject finalPanel;

    [SerializeField]
    private AudioSource audioSource;
    public AudioClip audioClip;

    private GameObject[] squareArray = new GameObject[24];
    List<int> quotientList = new List<int>();
    int dividend,divider;
    int questionNo;
    bool buttonCheck;
    int remainingChance;

    int quotientButtonValue;
    ChanceManager chanceManager;
    pointManager pointManager;
    string difficulty;
    GameObject currentSquare;

    void Awake()
    {
        audioSource.GetComponent<AudioSource>();
        remainingChance = 3;
        chanceManager = Object.FindObjectOfType<ChanceManager>();
        chanceManager.ManageRemainingChances(remainingChance);
        pointManager = Object.FindObjectOfType<pointManager>();
    }
    void Start()
    {
        buttonCheck=false;
        questionPanel.GetComponent<RectTransform>().localScale = new Vector3(0,0);
        finalPanel.GetComponent<RectTransform>().localScale = new Vector3(0, 0);
        copySquares();
         printValues();
        StartCoroutine(DoFadeRoutine());
        Invoke("printQuestion",2.5f);
        
        
    }

    public void copySquares() {
        for (int i = 0; i < 24; i++)
        {
            GameObject square = Instantiate(squarePrefab, squarePanel);
            square.transform.GetChild(1).GetComponent<Image>().sprite = toySprites[Random.Range(0, toySprites.Length)];
            square.transform.GetComponent<Button>().onClick.AddListener(()=>QuotientButtonClick());
            squareArray[i] = square;
        
        }
    }

    IEnumerator DoFadeRoutine()  {
        foreach (var square in squareArray)
        {
            square.GetComponent<CanvasGroup>().DOFade(1,0.5f);
             yield return new WaitForSeconds(0.1f);
        }
    }

    void printValues() {
        foreach(var square in squareArray) {
            int randomQuotientValue = Random.Range(1,25);
            square.transform.GetChild(0).GetComponent<Text>().text = randomQuotientValue.ToString();
            quotientList.Add(randomQuotientValue);
        }
    }

    void printQuestion() {
        askQuestion();
        questionPanel.GetComponent<RectTransform>().DOScale(1,0.5f);
    }

    void askQuestion() {
        divider = Random.Range(2,11);
        questionNo = Random.Range(0, quotientList.Count);
        dividend = divider*quotientList[questionNo];
        questionText.text = dividend.ToString() + " : " + divider.ToString();
        buttonCheck = true;
        if ( dividend < 40 )
        {
            difficulty = "easy";
        }
        if (40<=dividend && dividend<90) {
            difficulty = "medium";
        }
        if (dividend > 89)
        {
            difficulty = "hard";
        }
    }

    void QuotientButtonClick() {
        if(buttonCheck) {
            audioSource.PlayOneShot(audioClip);
           quotientButtonValue = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>().text);
            currentSquare = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Debug.Log(quotientButtonValue); 
        checkResult();
        }
        
    }
    void checkResult(){
        if (quotientButtonValue == (dividend / divider))
        {
            currentSquare.transform.GetChild(1).GetComponent<Image>().enabled = true;
            currentSquare.transform.GetChild(0).GetComponent<Text>().text = "";
            currentSquare.transform.GetComponent<Button>().interactable = false;
            pointManager.managePointIncrease(difficulty);
            quotientList.RemoveAt(questionNo);
            if(quotientList.Count<=0)
            {
                gameOver();
            }
            else
            printQuestion();
        }
            
        else
        {
            remainingChance--;
            chanceManager.ManageRemainingChances(remainingChance);
            if(remainingChance<=0)
            {
                gameOver();
            }
        }
    }
    void gameOver()
    {
        finalPanel.GetComponent<RectTransform>().DOScale(1, 0.5f);
        buttonCheck = false;
    }
   
}
