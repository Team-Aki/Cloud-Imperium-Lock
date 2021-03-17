using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
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

    [SerializeField] private Text tempCode;
    [SerializeField] private Difficulty difficulty;
    private int maxDigitCount;
    //private int index;

    private Text displayCode;
    int counter = 0;

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
            CreateTextObject(); //i
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
                break;
            case "One":
                GenerateText(1);
                break;
            case "Two":
                GenerateText(2);
                break;
            case "Three":
                GenerateText(3);
                break;
            case "Four":
                GenerateText(4);
                break;
            case "Five":
                GenerateText(5);
                break;
            case "Six":
                GenerateText(6);
                break;
            case "Seven":
                GenerateText(7);
                break;
            case "Eight":
                GenerateText(8);
                break;
            case "Nine":
                GenerateText(9);
                break;
        }

        
    }

    private void GenerateText(int digitEntered)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (counter == 0 && counter < maxDigitCount)
            {
                var textChildren = gameObject.transform.GetChild(0);
                displayCode = textChildren.GetComponent<Text>();
                displayCode.text += digitEntered;
                counter++;
                break;
            }
            else if (counter == 1 && counter < maxDigitCount)
            {
                var textChildren = gameObject.transform.GetChild(1);
                displayCode = textChildren.GetComponent<Text>();
                displayCode.text += digitEntered;
                counter++;
                break;
            }
            else if (counter == 2 && counter < maxDigitCount)
            {
                var textChildren = gameObject.transform.GetChild(2);
                displayCode = textChildren.GetComponent<Text>();
                displayCode.text += digitEntered;
                counter++;
                break;
            }
            else if (counter == 3 && counter < maxDigitCount)
            {
                var textChildren = gameObject.transform.GetChild(3);
                displayCode = textChildren.GetComponent<Text>();
                displayCode.text += digitEntered;
                counter++;
                break;
            }
            else if (counter == 4 && counter < maxDigitCount)
            {
                var textChildren = gameObject.transform.GetChild(4);
                displayCode = textChildren.GetComponent<Text>();
                displayCode.text += digitEntered;
                counter++;
                break;
            }
        }
        

        
        //int counter = 1;

        /*for (int i = 0; i < displayCode.Count; i++)
        {
            Debug.Log("dfdsaaaaa");
        }*/

        /*foreach (Text item in displayCode)
        {

            if (item.text.Length < 1)
            {
                item.text += digitEntered;
                continue;
            }
            //if()
        }*/

        //int count = 0;
      /*  displayCode = textChildren.GetComponent<Text>();

        if (displayCode.text.Length < 1)
            displayCode.text += digitEntered;
        else
            displayCode.text = digitEntered.ToString();*/
        


        //then convert int to char/string ?
       
    }

    private void CreateTextObject()
    {
        displayCode = Instantiate(tempCode, transform.position, Quaternion.identity) as Text;

        displayCode.transform.SetParent(GameObject.Find("Screen").transform, false);

        displayCode.GetComponentInChildren<Text>();
    }

    private void CheckResults()
    {
        //check on update
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
