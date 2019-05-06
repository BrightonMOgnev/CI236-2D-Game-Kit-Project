using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour {

public GameObject TextBox;
public GameObject Choice1;
public GameObject Choice2;
public GameObject Choice3;
public GameObject Choice4;
public GameObject NextButton;
private int ChoiceMade;

// \n

private string[] questionPool = new string[] { "y=2+8"+"\n"+"Find \"y\"",
                                              "x=2x-4"+"\n"+"Find \"x\"",
                                              "y=6y-5"+"\n"+"Find \"y\"",
                                             "2x=5x-3"+"\n"+"Find \"x\""};

private string[] correctPool = new string[] { "10",
                                                "4",
                                                "1",
                                                "1" };

private string[,] answerPool = new string[,] { { "10", "2", "3", "4", "5", "6" },
                                                  { "4", "8", "9", "10", "11", "12" },
                                                  { "1", "13", "14", "15", "16", "17" },
                                                  { "1", "18", "19", "20", "21", "22" } };


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



private int questionNumber = 0;



public void ChoiceOption1() {
    TextBox.GetComponent<Text>().text = "Great Work, Keep Going!";
    ChoiceMade = 1;
}

public void ChoiceOption2() {
    TextBox.GetComponent<Text>().text = "So Close! Keep At It!";
    ChoiceMade = 2;
}

public void ChoiceOption3() {
    TextBox.GetComponent<Text>().text = "Not Quite, Try Another One!";
    ChoiceMade = 3;
}

public void ChoiceOption4() {
    TextBox.GetComponent<Text>().text = "You Nearly Got It! Don't Give Up!";
    ChoiceMade = 4;
}

public void CheckAnswer(int ChoiceMade) {

if (ChoiceMade == 1) {}

}

public void NextQuestion() {
    if (questionNumber <= 3) {
    TextBox.GetComponent<Text>().text = questionPool[questionNumber];

    Choice1.GetComponentInChildren<Text>().text = answerPool[questionNumber, 0];
    Choice2.GetComponentInChildren<Text>().text = answerPool[questionNumber, 1];
    Choice3.GetComponentInChildren<Text>().text = answerPool[questionNumber, 2];
    Choice4.GetComponentInChildren<Text>().text = answerPool[questionNumber, 3];
    
    ChoiceMade = 7;
    questionNumber+=1;
    }
    else {
        TextBox.GetComponent<Text>().text = "End Of Quiz! Well Done!";
            ChoiceMade = 5;
        //Set Up New Button For Quit Command OR RETRY TEST IF MARK LOWER THAN FOUR
    }
}

private static int[] uniqueRandomNumbers(int min, int max, int howMany)
    {
        int[] myNumbers = new int[howMany];

        // actual generation of random numbers
        System.Random randNum = new System.Random();
        for (int currIndex = 0; currIndex < howMany; currIndex++)
        {
            // generate a candidate
            int randCandidate = randNum.Next(min, max);
 
            // generate a new candidate as long as we don't get one that isn't in the array
            while (myNumbers.Contains(randCandidate))
            {
                randCandidate = randNum.Next(min, max);
            }
 
            myNumbers[currIndex] = randCandidate;
        }
 
        return myNumbers;
    }

void Update() {
    if (ChoiceMade >= 1 && ChoiceMade < 7) {
        Choice1.SetActive (false);
        Choice2.SetActive (false);
        Choice3.SetActive (false);
        Choice4.SetActive (false);
        NextButton.SetActive (true);
        if (ChoiceMade == 5) {
            NextButton.SetActive(false);}
    }
    
    if (ChoiceMade == 7) {
        Choice1.SetActive (true);
        Choice2.SetActive (true);
        Choice3.SetActive (true);
        Choice4.SetActive (true);
        NextButton.SetActive (false);
    }
}

}