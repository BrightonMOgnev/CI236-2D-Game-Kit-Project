using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript1 : MonoBehaviour {

public GameObject TextBox;
public GameObject Choice1;
public GameObject Choice2;
public GameObject Choice3;
public GameObject Choice4;
public GameObject NextButton1;
public GameObject NextTutorial1;

// \n

private string[] tutorialText1 = new string[] {"Algebra Is Used In Maths When We Do Not Know The Exact Number(s) In A Calculation."+"\n"+
                                            "In Algebra Letters Are Used To Represent Unknown Values Or Values That Can Change."+"\n"+
                                            "Unknown Values Are Commonly Represented By The Letters x and y.",

                                            "Simultaneous Equations Can Be Solved With The Help Of These Formulae:"+"\n"+
                                            "ab = a × b"+"\n"+
                                            "a² = a × a"+"\n"+
                                            "a²b = a × a × b"+"\n"+
                                            "a(a + b) = (a x a) + (a x b)"+"\n",

                                            "For Example, Let's Go Through A Simultaneous Equation:"+"\n"+
                                            "4(2y - 3) = 3(y + 6)"+"\n"+
                                            "Expand Brackets| 8y - 12 = 3y + 18"+"\n"+
                                            "Minus 3y From Both Sides| 8y -12 – 3y = 18"+"\n"+
                                            "Add 12 To Both Sides| 8y – 3y = 18 + 12"+"\n"+
                                            "Collect Like Terms| 5y = 30"+"\n"+
                                            "Divide Both Sides by 5| y = 6",

                                            "Now Try Answering Some Questions!"};


private string[] questionPool = new string[] { "7x – 7 = 15"+"\n"+"Solve The Simultaneous Equation",
                                            "9x – 6 + 20 = 5x"+"\n"+"Solve the Simultaneous Equation",
                                            "4x – 5 = 1/3"+"\n"+"Solve the Simultaneous Equation",
                                            "x + 12 = 7x"+"\n"+"Solve the Simultaneous Equation",
                                            "10 + 2x = 5x"+"\n"+"Solve the Simultaneous Equation"};

// int array used as it's being compared to int "ChoiceMade".
// ChoiceMade corresponds to buttons (ie button 1 = ChoiceMade = 1).
private int[] correctPosition = new int[] { 3, 4, 2, 1, 4};

private string[,] answerPool = new string[,] { { "x > 4", "x = 10", "x = 3.14", "x = 7" },
                                                { "x = 4", "x = 20", "x = 6", "x = 1" },
                                                { "x = 5/12", "x = 4/3", "x = 7/6", "x = 15/3" },
                                                { "x = 1/2", "x = 1/3", "x = 4/3", "x = 1" },
                                                { "x = 10/7", "x = 7/10", "x = 1/3", "x = 10/3" } };


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
private int tutorialMessage1 = 0;
private int questionNumber = 0;
private int totalQuestions = 0;
private int totalCorrect = 0;



public void NextTutorialText1() {
    if (tutorialMessage1 < 4) {
        if (tutorialMessage1 == 3) {
            NextTutorial1.GetComponentInChildren<Text>().text = "Start The Quizz!";
        }
    TextBox.GetComponent<Text>().text = tutorialText1[tutorialMessage1];
    ChoiceMade = 10;
    tutorialMessage1+=1;}

    else {NextQuestion1();}
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

public void NextQuestion1() {
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
        NextButton1.SetActive (false);
        NextTutorial1.SetActive (true);
    }


    if (ChoiceMade >= 1 && ChoiceMade < 7) {
        Choice1.SetActive (false);
        Choice2.SetActive (false);
        Choice3.SetActive (false);
        Choice4.SetActive (false);
        NextTutorial1.SetActive (false);
        NextButton1.SetActive (true);

        if (ChoiceMade == 5)
        {NextButton1.SetActive(false);}
    }
    
    if (ChoiceMade == 7 || ChoiceMade == 9) {
        Choice1.SetActive (true);
        Choice2.SetActive (true);
        Choice3.SetActive (true);
        Choice4.SetActive (true);
        NextButton1.SetActive (false);
        NextTutorial1.SetActive (false);
    }

    if(Input.GetKeyDown("space")){
    TextBox.GetComponent<Text>().text = "Hey! This Is A Short Introduction To Simultaneous Equations!"+"\n"
    + "To Get Started, Click The \"Next\" Button Below!";
    NextTutorial1.GetComponentInChildren<Text>().text = "Next";
    ChoiceMade = 10;
    tutorialMessage1 = 0;
    questionNumber = 0;
    totalQuestions = 0;
    totalCorrect = 0;}
}

}