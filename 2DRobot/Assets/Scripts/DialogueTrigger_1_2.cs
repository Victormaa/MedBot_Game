using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger_1_2 : MonoBehaviour
{
    public Dialogue dialogue;
    
    //StartDialogue();

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Player" & FindObjectOfType<ItemManager>().Items.Contains("Diary"))
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        //Put event system 
        //dialogue = FindObjectOfType<EventSystem>().GetDialogue();
        FindObjectOfType<DialogueManager_1>().SwitchScene = true;
        FindObjectOfType<DialogueManager_1>().StartDialogue(dialogue);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
