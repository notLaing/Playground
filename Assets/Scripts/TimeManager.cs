using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    //https://www.youtube.com/watch?v=0VGosgaoTsw
    //need to adjust animators to use unscaled time?
    public GameObject takodachis;
    public static bool UI_on = false;
    public UI_Code uiScript;
    public GameObject ability1;

    public float slowdownFactor = .05f;
    public float slowdownLength = 2f;

    void Start()
    {
        uiScript = FindObjectOfType<UI_Code>();
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
            if (UI_on) DeactivateUI();
            else ActivateUI();
        }
    }

    void FixedUpdate()
    {
        if (UI_on) moveAbility1(true);
        else moveAbility1(false);
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
        /*takodachis.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * .02f;*/
        UI_on = false;
    }

    public void moveAbility1(bool active)
    {
        if(active)
        {
            float y = ability1.transform.localPosition.y + (800 * Time.unscaledDeltaTime);
            if (y > 100f) y = 100f;
            Vector3 pos = new Vector3(0, y, 0);
            ability1.transform.localPosition = pos;
            //lerp
        }
        else
        {
            float y = ability1.transform.localPosition.y - (800 * Time.unscaledDeltaTime);
            if (y < 0f) y = 0f;
            Vector3 pos = new Vector3(0, y, 0);
            ability1.transform.localPosition = pos;

            if(y == 0f)
            {
                takodachis.SetActive(false);
                Time.timeScale = 1f;
                Time.fixedDeltaTime = Time.timeScale * .02f;
            }
        }
    }
}
