using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    private Button button;
    private Text buttonLabel;
    private int buttonNum;
    
    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        buttonLabel = gameObject.GetComponentInChildren<Text>();
        buttonLabel.text = gameObject.name;
        buttonNum = Convert.ToInt32(gameObject.name);
    }

    public void ButtonPressed()
    {
        Debug.Log("Button " + buttonNum + " was pressed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
