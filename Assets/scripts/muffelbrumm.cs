using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muffelbrumm : MonoBehaviour
{
    public GameObject cam;
    public GameObject sprite;
    public GameObject bubble;

    public bool inRoom1;
    public bool inRoom2;
    public bool inRoom3;
    public bool inRoom4;

    public bool fade;

    public float fadeSpeed;

    public float alpha;

    public bool speaking;
    void Start()
    {
        
    }

    void Update()
    {
        sprite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);

        if (speaking == true)
        {
            bubble.SetActive(true);
        }
        if (speaking == false)
        {
            bubble.SetActive(false);
        }


        if (cam.GetComponent<cameraMovement>().onStart == true)
        {
            alpha = 0;
        }

        if (cam.GetComponent<cameraMovement>().inRoom1 == true)
        {
            if (inRoom1 == true)
            {
                fade = true;
            }
        }
        if (cam.GetComponent<cameraMovement>().inRoom2 == true)
        {
            if (inRoom2 == true)
            {
                fade = true;
            }
        }
        if (cam.GetComponent<cameraMovement>().inRoom3 == true)
        {
            if (inRoom3 == true)
            {
                fade = true;
            }
        }
        if (cam.GetComponent<cameraMovement>().inRoom4 == true)
        {
            if (inRoom4 == true)
            {
                fade = true;
            }
        }

        if (fade == true)
        {
            if (alpha < 1)
            {
                alpha += Time.deltaTime * fadeSpeed;
            }
            if (alpha >= 1)
            {
                alpha = 1;
            }
        }
    }
}
