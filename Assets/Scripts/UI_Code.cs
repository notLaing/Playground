using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//CURRENTLY ATTACHED TO: Canvas_TimeUI > Takodachis > [each ability and takodachi]

public class UI_Code : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isOver = false;
    public TimeManager timeScript;

    // Start is called before the first frame update
    void Start()
    {
        timeScript = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse enter");
        isOver = true;
        transform.localScale = new Vector3(2f, 2f, 2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse exit");
        isOver = false;
        transform.localScale = Vector3.one;
    }

    public void Ability1()
    {
        Debug.Log("Ability 1");
        timeScript.DeactivateUI();
        //OnPointerExit();
        isOver = false;
        transform.localScale = Vector3.one;
    }

    public void Ability2()
    {
        Debug.Log("Ability 2");
        timeScript.DeactivateUI();
        //OnPointerExit();
        isOver = false;
        transform.localScale = Vector3.one;
    }

    public void Ability3()
    {
        Debug.Log("Ability 3");
        timeScript.DeactivateUI();
        //OnPointerExit();
        isOver = false;
        transform.localScale = Vector3.one;
    }

    public void Ability4()
    {
        Debug.Log("Ability 4");
        timeScript.DeactivateUI();
        //OnPointerExit();
        isOver = false;
        transform.localScale = Vector3.one;
    }
}