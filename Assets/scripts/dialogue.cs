using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour
{
    public GameObject body;
    public GameObject question;

    public TextMeshProUGUI dialogueBox;

    public bool chapter1;
    public string[] sentences1;
    public bool chapter2;
    public string[] sentences2;
    public bool chapter3;
    public string[] sentences3;

    public int dialogueProgress;
    public int dialogueLength;

    public bool gameReady;
    public bool endOfDialogue;

    void Start()
    {
        chapter1 = true;
    }

    void Update()
    {
        if (body.GetComponent<muffelbrumm>().speaking == false)
        {
            dialogueProgress = 0;
        }

        if (chapter1 == true)
        {
            dialogueLength = sentences1.Length;

            dialogueBox.text = sentences1[dialogueProgress];

            if (dialogueProgress >= dialogueLength -1 && dialogueProgress > 0)
            {
                if (gameReady == true)
                {
                    if (question.GetComponent<playGameButtons>().answered == false)
                    {
                        question.GetComponent<playGameButtons>().asking = true;
                    }

                    if (question.GetComponent<playGameButtons>().answered == true)
                    {
                        dialogueProgress = 0;
                        chapter2 = true;
                        chapter1 = false;
                    }
                }

                if (gameReady == false)
                {
                    endOfDialogue = true;
                }
            }
        }

        if (chapter2 == true)
        {
            dialogueLength = sentences2.Length;

            dialogueBox.text = sentences2[dialogueProgress];

            if (dialogueProgress >= dialogueLength -1 && dialogueProgress > 0)
            {
                endOfDialogue = true;
            }
        }

        if (chapter3 == true)
        {
            dialogueLength = sentences3.Length;

            dialogueBox.text = sentences3[dialogueProgress];

            if (dialogueProgress >= dialogueLength -1 && dialogueProgress > 0)
            {

                if (gameReady == true)
                {
                    if (question.GetComponent<playGameButtons>().answered == false)
                    {
                        question.GetComponent<playGameButtons>().asking = true;
                    }

                    if (question.GetComponent<playGameButtons>().answered == true)
                    {
                        dialogueProgress = 0;
                        chapter2 = true;
                        chapter3 = false;
                    }
                }

                if (gameReady == false)
                {
                    body.GetComponent<muffelbrumm>().speaking = false;

                    dialogueProgress = 0;
                }
            }
        }

        if (dialogueProgress == 0)
        {
            question.GetComponent<playGameButtons>().answered = false;
        }
    }
}
