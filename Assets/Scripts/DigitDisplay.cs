using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitDisplay : MonoBehaviour
{
    public enum Difficulty
    {
        EASY,
        NORMAL,
        HARD
    }

    [SerializeField] private Difficulty difficulty;

    [SerializeField] private Text tempCode;
    private int maxDigitCount;
    private Text displayCode;
    int counter = 0;
    private string codeSolution = "";
    private string codeSolutionEntered = "";
    private string solutionChars = "0123456789";



    //List<Text> displayCode = new List<Text>();
    /*    List<int> prev = new List<int>();
        List<int> next = new List<int>();*/

    //private int currentDigitCount = 0;

    private void Start()
    {
        if (difficulty == Difficulty.EASY)
            maxDigitCount = 3;
        else if (difficulty == Difficulty.NORMAL)
            maxDigitCount = 4;
        if (difficulty == Difficulty.HARD)
            maxDigitCount = 5;

        //index = maxDigitCount;

        //displayCode = new Text[maxDigitCount];

        for (int i = 0; i < maxDigitCount; i++)
        {
            codeSolution += solutionChars[UnityEngine.Random.Range(0, solutionChars.Length)];

            CreateTextObject();

            CreateCodeSolution(codeSolution);

        }


        PressButton.ButtonPressed += EnterCode;
    }

    /*    private void AddDigitToCode(string digitEntered)
        {

            if (currentDigitCount < maxDigitCount)
            {
                EnterCode(digitEntered);
                currentDigitCount++;
            }

            //Reset/cancel last character
        }*/

    private void EnterCode(string digitEntered)
    {
        switch (digitEntered)
        {
            case "Zero":
                GenerateText(0);
                AddCharacterToSolutionCheck(0);
                break;
            case "One":
                GenerateText(1);
                AddCharacterToSolutionCheck(1);
                break;
            case "Two":
                GenerateText(2);
                AddCharacterToSolutionCheck(2);
                break;
            case "Three":
                GenerateText(3);
                AddCharacterToSolutionCheck(3);
                break;
            case "Four":
                GenerateText(4);
                AddCharacterToSolutionCheck(4);
                break;
            case "Five":
                GenerateText(5);
                AddCharacterToSolutionCheck(5);
                break;
            case "Six":
                GenerateText(6);
                AddCharacterToSolutionCheck(6);
                break;
            case "Seven":
                GenerateText(7);
                AddCharacterToSolutionCheck(7);
                break;
            case "Eight":
                GenerateText(8);
                AddCharacterToSolutionCheck(8);
                break;
            case "Nine":
                GenerateText(9);
                AddCharacterToSolutionCheck(9);
                break;
        }

        
    }

    private void AddCharacterToSolutionCheck(int digitEntered)
    {
        if (codeSolutionEntered.Length < maxDigitCount)
            codeSolutionEntered += digitEntered;

        if(codeSolution.Length == codeSolutionEntered.Length)
            CheckResults();
        

    }

    private void GenerateText(int digitEntered)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (counter < maxDigitCount)
            {
                if (counter == 0)
                {
                    AddCharacter(digitEntered);
                    break;
                }
                else if (counter == 1)
                {
                    AddCharacter(digitEntered);
                    break;
                }
                else if (counter == 2)
                {
                    AddCharacter(digitEntered);
                    break;
                }
                else if (counter == 3)
                {
                    AddCharacter(digitEntered);
                    break;
                }
                else if (counter == 4)
                {
                    AddCharacter(digitEntered);
                    break;
                }
            }
        }

        //then convert int to char/string ?
       
    }

    private void CreateCodeSolution(string codeSolution)
    {
        Debug.Log("Solution " + codeSolution);

/*        for (int i = 0; i < transform.childCount; i++)
        {
            if()
        }*/
    }

    private void AddCharacter(int digitEntered)
    {
        var textChildren = gameObject.transform.GetChild(counter);
        displayCode = textChildren.GetComponent<Text>();
        displayCode.text += digitEntered;
        counter++;
    }

    private void CreateTextObject()
    {
        displayCode = Instantiate(tempCode, transform.position, Quaternion.identity) as Text;

        displayCode.transform.SetParent(GameObject.Find("Screen").transform, false);

        displayCode.GetComponentInChildren<Text>();
    }

    private void CheckResults()
    {
        if (codeSolution.Contains(codeSolutionEntered))
            Debug.Log("Success");
        else
            Debug.Log("Fail");

        //reset display if wrong
        //attempts --
    }

    private void ResetDisplay()
    {
        /*for (int i = 0; i < displayCode.text.Length; i++)
        {
            displayCode.text = "";
        }*/
    }

    private void OnDestroy()
    {
        PressButton.ButtonPressed -= EnterCode;
    }
}
