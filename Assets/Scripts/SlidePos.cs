using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidePos : MonoBehaviour
{
    private Slider slider;

    [SerializeField] private DigitDisplay code;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();

        Debug.Log("Code Solution in Slider Obj " + code.codeSolution);

    }

    public void SliderChange()
    {
        for (int i = 0; i < code.codeSolution.Length; i++)
        {
            char character = code.codeSolution[i];
            if (slider.value == character)
            {
                Debug.Log("Character should appear");
            }
            else
                Debug.Log("Different character");
        }
        Debug.Log("Slider is at " + slider.value);
    }
}
