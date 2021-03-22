using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class checks the solution and the characters in the slider
 
     
     
     */


public class DigitDisplay : MonoBehaviour
{
    public enum Difficulty
    {
        EASY,
        NORMAL,
        HARD
    }

    [SerializeField] public Difficulty difficulty;

    [SerializeField] private Text tempCode;
    public int maxDigitCount { get; set; }

    public Text displayCode { get; set; }

    int counter;
    public bool success { get; set; }

    public string codeSolution { get; set; }

    public string codeSolutionEntered { get; set; }

    private string solutionChars = "0123456789";

    [SerializeField]
    public GameObject door;

    private void OnEnable()
    {
        ResetLock();
    }

    private void OnDisable()
    {
        DestroyTextObjects();
    }

    private void Start()
    {
        PressButton.ButtonPressed += EnterCode;
    }

    public void ResetLock()
    {
        if (difficulty == Difficulty.EASY)
            maxDigitCount = 3;
        else if (difficulty == Difficulty.NORMAL)
            maxDigitCount = 4;
        if (difficulty == Difficulty.HARD)
            maxDigitCount = 5;

        counter = 0;
        codeSolution = "";
        codeSolutionEntered = "";

        for (int i = 0; i < maxDigitCount; i++)
        {
            CreateCodeSolution();

            CreateTextObject();

            DebugSolution(codeSolution);

        }
    }


    private void CreateCodeSolution()
    {
        codeSolution += solutionChars[UnityEngine.Random.Range(0, solutionChars.Length)];        
    }

    private void EnterCode(string digitEntered)
    {
        switch (digitEntered)
        {
            case "Zero":
                //GenerateText(0);
                AddCharacterToSolutionCheck(0);
                break;
            case "One":
                //GenerateText(1);
                AddCharacterToSolutionCheck(1);
                break;
            case "Two":
                //GenerateText(2);
                AddCharacterToSolutionCheck(2);
                break;
            case "Three":
                //GenerateText(3);
                AddCharacterToSolutionCheck(3);
                break;
            case "Four":
                //GenerateText(4);
                AddCharacterToSolutionCheck(4);
                break;
            case "Five":
                //GenerateText(5);
                AddCharacterToSolutionCheck(5);
                break;
            case "Six":
                //GenerateText(6);
                AddCharacterToSolutionCheck(6);
                break;
            case "Seven":
                //GenerateText(7);
                AddCharacterToSolutionCheck(7);
                break;
            case "Eight":
                //GenerateText(8);
                AddCharacterToSolutionCheck(8);
                break;
            case "Nine":
                //GenerateText(9);
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

/*    public void CheckSolutionForReset()
    {
        if (codeSolution.Length == codeSolutionEntered.Length)
            CheckResults();
    }*/

   /* private void GenerateText(int digitEntered) //counter to limit instances
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
       
    }*/

    private void DebugSolution(string codeSolution)
    {
        Debug.Log("Solution " + codeSolution);
    }

    /*private void AddCharacter(int digitEntered) //create child object with text of one character
    {
        var textChildren = gameObject.transform.GetChild(counter);
        displayCode = textChildren.GetComponent<Text>();

        digitEntered.ToString("");

        if (displayCode.text.Length < 1)
            displayCode.text += digitEntered;
        counter++;
    }*/

    private void CreateTextObject()
    {
        Text tempDisplayCode = displayCode;

        tempDisplayCode = Instantiate(tempCode, transform.position, Quaternion.identity) as Text;

        tempDisplayCode.transform.SetParent(GameObject.Find("Screen").transform, false);

        tempDisplayCode.GetComponentInChildren<Text>();

        /*displayCode = Instantiate(tempCode, transform.position, Quaternion.identity) as Text;

        displayCode.transform.SetParent(GameObject.Find("Screen").transform, false);

        displayCode.GetComponentInChildren<Text>();*/
    }


    private void DestroyTextObjects()
    {
        for (int j = 0; j < transform.childCount; j++)
        {
            var textChildren = gameObject.transform.GetChild(j).gameObject;
            //displayCode = textChildren.GetComponent<Text>();
            Destroy(textChildren);
        }
    }
    

    private void CheckResults()
    {
        if (codeSolution.Contains(codeSolutionEntered))
        {
            success = true;
            //Debug.Log("Success");
            door.GetComponent<DoorManager>().state = DoorManager.State.open;
            ResetDisplay();
            //ResetLock();
            //Open Door
        }
        else
        {
            door.GetComponent<DoorManager>().codeExpired = true;
            //Debug.Log("Fail");
            success = false;
            ResetDisplay();
            //DebugSolution(codeSolution);
            //Reset
            //Attempts==
            //Maybe Create new Solution
        }
    }

    private void ResetDisplay()
    {
        for (int i = 0; i < maxDigitCount; i++)
        {
            codeSolutionEntered = "";
            for (int j = 0; j < transform.childCount; j++)
            {
                var textChildren = gameObject.transform.GetChild(j).gameObject;
                //displayCode = textChildren.GetComponent<Text>();
                textChildren.GetComponent<Text>().text = "";
                //displayCode.text = "";
            }
            counter = 0;
        }
    }

    private void OnDestroy()
    {
        PressButton.ButtonPressed -= EnterCode;
    }
}
