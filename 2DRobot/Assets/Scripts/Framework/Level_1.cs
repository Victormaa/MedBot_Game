using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level_1 : MonoBehaviour
{
    int _Timer = 0;

    [SerializeField]
    Text Pace;

    [SerializeField]
    int Finished_Time = 500;

    bool istrigger = false;

    bool Level_Done = false;

    bool Dontrepeat = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!istrigger)
            Pace.text = "Level_1_Trigger";

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            _Timer = 0;
            istrigger = true;
            collision.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Dontrepeat)
        {
            if (collision.tag == "Player")
            {
                if (GameManager.Instance.PlayerState == State.d_Sensing)
                {
                    _Timer++;
                    Pace.text = (_Timer / 5).ToString();
                    GameManager.Instance.Repair(_Timer, Finished_Time);
                    GameManager.Instance.LightON(_Timer, Finished_Time);
                    if (_Timer == Finished_Time)
                    {
                        Level_Done = true;
                        if (Level_Done)
                        {
                            //GameManager.Instance.Go_Level_1 += Level_1_Finished;
                            GameManager.Instance.is_sensed = true;
                            Dontrepeat = true;
                        }

                    }
                }
            }
        }   
    }

    private void Level_1_Finished()
    {
        Debug.Log("Level Finished" + "Let's make the Robot could see the world around");
        GameManager.Instance.Go_Level_1 -= Level_1_Finished;       
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Dontrepeat)
        {
            if (collision.tag == "Player")
            {
                _Timer = 0;
                GameManager.Instance.Repair(_Timer, Finished_Time);
                istrigger = false;
                collision.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
            }
        }
    }
}
