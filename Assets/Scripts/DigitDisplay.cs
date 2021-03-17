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
    private Text displayCode;
    [SerializeField] private Difficulty difficulty;

    //private string codeSequence;

    private void Start()
    {
        displayCode = gameObject.GetComponentInChildren<Text>();

        displayCode.text = "";

        //codeSequence = "";

        /*for (int i = 0; i < characters.Length; i++)
        {
            characters[i].sprite = digits[10];
        }*/

        PressButton.ButtonPressed += AddDigitToCode;
    }

    private void AddDigitToCode(string digitEntered)
    {
        switch (difficulty)
        {
            case Difficulty.EASY:
                if (displayCode.text.Length < 4)
                {
                    EnterCode(digitEntered);
                }
                break;
            case Difficulty.NORMAL:
                if (displayCode.text.Length < 5)
                {
                    EnterCode(digitEntered);
                }
                break;
            case Difficulty.HARD:
                if (displayCode.text.Length < 6)
                {
                    EnterCode(digitEntered);
                }
                break;
        }
        

        //Reset/cancel last character
    }

    private void EnterCode(string digitEntered)
    {
        switch (digitEntered)
        {
            case "Zero":
                displayCode.text += 0;
                //DisplayCodeSequence(0);
                break;
            case "One":
                displayCode.text += 1;
                //DisplayCodeSequence(1);
                break;
            case "Two":
                displayCode.text += 2;
                //DisplayCodeSequence(2);
                break;
            case "Three":
                displayCode.text += 3;
                //DisplayCodeSequence(3);
                break;
            case "Four":
                displayCode.text += 4;
                //DisplayCodeSequence(4);
                break;
            case "Five":
                displayCode.text += 5;
                //DisplayCodeSequence(5);
                break;
            case "Six":
                displayCode.text += 6;
                //DisplayCodeSequence(6);
                break;
            case "Seven":
                displayCode.text += 7;
                //DisplayCodeSequence(7);
                break;
            case "Eight":
                displayCode.text += 8;
                //DisplayCodeSequence(8);
                break;
            case "Nine":
                displayCode.text += 9;
                //DisplayCodeSequence(9);
                break;
        }
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
        //reset display if wrong
        //attempts --
    }

    private void ResetDisplay()
    {
        for (int i = 0; i < displayCode.text.Length; i++)
        {
            displayCode.text = "";
        }
    }

    private void OnDestroy()
    {
        PressButton.ButtonPressed -= AddDigitToCode;
    }
}
