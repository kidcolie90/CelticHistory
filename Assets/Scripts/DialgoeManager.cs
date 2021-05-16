using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//reference to code : https://forum.unity.com/threads/creating-a-basic-dialogue-window.494649/

public class DialgoeManager : MonoBehaviour
{

    private Queue <string> sentences; //Que is like list opperating on FIFO principal
    
    
    
    
    
    // Start is called before the first frame update
   /* void Start()
    {
        sentences = new Queue<string>();
        
    }



   /* public void StartConvo(Dialogue dialogue)
    {

        sentences.Clear();

        foreach( string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialgoue();
            return;
        }
    }
        string sentence = Sentences.Dequeue();

    }



    void EndDialogue()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
