using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidePos : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        Debug.Log("Slider is at " + slider.value);
    }

    public void SliderChange()
    {
        Debug.Log("Slider is at " + slider.value);
    }
}
