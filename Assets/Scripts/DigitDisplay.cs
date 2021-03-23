using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This class creates the solution and checks it
 * also displays the characters solution from the slider
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
                AddCharacterToSolutionCheck(0);
                break;
            case "One":
                AddCharacterToSolutionCheck(1);
                break;
            case "Two":
                AddCharacterToSolutionCheck(2);
                break;
            case "Three":
                AddCharacterToSolutionCheck(3);
                break;
            case "Four":
                AddCharacterToSolutionCheck(4);
                break;
            case "Five":
                AddCharacterToSolutionCheck(5);
                break;
            case "Six":
                AddCharacterToSolutionCheck(6);
                break;
            case "Seven":
                AddCharacterToSolutionCheck(7);
                break;
            case "Eight":
                AddCharacterToSolutionCheck(8);
                break;
            case "Nine":
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

    private void DebugSolution(string codeSolution)
    {
        Debug.Log("Solution " + codeSolution);
    }

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
