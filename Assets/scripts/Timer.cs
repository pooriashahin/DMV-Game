using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countUp;

    [Header("Questions Score")]
    public TextMeshProUGUI questionsScore;
    public int amountCorrect = 0;
    public int amountQuestions = 0;

    private bool happened = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if(amountQuestions <=20 && happened){
            currentTime = countUp ? currentTime += Time.deltaTime : currentTime -= Time.deltaTime;
            timerText.text = currentTime.ToString("0.00");
            if (amountQuestions > 0) {
                questionsScore.text = amountCorrect + "/" + amountQuestions + "   (" + (amountCorrect * 100 / amountQuestions) + "%)   ";
            } else {
                questionsScore.text = "0%";
            }
            if(amountQuestions==20)
                happened = false;
        }
    }
}
