using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPoint : MonoBehaviour
{
    public int Num;

    internal bool isSuccess = true;

    [SerializeField]
    [Range(0.2f, 1)]
    float adjust = 0.2f;

    public bool islighted = false;

    public void setOriginal()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(188.0f / 255, 68.0f / 255, 48.0f / 255,  0.2f);
    }

    public void TurnLightOn(float Timer, float FinishedTime)
    {
        this.GetComponent<SpriteRenderer>().color = new Color(188.0f / 255, 68.0f / 255, 48.0f / 255, Mathf.Lerp( 0.2f, 1, Timer / FinishedTime));
    }

    public void CompareLight(int current)
    {
        if (!islighted)
        {
            if (Num - current != 1)
            {
                Invoke("TurnLightoff", 2);
            }
            else
            {
                
                LightPointManager.Instance.light_message += LightSuccess;
            }
        }
        
    }

    void LightSuccess()
    {
        GameManager.Instance.CurrentLight = Num;
        GameManager.Instance.SoundsEffect();
        islighted = true;
        LightPointManager.Instance.lightsON();
        LightPointManager.Instance.light_message -= LightSuccess;
    }

    internal void TurnLightoff()
    {
        // light manager turn all light off
        Debug.Log("Turnoffall");

        GameManager.Instance.CurrentLight = 0;
        GameManager.Instance.FailureSound();
        LightPointManager.Instance.StepWrong();
    }

}
