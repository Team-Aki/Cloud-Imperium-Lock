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

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();

        code = GameObject.Find("Screen").GetComponent<DigitDisplay>();

      
    }

    
    private void Update()
    {
        tempCodeSolution = code.codeSolution; //Always get the code solution          
    }

    public void SliderChange()
    {
        if (tempCodeSolution.Length == 4)
            ShowSolutionTextN();
        else if (tempCodeSolution.Length == 5)
            ShowSolutionTextH();
        else if (tempCodeSolution.Length == 3)
            ShowSolutionTextE();
    }

/* GOTTA HARDCODE IT
 * I FEEL DISGUSTING
 
         */

    private void ShowSolutionTextE()
    {
        if (slider.value.ToString().Contains(tempCodeSolution[0].ToString()))
        {
            CheckFirstCharacterE();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[1].ToString()))
        {
            CheckSecondCharacterE();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[2].ToString()))
        {
            GetDigitChild(2);
        }
        //else
        //{
        //    DigitDisplay tempDisplayCode = GetComponent<DigitDisplay>();
        //    tempDisplayCode.displayCode.text = "";
        //}
    }

    private void ShowSolutionTextH()
    {
        if (slider.value.ToString().Contains(tempCodeSolution[0].ToString()))
        {
            CheckFirstCharacterH();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[1].ToString()))
        {
            CheckSecondCharacterH();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[2].ToString()))
        {
            CheckThirdCharacterH();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[3].ToString()))
        {
            CheckFourthCharacterH();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[4].ToString()))
            GetDigitChild(4);
        //else
        //{
        //    Text tempDisplayCode = code.displayCode;
        //    tempDisplayCode.text = "";
        //}
    }

    private void ShowSolutionTextN()
    {
        if (slider.value.ToString().Contains(tempCodeSolution[0].ToString()))
        {
            CheckFirstCharacterN();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[1].ToString()))
        {
            CheckSecondCharacterN();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[2].ToString()))
        {
            CheckThirdCharacterN();
        }
        else if (slider.value.ToString().Contains(tempCodeSolution[3].ToString()))
            GetDigitChild(3);
        //else
        //{
        //    Text tempDisplayCode = code.displayCode;
        //    tempDisplayCode.text = "";
        //}
    }

    private void CheckFirstCharacterE()
    {
        if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[2])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(2);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1])
        {
            GetDigitChild(0);
            GetDigitChild(1);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[2])
        {
            GetDigitChild(0);
            GetDigitChild(2);

        }
        else if (tempCodeSolution[0] != tempCodeSolution[1] && tempCodeSolution[0] != tempCodeSolution[2])
        {
            GetDigitChild(0);
        }
        else
            code.displayCode.text = "";
    }

    private void CheckSecondCharacterE()
    {
        if (tempCodeSolution[1] == tempCodeSolution[2])
        {
            GetDigitChild(1);
            GetDigitChild(2);
        }
        else if (tempCodeSolution[1] != tempCodeSolution[2])
            GetDigitChild(1);
        else
            code.displayCode.text = "";
    }

    private void CheckFirstCharacterN()
    {
        if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[2] && tempCodeSolution[0] == tempCodeSolution[3])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(2);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[2])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(2);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[2] && tempCodeSolution[0] == tempCodeSolution[3])
        {
            GetDigitChild(0);
            GetDigitChild(2);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[3])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1])
        {
            GetDigitChild(0);
            GetDigitChild(1);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[2])
        {
            GetDigitChild(0);
            GetDigitChild(2);

        }
        else if (tempCodeSolution[0] == tempCodeSolution[3])
        {
            GetDigitChild(0);
            GetDigitChild(3);

        }
        else if (tempCodeSolution[0] != tempCodeSolution[1] && tempCodeSolution[0] != tempCodeSolution[2] && tempCodeSolution[0] != tempCodeSolution[3])
            GetDigitChild(0);
        else
            code.displayCode.text = "";
    }

    private void CheckSecondCharacterN()
    {
        if (tempCodeSolution[1] == tempCodeSolution[2] && tempCodeSolution[1] == tempCodeSolution[3])
        {
            GetDigitChild(1);
            GetDigitChild(2);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[1] == tempCodeSolution[2])
        {
            GetDigitChild(1);
            GetDigitChild(2);
        }
        else if (tempCodeSolution[1] == tempCodeSolution[3])
        {
            GetDigitChild(1);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[1] != tempCodeSolution[2] && tempCodeSolution[1] != tempCodeSolution[3])
            GetDigitChild(1);
        else
            code.displayCode.text = "";
    }

    private void CheckThirdCharacterN()
    {
        if (tempCodeSolution[2] == tempCodeSolution[3])
        {
            GetDigitChild(2);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[2] != tempCodeSolution[3])
            GetDigitChild(2);
        else
            code.displayCode.text = "";
    }

    private void CheckFirstCharacterH()
    {
        if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[2] && tempCodeSolution[0] == tempCodeSolution[3] && tempCodeSolution[0] == tempCodeSolution[4])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(2);
            GetDigitChild(3);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[2] && tempCodeSolution[0] == tempCodeSolution[3])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(2);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[2] && tempCodeSolution[0] == tempCodeSolution[4])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(2);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[3] && tempCodeSolution[0] == tempCodeSolution[4])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(3);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[2] && tempCodeSolution[0] == tempCodeSolution[3] && tempCodeSolution[0] == tempCodeSolution[4])
        {
            GetDigitChild(0);
            GetDigitChild(2);
            GetDigitChild(3);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[4])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[3])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[1] && tempCodeSolution[0] == tempCodeSolution[2])
        {
            GetDigitChild(0);
            GetDigitChild(1);
            GetDigitChild(2);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[2] && tempCodeSolution[0] == tempCodeSolution[4])
        {
            GetDigitChild(0);
            GetDigitChild(2);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[2] && tempCodeSolution[0] == tempCodeSolution[3])
        {
            GetDigitChild(0);
            GetDigitChild(2);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[3] && tempCodeSolution[0] == tempCodeSolution[4])
        {
            GetDigitChild(0);
            GetDigitChild(3);
            GetDigitChild(4);
        }

        else if (tempCodeSolution[0] == tempCodeSolution[1])
        {
            GetDigitChild(0);
            GetDigitChild(1);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[2])
        {
            GetDigitChild(0);
            GetDigitChild(2);

        }
        else if (tempCodeSolution[0] == tempCodeSolution[3])
        {
            GetDigitChild(0);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[0] == tempCodeSolution[4])
        {
            GetDigitChild(0);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[0] != tempCodeSolution[1] && tempCodeSolution[0] != tempCodeSolution[2] && tempCodeSolution[0] != tempCodeSolution[3] && tempCodeSolution[0] != tempCodeSolution[4])
            GetDigitChild(0);
        else
            code.displayCode.text = "";
    }

    private void CheckSecondCharacterH()
    {
        if (tempCodeSolution[1] == tempCodeSolution[2] && tempCodeSolution[1] == tempCodeSolution[3] && tempCodeSolution[1] == tempCodeSolution[4])
        {
            GetDigitChild(1);
            GetDigitChild(2);
            GetDigitChild(3);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[1] == tempCodeSolution[2] && tempCodeSolution[1] == tempCodeSolution[4])
        {
            GetDigitChild(1);
            GetDigitChild(2);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[1] == tempCodeSolution[2] && tempCodeSolution[1] == tempCodeSolution[3])
        {
            GetDigitChild(1);
            GetDigitChild(2);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[1] == tempCodeSolution[3] && tempCodeSolution[1] == tempCodeSolution[4])
        {
            GetDigitChild(1);
            GetDigitChild(3);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[1] == tempCodeSolution[4])
        {
            GetDigitChild(1);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[1] == tempCodeSolution[3])
        {
            GetDigitChild(1);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[1] == tempCodeSolution[2])
        {
            GetDigitChild(1);
            GetDigitChild(2);
        }
        else if (tempCodeSolution[1] != tempCodeSolution[2] && tempCodeSolution[1] != tempCodeSolution[3] && tempCodeSolution[1] != tempCodeSolution[4])
            GetDigitChild(1);
        else
            code.displayCode.text = "";
    }

    private void CheckThirdCharacterH()
    {
        if (tempCodeSolution[2] == tempCodeSolution[3] && tempCodeSolution[2] == tempCodeSolution[4])
        {
            GetDigitChild(2);
            GetDigitChild(3);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[2] == tempCodeSolution[4])
        {
            GetDigitChild(2);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[2] == tempCodeSolution[3])
        {
            GetDigitChild(2);
            GetDigitChild(3);
        }
        else if (tempCodeSolution[2] != tempCodeSolution[3] && tempCodeSolution[2] != tempCodeSolution[4])
            GetDigitChild(2);
        else
            code.displayCode.text = "";
    }

    private void CheckFourthCharacterH()
    {
        if (tempCodeSolution[3] == tempCodeSolution[4])
        {
            GetDigitChild(3);
            GetDigitChild(4);
        }
        else if (tempCodeSolution[3] != tempCodeSolution[4])
            GetDigitChild(3);
        else
            code.displayCode.text = "";
    }

    private Text GetDigitChild(int i)
    {
        var textChild = code.gameObject.transform.GetChild(i);
        code.displayCode = textChild.GetComponent<Text>();
        Text tempDisplayCode = code.displayCode;
        tempDisplayCode.text = tempCodeSolution[i].ToString();

        StartCoroutine(CancelDigit(tempDisplayCode));

        return tempDisplayCode;
    }

    private IEnumerator CancelDigit(Text fadeText)
    {
        yield return new WaitForSeconds(1.0f);
        fadeText.text = "";
    }
}
/* THIS SOLUTION DOESN'T WORK: IT ONLY DISPLAYS THE LAST SOLUTION CHARACTER IN EVERY DIGIT
 * 
 * ONE SOLUTION WOULD BE TO STORE EACH CHARACTER AND COMPARE THEM AGAINST EACH OTHER WILL TRY THAT IF I HAVE TIME (I DON'T)
*/
/*
    for (int i = 0; i<code.gameObject.transform.childCount; i++)
        {
            var textChildrenNext = code.gameObject.transform.GetChild(i);
            code.displayCode = textChildrenNext.GetComponent<Text>();
            Text tempDisplayCodeNext = code.displayCode;
            for (int j = 0; j<code.codeSolution.Length; j++)
            {

                if (slider.value.ToString().Contains(tempCodeSolution[j].ToString()))
                {
                    tempDisplayCodeNext.text = slider.value.ToString(); //tempCodeSolution[j].ToString() slider.value.ToString()
                }
                else
                    tempDisplayCodeNext.text = "";
                
            }
     HELP   }*/