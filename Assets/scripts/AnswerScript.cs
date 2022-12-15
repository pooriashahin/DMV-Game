using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Color;
 
 
public class AnswerScript : MonoBehaviour
{
    public bool isCorrect;
    public QuizManager quizManager;
    public GameObject Panel;
    public GameObject ExplainationPanel;
    public GameObject Car;
    public GameObject GearsCanvas;
    public Timer Score;
    public GameObject ScoreBoard;
    [SerializeField] int numQuestionsInARow =4;
    [SerializeField] float waitTimeInSeconds=5;
    [SerializeField] bool removeQuestions = true;

    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
 
   public void Answer(){

        if(isCorrect){
            Score.amountCorrect++;
        }
        else{
        }

            Score.amountQuestions++;

            changeButtonsColor();
            turnButtonsOff();
            StartCoroutine(waiter(waitTimeInSeconds));
            // quizManager.correct();
            // changeButtonsColorBack();
            // turnButtonsOn();

            // if(Score.amountQuestions%4==0){
            //     removePanel();
            //     returnCar();
            //     if(Score.amountQuestions==20){
            //         ScoreBoard.SetActive(true);
            //         removeCar();
            //     }
            //     else
            //         returnGear();
            // }
   }

   public void returnCar(){
       if(Car!= null){
           //bool isActive = Car.activeSelf;
           Car.SetActive(true);//Car.SetActive(!isActive)
       }
   }
      public void removeCar(){
       if(Car!= null){
           //bool isActive = Car.activeSelf;
           Car.SetActive(false);//Car.SetActive(!isActive)
       }
   }
   public void removePanel(){ //turns panel off/on
       if(Panel!= null){
           //bool isActive = Panel.activeSelf;
           Panel.SetActive(false);
       }
   }
   public void returnGear(){
       if(GearsCanvas!= null){
           //bool isActive = GearsCanvas.activeSelf;
           GearsCanvas.SetActive(true);
       }
 
    }
    public void turnButtonsOff(){
        button1.enabled = false;
        button2.enabled = false;
        button3.enabled = false;
        button4.enabled = false;
    }

    public void turnButtonsOn(){
        button1.enabled = true;
        button2.enabled = true;
        button3.enabled = true;
        button4.enabled = true;
    }
    public void changeButtonsColor(){


        Color red = Color.red;
        Color green = Color.green;

        if(button1.GetComponent<AnswerScript>().isCorrect){
            button1.GetComponent<Image>().color = Color.green;
            button2.GetComponent<Image>().color = Color.red;
            button3.GetComponent<Image>().color = Color.red;
            button4.GetComponent<Image>().color = Color.red;
        }else if(button2.GetComponent<AnswerScript>().isCorrect){
            button1.GetComponent<Image>().color = Color.red;
            button2.GetComponent<Image>().color = Color.green;
            button3.GetComponent<Image>().color = Color.red;
            button4.GetComponent<Image>().color = Color.red;
        }else if(button3.GetComponent<AnswerScript>().isCorrect){
            button1.GetComponent<Image>().color = Color.red;
            button2.GetComponent<Image>().color = Color.red;
            button3.GetComponent<Image>().color = Color.green;
            button4.GetComponent<Image>().color = Color.red;
        }else{
            button1.GetComponent<Image>().color = Color.red;
            button2.GetComponent<Image>().color = Color.red;
            button3.GetComponent<Image>().color = Color.red;
            button4.GetComponent<Image>().color = Color.green;
        }
    
    }
    public void changeButtonsColorBack(){
        Color normal = new Color(255,255,255,255);

        button1.GetComponent<Image>().color = normal;
        button2.GetComponent<Image>().color = normal;
        button3.GetComponent<Image>().color = normal;
        button4.GetComponent<Image>().color = normal;

    }
    
    IEnumerator waiter(float waitTime) {
        ExplainationPanel.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        quizManager.correct(removeQuestions);
        ExplainationPanel.SetActive(false);
        changeButtonsColorBack();
        turnButtonsOn();

        if(Score.amountQuestions%numQuestionsInARow==0){
            removePanel();
            returnCar();
            // if(Score.amountQuestions==20){
            //     ScoreBoard.SetActive(true);
            //     removeCar();
            // }
            // else
                returnGear();
        }
    
    }
}

