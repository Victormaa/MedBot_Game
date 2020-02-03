using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameManager.Instance.PlayerState == State.a_Sesrching)
            {
                GameManager.Instance.is_Found = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
            }
    }
    
}
