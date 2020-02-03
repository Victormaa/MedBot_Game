using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager_1 : MonoBehaviour
{
    public GameObject DialogueBox; 
    public Text DialogueText;
    [HideInInspector]
    public bool SwitchScene;

    private Queue<string> sentences;
    private string DialogueName;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        SwitchScene = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
        //Debug.Log("Sentence Count 1: " + sentences.Count);
        sentences.Clear();
        DialogueName = dialogue.name;
        DialogueBox.SetActive(true);
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }
        //int sentenceNumber = sentences.Count;

        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        //Debug.Log("Sentence Count 5: " + sentences.Count);
        if (sentences.Count == 0){
            //Debug.Log("Sentence Count 2: " + sentences.Count);
            EndDialogue();
            return;
        }
        //sentenceNumber -= 1;
        //Debug.Log("Sentence Count 3: " + sentences.Count);
        string sentence = sentences.Dequeue();
        //Debug.Log("Sentence Count after Dequeue: " + sentences.Count);
        Debug.Log(sentence);
        DialogueText.text = DialogueName.ToUpper() + ": " + sentence;

    }

    void EndDialogue()
    {
        //Debug.Log("Sentence Count 4: " + sentences.Count);
        Debug.Log("End of conversation.");
        //DialogueBox.GetComponent<Renderer>().enabled = false;
        DialogueBox.SetActive(false);
        /*
        if (SwitchScene == true) {
            //SceneManager.LoadScene(1);
            FindObjectOfType<LevelChanger>().FadeToLevel(2);
        }*/
}
   
}
