using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CURRENTLY ATTACHED TO: Canvas_TimeUI

public class TimeManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=0VGosgaoTsw
    //need to adjust animators to use unscaled time?
    public GameObject takodachis;
    public static bool UI_on = false;
    public UI_Code uiScript;
    GameObject[] abilityArray = new GameObject[4];
    public GameObject ability0;
    public GameObject ability1;
    public GameObject ability2;
    public GameObject ability3;
    float uiTime = 0f;
    bool changeUISize = false;

    public float slowdownFactor = .05f;
    public float slowdownLength = 2f;

    void Start()
    {
        uiScript = FindObjectOfType<UI_Code>();
        abilityArray[0] = ability0;
        abilityArray[1] = ability1;
        abilityArray[2] = ability2;
        abilityArray[3] = ability3;
        //ability1 = takodachis.
        //ability1 = takodachis.transform.Find("Ability1").GetComponent<GameObject>();
    }

    //slowly return back to normal time
    /*void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        //increase pitches of sounds
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            changeUISize = true;
            if (UI_on) DeactivateUI();
            else ActivateUI();
        }
    }

    void FixedUpdate()
    {
        if (changeUISize) uiSize();//change the ui size as long as the time isn't over/under the limit

        if (UI_on)
        {
            moveAbility0(true);
            moveAbility1(true);
            moveAbility2(true);
            moveAbility3(true);
            uiTime += Time.fixedUnscaledDeltaTime;
            if (uiTime > .15f)
            {
                uiTime = .15f;
                if (changeUISize) uiSize();//lerp once more to reach max size before UI_Code script becomes in charge of changing icon size
                changeUISize = false;
            }
        }
        else
        {
            moveAbility0(false);
            moveAbility1(false);
            moveAbility2(false);
            moveAbility3(false);
            uiTime -= Time.fixedUnscaledDeltaTime;
            if (uiTime < 0f)
            {
                uiTime = 0f;
                if (changeUISize) uiSize();//lerp once more to reach max size before UI_Code script becomes in charge of changing icon size
                changeUISize = false;
            }
            if (uiTime == 0f)
            {
                takodachis.SetActive(false);
                Time.timeScale = 1f;
                Time.fixedDeltaTime = Time.timeScale * .02f;
            }
        }
    }

    //grow/shrink the UI ability sizes as they expand/retract
    public void uiSize()
    {
        for (int i = 0; i < 4; ++i)
        {
            //need uiTime to be between values of 0 and 1. UI extends/retracts over .15 seconds
            abilityArray[i].transform.localScale = Vector3.Lerp(Vector3.one * .25f, Vector3.one, Mathf.Pow(((uiTime * 100f) / 15f), 3));
        }
    }

    public void slowTime()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        //decrease pitches of sounds
    }

    public void ActivateUI()
    {
        takodachis.SetActive(true);
        Time.timeScale = 0.05f;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        UI_on = true;
    }

    public void DeactivateUI()//CALLED BY UI_Code: NEED TO MAKE ANIMATION BACK IN ONLY FOR CLOSING, NOT ABILITY USE
    {
        UI_on = false;
    }


    //lerp to move abilities to the correct spot on canvas
    public void moveAbility0(bool active)
    {
        if(active) ability0.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0f, 100f, 0f), uiTime / .15f);
        else ability0.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0f, 100f, 0f), uiTime / .15f);
    }

    public void moveAbility1(bool active)
    {
        if (active) ability1.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(100f, 0f, 0f), uiTime / .15f);
        else ability1.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(100f, 0f, 0f), uiTime / .15f);
    }

    public void moveAbility2(bool active)
    {
        if (active) ability2.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0f, -100f, 0f), uiTime / .15f);
        else ability2.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(0f, -100f, 0f), uiTime / .15f);
    }

    public void moveAbility3(bool active)
    {
        if (active) ability3.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(-100f, 0f, 0f), uiTime / .15f);
        else ability3.transform.localPosition = Vector3.Lerp(Vector3.zero, new Vector3(-100f, 0f, 0f), uiTime / .15f);
    }
}
