using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript2 : MonoBehaviour {

public GameObject TextBox;
public GameObject Choice1;
public GameObject Choice2;
public GameObject Choice3;
public GameObject Choice4;
public GameObject NextButton2;
public GameObject NextTutorial2;

// \n

private string[] tutorialText2 = new string[] {"The Process To Solve Inequalities Is The Same As The Process To Solve Equations, Which Uses Inverse Operations To Keep The Equation or Inequality Balanced."+"\n"+
                                            "Instead Of Using An Equals Sign, However, The Inequality Symbol Is Used Throughout.",

                                            "Use These Formulae And Notations To Help With Solving Inequalities:"+"\n"+
                                            "< Means 'Less Than'"+"\n"+
                                            "> Means 'Greater Than'"+"\n"+
                                            "<= Means 'Less Than Or Equal To'"+"\n"+
                                            ">= Means 'Greater Than Or Equal To'"+"\n",

                                            "For Example, Let's Work Out An Algebraic Inequality:"+"\n"+
                                            "9 + 7x >= 29 + 2x"+"\n"+
                                            "Subtract 2x From Both Sides| 5x + 9 >= 29"+"\n"+
                                            "Subtract 9 From Both Sides| 5x >= 20"+"\n"+
                                            "Divide Both Sides By 5| x >= 4",

                                            "Now Try Answering Some Questions!"};


private string[] questionPool = new string[] { "50 – 10y > 10"+"\n"+"Solve The Inequality",
                                            "8 – 5y > 43"+"\n"+"Solve The Inequality",
                                            "4x + 7 < 21"+"\n"+"Solve The Inequality",
                                            "2y + 8 < 3y"+"\n"+"Solve The Inequality",
                                            "x(8+2) + 10x <= 20"+"\n"+"Solve The Inequality"};

// int array used as it's being compared to int "ChoiceMade".
// ChoiceMade corresponds to buttons (ie button 1 = ChoiceMade = 1).
private int[] correctPosition = new int[] { 3, 4, 2, 1, 4};

private string[,] answerPool = new string[,] { { "y > 8", "y < 10", "y < 4", "y > 50" },
                                                { "y > 7", "y < 7/14", "y > 14", "y < -7" },
                                                { "x > 4", "x < 14/4", "x < 4/14", "x > 14/4" },
                                                { "y > 8", "2y < 8", "8 > -y", "3y < 8" },
                                                { "x = 1", "x >= 10", "x < 10", "x <= 1" } };


private string[] correctChoice = new string[] { "Great Work, Keep Going!", 
                                                "Well Done, You Made That Look Easy!",
                                                "Nice One! You're Doing Great!",
                                                "Nailed It! Don't Stop Now!",
                                                "You Got It Right! Awesome Work!" };

private string[] wrongChoice = new string[] { "So Close! Keep At It!",
                                              "Not Quite, Try Another One!",
                                              "You Nearly Got It! Don't Give Up!",
                                              "That Wasn't It, But Don't Stop Now!",
                                              "Not Quite, Maybe Read Through Your Notes Again!" };



private int ChoiceMade = 10;
private int tutorialMessage2 = 0;
private int questionNumber = 0;
private int totalQuestions = 0;
private int totalCorrect = 0;



public void NextTutorialText2() {
    if (tutorialMessage2 < 4) {
        if (tutorialMessage2 == 3) {
            NextTutorial2.GetComponentInChildren<Text>().text = "Start The Quizz!";
        }
    TextBox.GetComponent<Text>().text = tutorialText2[tutorialMessage2];
    ChoiceMade = 10;
    tutorialMessage2+=1;}

    else {NextQuestion2();}
}

public void ChoiceOption1() {
    //TextBox.GetComponent<Text>().text = "Great Work, Keep Going!";
    ChoiceMade = 1;
    CheckAnswer(ChoiceMade);
}

public void ChoiceOption2() {
    //TextBox.GetComponent<Text>().text = "So Close! Keep At It!";
    ChoiceMade = 2;
    CheckAnswer(ChoiceMade);
}

public void ChoiceOption3() {
    //TextBox.GetComponent<Text>().text = "Not Quite, Try Another One!";
    ChoiceMade = 3;
    CheckAnswer(ChoiceMade);
}

public void ChoiceOption4() {
    //TextBox.GetComponent<Text>().text = "You Nearly Got It! Don't Give Up!";
    ChoiceMade = 4;
    CheckAnswer(ChoiceMade);
}

public void CheckAnswer(int ChoiceMade) {
if (correctPosition[totalQuestions] == ChoiceMade){
    TextBox.GetComponent<Text>().text = correctChoice[totalQuestions];
    totalQuestions+=1;
    totalCorrect+=1;
}

else{
    TextBox.GetComponent<Text>().text = wrongChoice[totalQuestions];
    totalQuestions+=1;
}
}

public void NextQuestion2() {
    if (questionNumber <= 4) {
    TextBox.GetComponent<Text>().text = questionPool[questionNumber];

    Choice1.GetComponentInChildren<Text>().text = answerPool[questionNumber, 0];
    Choice2.GetComponentInChildren<Text>().text = answerPool[questionNumber, 1];
    Choice3.GetComponentInChildren<Text>().text = answerPool[questionNumber, 2];
    Choice4.GetComponentInChildren<Text>().text = answerPool[questionNumber, 3];
    
    ChoiceMade = 7;
    questionNumber+=1;
    }

    else {
        TextBox.GetComponent<Text>().text = "End Of Quiz! Well Done!"+"\n"
        +"Your Score Is "+totalCorrect+" Out Of 5!";
        ChoiceMade = 5;
        //Set Up New Button For Quit Command OR RETRY TEST IF MARK LOWER THAN FOUR
    }
}



void FixedUpdate() {
    if (ChoiceMade == 10) {
        Choice1.SetActive (false);
        Choice2.SetActive (false);
        Choice3.SetActive (false);
        Choice4.SetActive (false);
        NextButton2.SetActive (false);
        NextTutorial2.SetActive (true);
    }


    if (ChoiceMade >= 1 && ChoiceMade < 7) {
        Choice1.SetActive (false);
        Choice2.SetActive (false);
        Choice3.SetActive (false);
        Choice4.SetActive (false);
        NextTutorial2.SetActive (false);
        NextButton2.SetActive (true);

        if (ChoiceMade == 5)
        {NextButton2.SetActive(false);}
    }
    
    if (ChoiceMade == 7 || ChoiceMade == 9) {
        Choice1.SetActive (true);
        Choice2.SetActive (true);
        Choice3.SetActive (true);
        Choice4.SetActive (true);
        NextButton2.SetActive (false);
        NextTutorial2.SetActive (false);
    }

    if(Input.GetKeyDown("space")){
    TextBox.GetComponent<Text>().text = "Hey! This Is A Short Introduction To Solving Inequalities!"+"\n"
    + "To Get Started, Click The \"Next\" Button Below!";
    NextTutorial2.GetComponentInChildren<Text>().text = "Next";
    ChoiceMade = 10;
    tutorialMessage2 = 0;
    questionNumber = 0;
    totalQuestions = 0;
    totalCorrect = 0;}
}

}