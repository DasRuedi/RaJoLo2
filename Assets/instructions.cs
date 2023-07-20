using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class instructions : MonoBehaviour
{
    public GameObject cam;
    public GameObject gameManager;
    public GameObject okButton;
    public GameObject deleteButton;
    public GameObject breath;


    public Sprite[] sprites;

    public Sprite[] breatheIn;
    public Sprite[] holdBreath;
    public Sprite[] breatheOut;

    public int spriteChoice;

    public bool mainMenu;
    public bool house;
    public bool bubble;
    public bool anger;

    public bool delete;
    public bool ok;


    public float swapTime;
    public float swapRate;

    public bool smolInstruction;
    public bool bigInstruction;

    public Vector3 startPos;
    public Vector3 inactPos;

    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {


        if (bubble == true)
        {
            if (breath.GetComponent<ringGrow>().instructionStep == 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            }
            if (breath.GetComponent<ringGrow>().instructionStep == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = breatheIn[spriteChoice];
            }
            if (breath.GetComponent<ringGrow>().instructionStep == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = holdBreath[spriteChoice];
            }
            if (breath.GetComponent<ringGrow>().instructionStep == 3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = breatheOut[spriteChoice];
            }

            swapTime += Time.deltaTime;

            if (swapTime >= swapRate)
            {
                spriteChoice++;
                swapTime = 0;
            }

            if (spriteChoice >= 3)
            {
                spriteChoice = 0;
            }

        }


        if (anger == true)
        {

            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];


            if (smolInstruction == true)
            {
                if (gameManager.GetComponent<miniGameManager>().state == GameState.DRAWING || gameManager.GetComponent<miniGameManager>().state == GameState.STARTING)
                {
                    if (delete == false || ok == false)
                    {
                        transform.position = startPos;
                        swapTime += Time.deltaTime;

                        if (swapTime >= swapRate)
                        {
                            spriteChoice++;
                            swapTime = 0;
                        }

                        if (spriteChoice >= 3)
                        {
                            spriteChoice = 0;
                        }
                    }

                    if (delete == true)
                    {
                        if (deleteButton.GetComponent<jiggle>().hoverOver == true)
                        {
                            Debug.Log("wigglewiggle");
                            transform.position = startPos;
                            swapTime += Time.deltaTime;

                            if (swapTime >= swapRate)
                            {
                                spriteChoice++;
                                swapTime = 0;
                            }

                            if (spriteChoice >= 3)
                            {
                                spriteChoice = 0;
                            }
                        }
                        if (deleteButton.GetComponent<jiggle>().hoverOver == false)
                        {
                            transform.position = inactPos;
                        }
                    }
                    if (ok == true)
                    {
                        if (okButton.GetComponent<jiggle>().hoverOver == true)
                        {
                            transform.position = startPos;
                            swapTime += Time.deltaTime;

                            if (swapTime >= swapRate)
                            {
                                spriteChoice++;
                                swapTime = 0;
                            }

                            if (spriteChoice >= 3)
                            {
                                spriteChoice = 0;
                            }
                        }
                        if (okButton.GetComponent<jiggle>().hoverOver == false)
                        {
                            transform.position = inactPos;
                        }
                    }

                }
                if (gameManager.GetComponent<miniGameManager>().state != GameState.DRAWING && gameManager.GetComponent<miniGameManager>().state != GameState.STARTING)
                {
                    transform.position = inactPos;
                }

            }

            if (bigInstruction == true)
            {
                swapTime += Time.deltaTime;

                if (swapTime >= swapRate)
                {
                    spriteChoice++;
                    swapTime = 0;
                }

                if (spriteChoice >= 3)
                {
                    spriteChoice = 0;
                }
            }
        }
    }
}
