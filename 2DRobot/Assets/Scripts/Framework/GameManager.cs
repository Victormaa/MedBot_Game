using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniarts.ColorCorrection;
using UnityEngine.UI;
using System;
using Fungus;

public enum State
{
    a_Sesrching,
    b_going,
    c_challenging,
    d_Sensing,
    e_Finished
}

public enum LevelState
{
    Start,
    Level_0,
    Level_1,
    Level_2,
    Level_3,
    end
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject LevelDoor;

    public LevelState level = LevelState.Level_0;

    [SerializeField]
    private Image BlackMask;

    [SerializeField]
    AudioSource[] audios;

    [SerializeField]
    AudioSource BackGround;

    [SerializeField]
    AudioSource failureSound;

    private static GameManager gameManager;

    public static GameManager Instance
    {
        get
        {
            if(gameManager == null)
            {
                new GameManager();
            }
            return gameManager;
        }
    }

    public int CurrentLight = 0;

    public delegate void Level();

    public Level Go_Level_1;

    private void Awake()
    {
        if(gameManager != null)
        {
            
            return;
        }
        else
        {
            Debug.Log("1");
            gameManager = this;
        }
        DontDestroyOnLoad(this.gameObject);
        
    }


    int i = 0;

    public void SoundsEffect()
    {
        if (i == 3)
            i = 0;
       
        audios[i].Play();
        i += 1;
    }

    public void FailureSound()
    {
        failureSound.Play();
    }

    float o_brightness;
    float o_Hue;
    float o_Saturation;
    float o_constrast;

    public State PlayerState;

    bool Isinitiallize = false;
    void settingInitial()
    {
        is_Found = false;
        is_Arrive = false;
        is_victory = false;
        is_sensed = false;
        Invoke("SceneBegin", 2);
        PlayerState = 0;
    }

    
    public bool is_Found = false;
    public bool is_Arrive = false;
    public bool is_victory = false;
    public bool is_sensed = false;
    public bool TheLevelFinished = false;

    
    
    // Start is called before the first frame update
    void Start()
    {
        o_brightness = Camera.main.GetComponent<ColorCorrectionPro>().brightness;
        o_Hue = Camera.main.GetComponent<ColorCorrectionPro>().hue;
        o_Saturation = Camera.main.GetComponent<ColorCorrectionPro>().saturation;
        o_constrast = Camera.main.GetComponent<ColorCorrectionPro>().contrast;
    }

    bool temporary_forQuitGame = false;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            temporary_forQuitGame = true;
        }
        if (temporary_forQuitGame)
            Application.Quit();


        if (level == LevelState.Level_0)
        {
            BackGround.Stop();
            return;
        } 

            
        if (!Isinitiallize)
        {
            settingInitial();
            LevelDoor = GameObject.FindGameObjectWithTag("Level");
            //BackGround.Play();
            Isinitiallize = true;
        }
        /*
        switch (PlayerState)
        {
            case State.a_Sesrching:
                Debug.Log("Finding THE object");
                if (is_Found)
                {
                    Found();
                }
                break;
            case State.b_going:
                Debug.Log("Going to destination");
                if (is_Arrive)
                {
                    Arrival();
                }
                break;
            case State.c_challenging:
                Debug.Log("challeging");
                if (is_victory)
                {
                    victory();
                }
                break;
            case State.d_Sensing:
                Debug.Log("getting sense");
                if (is_sensed)
                {
                    Sensed();
                }
                break;
            case State.e_Finished:
                Debug.Log("go to next level soom");
                if(!TheLevelFinished)
                    NextGame();
                break;

            default:
                break;
        }*/

        if (Go_Level_1 != null)
        {
            Go_Level_1();
        }
    }

    public void NextLevel()
    {
        BackGround.Pause();
        // before the next level come shut down music
        if (level == LevelState.Start)
        {
            level = LevelState.Level_0;
        }
        if(level == LevelState.Level_0)
        {
            level = LevelState.Level_1;
        }else if(level == LevelState.Level_1)
        {
            level = LevelState.Level_2;
        }
        else if (level == LevelState.Level_2)
        {
            level = LevelState.Level_3;
        }else if(level == LevelState.Level_3)
        {
            level = LevelState.end;
        }
    }

    public void Repair(float Timer, float FinishedTime)
    {
        Camera.main.GetComponent<ColorCorrectionPro>().brightness = Mathf.Lerp(o_brightness, 0, Timer / FinishedTime);
        Camera.main.GetComponent<ColorCorrectionPro>().hue = Mathf.Lerp(o_Hue, 0, Timer / FinishedTime);
        Camera.main.GetComponent<ColorCorrectionPro>().saturation = Mathf.Lerp(o_Saturation, 0, Timer / FinishedTime);
        Camera.main.GetComponent<ColorCorrectionPro>().contrast = Mathf.Lerp(o_constrast, 0, Timer / FinishedTime);
    }

    public void LightON(float Timer, float FinishedTime)
    {
        BlackMask.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, Timer / FinishedTime));
    }

    void Found()
    {
        PlayerState = State.b_going;
    }

    void Arrival()
    {
        PlayerState = State.c_challenging;
    }

    void victory()
    {
        PlayerState = State.d_Sensing;
    }

    void Sensed()
    {
        PlayerState = State.e_Finished;
    }

    public void NextGame()
    {
        Debug.Log("Should I play here?");
        BackGround.Play();
        Invoke("GotoScene", 3);
        CurrentLight = 0;
    }

    void GotoScene()
    {
        Isinitiallize = false;
        TheLevelFinished = true;
    }

    void SceneBegin()
    {
        TheLevelFinished = false;
    }

    [SerializeField]
    GameObject Trigger;

    bool istriggerLevel_1 = false;

    public void OpenTheDoor()
    {
        if (!istriggerLevel_1)
        {
            if (level == LevelState.Level_1)
            {
                GameObject tem = GameObject.Instantiate(Trigger);
                tem.SetActive(true);
                istriggerLevel_1 = true;
            }
        }
        LevelDoor.GetComponent<SpriteRenderer>().enabled = true;
        LevelDoor.GetComponent<Collider2D>().isTrigger = true;
    }
}
