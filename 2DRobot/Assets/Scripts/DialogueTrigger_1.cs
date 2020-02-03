using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger_1 : MonoBehaviour
{
    public Dialogue dialogue;
    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 5.0f;
    private float startTime;

    //StartDialogue();

    void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log("Collided");
        if(col.gameObject.name == "Player" & !FindObjectOfType<ItemManager>().Items.Contains("Diary"))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        //Put event system 
        FindObjectOfType<DialogueManager_1>().StartDialogue(dialogue);
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time + 3;
    }

    // Update is called once per frame
    void Update()
    {
        float t = (Time.time - startTime) / duration;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.SmoothStep(minimum, maximum, t));
    }
}
