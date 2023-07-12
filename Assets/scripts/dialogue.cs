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

        if (dialogueProgress >= dialogueLength && dialogueProgress > 0)
        {
            question.GetComponent<playGameButtons>().asking = true;

            if (question.GetComponent<playGameButtons>().answered == true)
            {
                body.GetComponent<muffelbrumm>().speaking = false;
            }
        }

        if (chapter1 == true)
        {
            dialogueLength = sentences1.Length;

            dialogueBox.text = sentences1[dialogueProgress];
        }
        if (chapter2 == true)
        {
            dialogueLength = sentences2.Length;

            dialogueBox.text = sentences2[dialogueProgress];
        }
        if (chapter3 == true)
        {
            dialogueLength = sentences3.Length;

            dialogueBox.text = sentences3[dialogueProgress];
        }
    }
}
