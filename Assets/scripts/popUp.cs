using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour
{

    public GameObject cam;
    public GameObject roomManager;

    public bool onGround;
    public bool onCeiling;
    public bool onWall;

    public bool inRoom1;
    public bool inRoom2;
    public bool inRoom3;
    public bool inRoom4;

    public float startRotation;
    public float endRotation;
    public float rotationSpeed;

    public bool flip;

    Vector3 startPos;
    public Vector3 inactivePos;

    public float currScale;
    public float endScale;
    public float growSpeed;

    public bool reset;


    void Start()
    {
        startPos = transform.position;
        currScale = 0;
    }


    void Update()
    {

        transform.localScale = new Vector3(transform.localScale.x, currScale, transform.localScale.z);


        if (cam.GetComponent<cameraMovement>().onStart == true || roomManager.GetComponent<roomClick>().entering == true)
        {
            if (reset == true)
            {
                Reset();
            }
        }

        if (inRoom1 == true)
        {
            if (cam.GetComponent<cameraMovement>().inRoom1 == true)
            {
                transform.position = startPos;
                flip = true;
                Flipping();
                EndFlip();
            }
            if (cam.GetComponent<cameraMovement>().inRoom1 == false)
            {
                transform.position = inactivePos;
                reset = true;
            }
        }
        if (inRoom2 == true)
        {
            if (cam.GetComponent<cameraMovement>().inRoom2 == true)
            {
                transform.position = startPos;
                flip = true;
                Flipping();
                EndFlip();
            }
            if (cam.GetComponent<cameraMovement>().inRoom2 == false)
            {
                transform.position = inactivePos;
                reset = true;
            }
        }
        if (inRoom3 == true)
        {
            if (cam.GetComponent<cameraMovement>().inRoom3 == true)
            {
                transform.position = startPos;
                flip = true;
                Flipping();
                EndFlip();
            }
            if (cam.GetComponent<cameraMovement>().inRoom3 == false)
            {
                transform.position = inactivePos;
                reset = true;
            }
        }
        if (inRoom4 == true)
        {
            if (cam.GetComponent<cameraMovement>().inRoom4 == true)
            {
                transform.position = startPos;
                flip = true;
                Flipping();
                EndFlip();
            }
            if (cam.GetComponent<cameraMovement>().inRoom4 == false)
            {
                transform.position = inactivePos;
                reset = true;
            }
        }


    }
    public void Flipping()
    {
        if (flip == true)
        {
            if (onGround == true)
            {
                if (transform.rotation.x < endRotation)
                {
                    transform.Rotate(new Vector3(rotationSpeed, 0, 0) * Time.deltaTime);
                }
            }

            if (onCeiling == true)
            {
                if (transform.rotation.x > endRotation)
                {
                    transform.Rotate(new Vector3(-rotationSpeed, 0, 0) * Time.deltaTime);
                }

            }

            if (currScale < endScale)
            {
                currScale += Time.deltaTime * growSpeed;
            }
            if (currScale >= endScale)
            {
                currScale = endScale;
            }

        }
    }
    public void EndFlip()
    {

        if (onGround == true)
        {
            if (transform.rotation.x >= endRotation)
            {
                transform.eulerAngles = new Vector3(endRotation, 0, 0);

                if (flip == true)
                {
                    flip = false;
                }
            }
        }

        if (onCeiling == true)
        {
            if (transform.rotation.x <= endRotation)
            {
                transform.eulerAngles = new Vector3(endRotation, 0, 0);

                if (flip == true)
                {
                    flip = false;
                }
            }
        }
    }

    public void Reset()
    {
        transform.position = inactivePos;
        transform.eulerAngles = new Vector3(startRotation, 0, 0);
        currScale = 0;
        flip = false;

        if (roomManager.GetComponent<roomClick>().entering == true)
        {
            Debug.Log("resetting");
            roomManager.GetComponent<roomClick>().resetObjects++;
        }
        reset = false;
    }
}
