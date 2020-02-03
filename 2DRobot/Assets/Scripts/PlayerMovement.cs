using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    AudioSource Robotmovement_S;

    private Rigidbody2D rb;
    private float moveH, moveV;
    [SerializeField] private float moveSpeed = 5.0f;

    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (!this.gameObject.GetComponent<AudioSource>())
        {
            Debug.LogError("you need a audio source for movement");
        }
        else
        {
            Robotmovement_S = this.GetComponent<AudioSource>();
        }
    }

    [SerializeField]
    private bool IsTalking = false;

    public void TalkBegin() {
        IsTalking = true;
    }

    public void TalkEnd()
    {
        IsTalking = false;
    }

    private void Update()
    {
        if (!IsTalking)
        {
            moveH = Input.GetAxis("Horizontal") * moveSpeed;
            moveV = Input.GetAxis("Vertical") * moveSpeed;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                Robotmovement_S.Play();
                anim.SetBool("top", true);
                anim.SetBool("left", false);
                anim.SetBool("right", false);
                anim.SetBool("down", false);

            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Robotmovement_S.Play();
                anim.SetBool("right", true);
                anim.SetBool("left", false);
                anim.SetBool("top", false);
                anim.SetBool("down", false);

            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Robotmovement_S.Play();
                anim.SetBool("left", true);
                anim.SetBool("top", false);
                anim.SetBool("right", false);
                anim.SetBool("down", false);

            }

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                Robotmovement_S.Play();
                anim.SetBool("down", true);
                anim.SetBool("left", false);
                anim.SetBool("right", false);
                anim.SetBool("top", false);

            }
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                Robotmovement_S.Stop();
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                Robotmovement_S.Stop();
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                Robotmovement_S.Stop();
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                Robotmovement_S.Stop();
            }
        }
        

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _Timer = 0;
        this.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<LightPoint>())
        {
            _Timer = 0;
            if (!collision.GetComponent<LightPoint>().islighted)
                collision.GetComponent<LightPoint>().setOriginal();

            this.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.StartAwake;
        }
    }

    public void resetTimer()
    {
        _Timer = 0;
    }

    [SerializeField]
    int Finished_Time = 100;

    int _Timer = 0;

    bool _islight = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "L_1" && !collision.GetComponent<LightPoint>().islighted)
        {
            
            _Timer++;

            collision.GetComponent<LightPoint>().TurnLightOn(_Timer, Finished_Time);
            if(_Timer == Finished_Time)
                collision.GetComponent<LightPoint>().CompareLight(GameManager.Instance.CurrentLight);
        }
        
    }

}
