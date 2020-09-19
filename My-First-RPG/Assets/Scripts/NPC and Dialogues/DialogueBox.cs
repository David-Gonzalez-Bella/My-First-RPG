using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public static DialogueBox sharedInstance;
    public TMP_Text speaker;
    public TMP_Text content;
    private Dialogue dialogue;
    private int dialogueIndex = 0;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }

    public void StartDialogue(string speakerName, Dialogue npcDialogue)
    {
        gameObject.SetActive(true);
        dialogue = npcDialogue;
        speaker.text = speakerName;
        content.text = dialogue.lines[dialogueIndex];
    }

    public void NextLine()
    {
        dialogueIndex++;
        if (dialogueIndex >= dialogue.lines.Length)
        {
            gameObject.SetActive(false);
            return;
        }
        content.text = dialogue.lines[dialogueIndex]; 
    }
    
}
