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


    public Sprite[] sprites;
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
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];

        if (house == true)
        {
            if (cam.GetComponent<cameraMovement>().onStart == true)
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
            if (cam.GetComponent<cameraMovement>().onStart == false)
            {
                spriteChoice = 3;
            }
        }

        if (bubble == true)
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


        if (anger == true)
        {
            if (smolInstruction == true)
            {
                if (gameManager.GetComponent<miniGameManager>().state == GameState.DRAWING)
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
                if (gameManager.GetComponent<miniGameManager>().state != GameState.DRAWING)
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
