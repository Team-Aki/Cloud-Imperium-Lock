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

    /*[SerializeField] private Sprite[] digits;
    [SerializeField] private Image[] characters;*/
    //public Transform EntriesRoot;
    [SerializeField] private Text tempCode;
    [SerializeField] private Difficulty difficulty;
    private Text displayCode;
    private int maxDigitCount;
    private int currentDigitCount = 0;

    //private string codeSequence;

    private void Start()
    {
        /*displayCode = gameObject.GetComponentInChildren<Text>();

        displayCode.text = "";*/

        //codeSequence = "";

        /*for (int i = 0; i < characters.Length; i++)
        {
            characters[i].sprite = digits[10];
        }*/

        if (difficulty == Difficulty.EASY)
            maxDigitCount = 3;
        else if (difficulty == Difficulty.NORMAL)
            maxDigitCount = 4;
        if (difficulty == Difficulty.HARD)
            maxDigitCount = 5;

        PressButton.ButtonPressed += AddDigitToCode;
    }

    private void AddDigitToCode(string digitEntered)
    {
/*        switch (difficulty)
        {
            case Difficulty.EASY:*/
                if (currentDigitCount < maxDigitCount)
                {
                    EnterCode(digitEntered);
                    currentDigitCount++;
                }
/*                break;
            case Difficulty.NORMAL:
                if (currentDigitCount >= maxDigitCount)
                {
                    EnterCode(digitEntered);
                    currentDigitCount++;
                }
                break;
            case Difficulty.HARD:
                if (currentDigitCount >= maxDigitCount)
                {
                    EnterCode(digitEntered);
                    currentDigitCount++;
                }
                break;
        } */

        //Reset/cancel last character
    }

    private void EnterCode(string digitEntered)
    {
        switch (digitEntered)
        {
            case "Zero":
                //displayCode.text += 0;
                //DisplayCodeSequence(0);
                GenerateTextInstance(0);
                break;
            case "One":
                //displayCode.text += 1;
                //DisplayCodeSequence(1);
                GenerateTextInstance(1);
                break;
            case "Two":
                //displayCode.text += 2;
                //DisplayCodeSequence(2);
                GenerateTextInstance(2);
                break;
            case "Three":
                //displayCode.text += 3;
                //DisplayCodeSequence(3);
                GenerateTextInstance(3);
                break;
            case "Four":
                //displayCode.text += 4;
                //DisplayCodeSequence(4);
                GenerateTextInstance(4);
                break;
            case "Five":
                //displayCode.text += 5;
                //DisplayCodeSequence(5);
                GenerateTextInstance(5);
                break;
            case "Six":
                //displayCode.text += 6;
                //DisplayCodeSequence(6);
                GenerateTextInstance(6);
                break;
            case "Seven":
                //displayCode.text += 7;
                //DisplayCodeSequence(7);
                GenerateTextInstance(7);
                break;
            case "Eight":
                //displayCode.text += 8;
                //DisplayCodeSequence(8);
                GenerateTextInstance(8);
                break;
            case "Nine":
                //displayCode.text += 9;
                //DisplayCodeSequence(9);
                GenerateTextInstance(9);
                break;
        }
    }

    private void GenerateTextInstance(int digitEntered)
    {
        // var displayCode = Resources.Load("Digit") as Text;

        CreateTextObject();
        //displayCode.transform.SetParent(CanvasRenderer.transform, false);

        displayCode.text += digitEntered;

        //then convert int to char/string ?

    }

    private void CreateTextObject()
    {
        displayCode = Instantiate(tempCode, transform.position, Quaternion.identity);

        displayCode.transform.SetParent(GameObject.Find("Screen").transform, false); //= parent.transform;

        displayCode.GetComponentInChildren<Text>();
    }

    /* private void DisplayCodeSequence(int digit)
     {
         switch (displayCode.text.Length)
         {

             *//*case 1:
                 characters[0].sprite = digits[10];
                 characters[1].sprite = digits[10];
                 characters[2].sprite = digits[10];
                 characters[3].sprite = digits[digit];
                 break;
             case 2:
                 characters[0].sprite = digits[10];
                 characters[1].sprite = digits[10];
                 characters[2].sprite = characters[3].sprite;
                 characters[3].sprite = digits[digit];
                 break;
             case 3:
                 characters[0].sprite = digits[10];
                 characters[1].sprite = characters[2].sprite;
                 characters[2].sprite = characters[3].sprite;
                 characters[3].sprite = digits[digit];
                 break;
             case 4:
                 characters[0].sprite = characters[1].sprite;
                 characters[1].sprite = characters[2].sprite;
                 characters[2].sprite = characters[3].sprite;
                 characters[3].sprite = digits[digit];
                 break;*//*
         }
     }*/

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
        PressButton.ButtonPressed -= AddDigitToCode;
    }
}
