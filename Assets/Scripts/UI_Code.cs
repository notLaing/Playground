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
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Mouse enter");
        isOver = true;
        transform.localScale = new Vector3(2f, 2f, 2f);

        //play sound
        FindObjectOfType<AudioManager>().Play("AbilityHover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Mouse exit");
        isOver = false;
        transform.localScale = Vector3.one;
    }

    public void AbilitySelect()
    {
        FindObjectOfType<AudioManager>().Play("AbilitySelect");
    }

    public void Ability0()
    {
        Debug.Log("Ability 0");
        timeScript.DeactivateUI();
        //OnPointerExit();
        isOver = false;
        transform.localScale = Vector3.one;
        AbilitySelect();
    }

    public void Ability1()               //since each ability needs to go to its own onClick anyway, don't need to separate it out like this? Might need it when abilities do stuff. Could at least move the common stuff to its own function
    {
        Debug.Log("Ability 1");
        timeScript.DeactivateUI();
        //OnPointerExit();
        isOver = false;
        transform.localScale = Vector3.one;
        AbilitySelect();
    }

    public void Ability2()
    {
        Debug.Log("Ability 2");
        timeScript.DeactivateUI();
        //OnPointerExit();
        isOver = false;
        transform.localScale = Vector3.one;
        AbilitySelect();
    }

    public void Ability3()
    {
        Debug.Log("Ability 3");
        timeScript.DeactivateUI();
        //OnPointerExit();
        isOver = false;
        transform.localScale = Vector3.one;
        AbilitySelect();
    }
}