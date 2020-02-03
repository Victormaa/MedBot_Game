using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPointManager : MonoBehaviour
{

    public GameObject[] Lights;

    private static LightPointManager lightManager;

    public static LightPointManager Instance
    {
        get
        {
            if (lightManager == null)
            {
                new GameManager();
            }
            return lightManager;
        }
    }

    private void Awake()
    {
        if (lightManager != null)
        {
            return;
        }
        else
        {
            lightManager = this;
        }
    }

    [SerializeField]
    int LightNum;

    public delegate void Light_Message();

    public Light_Message light_message;

    // Start is called before the first frame update
    void Start()
    {
        Lights = GameObject.FindGameObjectsWithTag("L_1");
        LightNum = Lights.Length;
    }

    public int CurrentLights;

    // Update is called once per frame
    void Update()
    {
     if(light_message != null)
        {
            light_message();
        }  
     if(CurrentLights == LightNum)
        {
            GameManager.Instance.OpenTheDoor();
        }
    }

    public void StepWrong()
    {
        foreach(GameObject a in Lights)
        {
            a.GetComponent<LightPoint>().setOriginal();
            a.GetComponent<LightPoint>().islighted = false;
            FindObjectOfType<PlayerMovement>().resetTimer();
            ResetCurrentLight();
        }
        
    }

    public void lightsON()
    {
        CurrentLights += 1;
    }

    public void ResetCurrentLight()
    {
        CurrentLights = 0;
    }
}
