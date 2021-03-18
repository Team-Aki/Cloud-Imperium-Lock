using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SlidePos : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private DigitDisplay code;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Counter " + counter);

        slider = gameObject.GetComponent<Slider>();
    }

//Process ---- 
/* On slider change go thru children
 * counter to limit going over max --- No need I think source of bugs
 * 








*/

    public void SliderChange()
    {
        for (int i = 0; i < code.transform.childCount; i++)
        {
            for (int j = 0; j < code.codeSolution.Length; j++)
            {
                GetRelativeInstance(j);

                /*
                if (code.codeSolution.Length >= 3)
                {
                    GetRelativeInstance();
                    ShowSolutionTextNH();
                }
                else
                {
                    GetRelativeInstance();
                    ShowSolutionTextE();
                }*/

                /*if (slider.value.ToString() == code.codeSolution[counter].ToString())
                {
                    Debug.Log("Character Found");
                    GetRelativeInstance();
                    code.displayCode.text = code.codeSolution[counter].ToString();
                    counter++;
                }
                else
                {
                    code.displayCode.text = "";
                }*/

            }
            
        }
    }

    private void GetRelativeInstance(int i)
    {
        var textChildren = code.gameObject.transform.GetChild(i);
        code.displayCode = textChildren.GetComponent<Text>();
        if (code.codeSolution.Length > 3)
            ShowSolutionTextNH();
        else
            ShowSolutionTextE();
    }

    /*        for (int j = 0; j < code.codeSolution.Length; j++)
        {
            if (code.codeSolution.Length > 3)
                ShowSolutionTextNH();
            else
                ShowSolutionTextE();
        }*/

    private void ShowSolutionTextE()
    {
        if (slider.value.ToString() == code.codeSolution[0].ToString())
        {
            Debug.Log("Character Found");
            code.displayCode.text = code.codeSolution[0].ToString();

        }
        else if (slider.value.ToString() == code.codeSolution[1].ToString())
        {
            Debug.Log("Character Found");
            code.displayCode.text = code.codeSolution[1].ToString();

        }
        else if (slider.value.ToString() == code.codeSolution[2].ToString())
        {
            Debug.Log("Character Found");
            code.displayCode.text = code.codeSolution[2].ToString();

        }
        else
            code.displayCode.text = "";
    }

    private void ShowSolutionTextNH()
    {
        if (slider.value.ToString() == code.codeSolution[0].ToString())
        {
            Debug.Log("Character Found");
            code.displayCode.text = code.codeSolution[0].ToString();

        }
        else if (slider.value.ToString() == code.codeSolution[1].ToString())
        {
            Debug.Log("Character Found");
            code.displayCode.text = code.codeSolution[1].ToString();

        }
        else if (slider.value.ToString() == code.codeSolution[2].ToString())
        {
            Debug.Log("Character Found");
            code.displayCode.text = code.codeSolution[2].ToString();

        }
        else if (slider.value.ToString() == code.codeSolution[3].ToString())
        {
            Debug.Log("Character Found");
            code.displayCode.text = code.codeSolution[3].ToString();

        }
        else if (slider.value.ToString() == code.codeSolution[4].ToString())
        {
            Debug.Log("Character Found");
            code.displayCode.text = code.codeSolution[4].ToString();

        }
        else
            code.displayCode.text = "";
    }
}
