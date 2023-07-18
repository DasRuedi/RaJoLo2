using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class instructions : MonoBehaviour
{
    public GameObject cam;

    public Sprite[] sprites;
    public int spriteChoice;

    public bool mainMenu;
    public bool house;
    public bool bubble;
    public bool anger;


    public float swapTime;
    public float swapRate;

    public bool smolInstruction;
    public bool bigInstruction;

    void Start()
    {
        
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
