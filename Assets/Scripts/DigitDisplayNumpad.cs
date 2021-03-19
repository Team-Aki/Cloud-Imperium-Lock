using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitDisplayNumpad : MonoBehaviour
{
    [SerializeField] private Text tempCode;

    private int maxDigits;

    private Text displayCode;

    int counter;

    private string codeSolution;

    private string codeSolutionEntered;

    private DigitDisplay code;

    private void Awake()
    {
        code = GameObject.Find("Screen").GetComponent<DigitDisplay>();
    }

    private void Start()
    {

        maxDigits = code.maxDigitCount;

        counter = 0;
        codeSolution = code.codeSolution;
        codeSolutionEntered = code.codeSolutionEntered;

        for (int i = 0; i < maxDigits; i++)
        {
            CreateTextObject();
        }

        PressButton.ButtonPressed += EnterCode;
    }

    private void Update()
    {
       
    }

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
        if (codeSolutionEntered.Length < maxDigits)
            codeSolutionEntered += digitEntered;

        if (codeSolution.Length == codeSolutionEntered.Length)
            CheckResults();
    }

    private void GenerateText(int digitEntered) //counter to limit instances
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (counter < maxDigits)
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

    }

    private void AddCharacter(int digitEntered) //create child object with text of one character
    {
        Debug.Log("OnAddchar");
        var textChildren = gameObject.transform.GetChild(counter);
        displayCode = textChildren.GetComponent<Text>();

        if (displayCode.text.Length < 1)
            displayCode.text += digitEntered;

        counter++;
    }

    private void CreateTextObject()
    {
        displayCode = Instantiate(tempCode, transform.position, Quaternion.identity) as Text;

        displayCode.transform.SetParent(GameObject.Find("DigitScreen").transform, false);

        displayCode.GetComponentInChildren<Text>();
    }

    private void CheckResults()
    {
        if (codeSolution.Contains(codeSolutionEntered))
        {
            Debug.Log("Success");
            //Open Door
        }
        else
        {
            Debug.Log("Fail");
            ResetDisplay();
            //Reset
            //Attempts==
            //Maybe Create new Solution
        }
    }

    private void ResetDisplay()
    {
        for (int i = 0; i < maxDigits; i++)
        {
            codeSolutionEntered = "";
            for (int j = 0; j < transform.childCount; j++)
            {
                var textChildren = gameObject.transform.GetChild(j);
                displayCode = textChildren.GetComponent<Text>();
                displayCode.text = "";
            }
            counter = 0;
        }
    }

    private void OnDestroy()
    {
        PressButton.ButtonPressed -= EnterCode;
    }
}
