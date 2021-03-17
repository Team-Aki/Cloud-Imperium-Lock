﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] digits;
    [SerializeField] private Image[] characters;

    private string codeSequence;

    private void Start()
    {
        codeSequence = "";

        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].sprite = digits[10];
        }

        PressButton.ButtonPressed += AddDigitToCode;
    }

    private void AddDigitToCode(string digitEntered)
    {
        if (codeSequence.Length < 4)
        {
            switch (digitEntered)
            {
                case "Zero":
                    codeSequence += 0;
                    DisplayCodeSequence(0);
                    break;
                case "One":
                    codeSequence += 1;
                    DisplayCodeSequence(1);
                    break;
                case "Two":
                    codeSequence += 2;
                    DisplayCodeSequence(2);
                    break;
                case "Three":
                    codeSequence += 3;
                    DisplayCodeSequence(3);
                    break;
                case "Four":
                    codeSequence += 4;
                    DisplayCodeSequence(4);
                    break;
                case "Five":
                    codeSequence += 5;
                    DisplayCodeSequence(5);
                    break;
                case "Six":
                    codeSequence += 6;
                    DisplayCodeSequence(6);
                    break;
                case "Seven":
                    codeSequence += 7;
                    DisplayCodeSequence(7);
                    break;
                case "Eight":
                    codeSequence += 8;
                    DisplayCodeSequence(8);
                    break;
                case "Nine":
                    codeSequence += 9;
                    DisplayCodeSequence(9);
                    break;
            }
        }

        //Reset/cancel last character
    }

    private void DisplayCodeSequence(int digit)
    {
        switch (codeSequence.Length)
        {
            case 1:
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
                break;
        }
    }

    private void CheckResults()
    {
        //reset display if wrong
        //attempts --
    }

    private void ResetDisplay()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].sprite = digits[10];
        }
    }

    private void OnDestroy()
    {
        PressButton.ButtonPressed -= AddDigitToCode;
    }
}