using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructions : MonoBehaviour
{
    public GameObject cam;

    public Sprite[] sprites;
    public int spriteChoice;

    public float swapTime;
    public float swapRate;

    void Start()
    {
        
    }


    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];


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
}
