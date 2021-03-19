using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class SlidePos : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private DigitDisplay code;

    private string tempCodeSolution;

    private string solutionChars = "0123456789";

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();

        code = GameObject.Find("Screen").GetComponent<DigitDisplay>();

        tempCodeSolution = code.codeSolution;

        //string sliderValue = code.codeSolution;
    }

    private void Update()
    {
        if(code.success)
        {
            slider.enabled = false;
        }
            
    }

    public void SliderChange()
    {
        if (tempCodeSolution.Length == 4)
            ShowSolutionTextN();
        else if(tempCodeSolution.Length == 5)
            ShowSolutionTextH();
        else if(tempCodeSolution.Length == 3)
            ShowSolutionTextE();
        
    }

    private void ShowSolutionTextE()
    {
        //var matches = Regex.Matches(tempCodeSolution, @"(.)\1+");

/*        for (int i = 0; i < tempCodeSolution.Length; i++)
        {
            if (tempCodeSolution.Length != tempCodeSolution.Length - 1)
            {*/
   
                if (slider.value.ToString().Contains(tempCodeSolution[0].ToString()))
                {
                    CheckFirstCharacter();
                    //GetDigitChild(0);
                }
                else if (slider.value.ToString().Contains(tempCodeSolution[1].ToString()))
                {
                    CheckSecondCharacter();
                }
                else if (slider.value.ToString().Contains(tempCodeSolution[2].ToString()))
                {
                    var textChildrenNext = code.gameObject.transform.GetChild(2);
                    code.displayCode = textChildrenNext.GetComponent<Text>();
                    Text tempDisplayCodeNext = code.displayCode;
                    tempDisplayCodeNext.text = tempCodeSolution[2].ToString();
                }
                else
                    code.displayCode.text = "";

    }

    private void ShowSolutionTextH()
    {
        /*if (slider.value.ToString() == tempCodeSolution[0].ToString())
        {
            var textChildren0 = code.gameObject.transform.GetChild(0);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[0].ToString();
        }
        else if (slider.value.ToString() == tempCodeSolution[1].ToString())
        {
            var textChildren0 = code.gameObject.transform.GetChild(1);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[1].ToString();
        }
        else if (slider.value.ToString() == tempCodeSolution[2].ToString())
        {
            var textChildren0 = code.gameObject.transform.GetChild(2);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[2].ToString();
        }*/

        if (slider.value.ToString().Contains(tempCodeSolution[0].ToString()))
        {
            var textChildren0 = code.gameObject.transform.GetChild(0);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[0].ToString();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[1].ToString()))
        {
            var textChildren0 = code.gameObject.transform.GetChild(1);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[1].ToString();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[2].ToString()))
        {
            var textChildren0 = code.gameObject.transform.GetChild(2);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[2].ToString();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[3].ToString()))
        {
            var textChildren0 = code.gameObject.transform.GetChild(3);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[3].ToString();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[4].ToString()))
        {
            var textChildren0 = code.gameObject.transform.GetChild(4);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[4].ToString();
        }
        else
            code.displayCode.text = "";
    }

    private void ShowSolutionTextN()
    {
        if (slider.value.ToString() == tempCodeSolution[0].ToString())
        {
            var textChildren0 = code.gameObject.transform.GetChild(0);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[0].ToString();
        }
        else if (slider.value.ToString() == tempCodeSolution[1].ToString())
        {
            var textChildren0 = code.gameObject.transform.GetChild(1);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[1].ToString();

        }
        else if (slider.value.ToString() == tempCodeSolution[2].ToString())
        {
            var textChildren0 = code.gameObject.transform.GetChild(2);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[2].ToString();
        }
        else if (slider.value.ToString() == tempCodeSolution[3].ToString())
        {
            var textChildren0 = code.gameObject.transform.GetChild(3);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[3].ToString();
        }
        else
            code.displayCode.text = "";
    }


    private void CheckFirstCharacter()
    {
        if (tempCodeSolution[0] == tempCodeSolution[1])
        {
            var textChildren0 = code.gameObject.transform.GetChild(0);
            code.displayCode = textChildren0.GetComponent<Text>();
            Text tempDisplayCode = code.displayCode;
            tempDisplayCode.text = tempCodeSolution[0].ToString();

            /*var textChildren0 = code.gameObject.transform.GetChild(0);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[0].ToString();*/

            var textChildrenNext = code.gameObject.transform.GetChild(1);
            code.displayCode = textChildrenNext.GetComponent<Text>();
            Text tempDisplayCodeNext = code.displayCode;
            tempDisplayCodeNext.text = tempCodeSolution[1].ToString();
        }
        else if (tempCodeSolution[0] == tempCodeSolution[2])
        {
            var textChildren0 = code.gameObject.transform.GetChild(0);
            code.displayCode = textChildren0.GetComponent<Text>();
            Text tempDisplayCode = code.displayCode;
            tempDisplayCode.text = tempCodeSolution[0].ToString();

            var textChildrenNext = code.gameObject.transform.GetChild(2);
            code.displayCode = textChildrenNext.GetComponent<Text>();
            Text tempDisplayCodeNext = code.displayCode;
            tempDisplayCodeNext.text = tempCodeSolution[2].ToString();
        }
        else
        {
            var textChildren0 = code.gameObject.transform.GetChild(0);
            code.displayCode = textChildren0.GetComponent<Text>();
            Text tempDisplayCode = code.displayCode;
            tempDisplayCode.text = tempCodeSolution[0].ToString();
        }
        /*else if (tempCodeSolution[i] == tempCodeSolution[i + 2])
        {
            var textChildren0 = code.gameObject.transform.GetChild(0);
            code.displayCode = textChildren0.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[0].ToString();

            var textChildrenNext = code.gameObject.transform.GetChild(2);
            code.displayCode = textChildrenNext.GetComponent<Text>();
            code.displayCode.text = tempCodeSolution[2].ToString();
        }*/

    }

    private void CheckSecondCharacter()
    {
        if (tempCodeSolution[1] == tempCodeSolution[2])
        {
            var textChildren0 = code.gameObject.transform.GetChild(1);
            code.displayCode = textChildren0.GetComponent<Text>();
            Text tempDisplayCode = code.displayCode;
            tempDisplayCode.text = tempCodeSolution[1].ToString();

            var textChildrenNext = code.gameObject.transform.GetChild(2);
            code.displayCode = textChildrenNext.GetComponent<Text>();
            Text tempDisplayCodeNext = code.displayCode;
            tempDisplayCodeNext.text = tempCodeSolution[2].ToString();
        }
        else
        {
            var textChildren1 = code.gameObject.transform.GetChild(1);
            code.displayCode = textChildren1.GetComponent<Text>();
            Text tempDisplayCode = code.displayCode;
            tempDisplayCode.text = tempCodeSolution[1].ToString();
        }
    }

    private void GetDigitChild(int i)
    {
        var textChildren0 = code.gameObject.transform.GetChild(i);
        code.displayCode = textChildren0.GetComponent<Text>();
        code.displayCode.text = tempCodeSolution[0].ToString();
    }
}
