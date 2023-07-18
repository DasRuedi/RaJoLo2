using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shade : MonoBehaviour
{
    public GameObject cam;

    public bool room1;
    public bool room2;
    public bool room3;
    public bool room4;

    public Vector3 startPos;
    public Vector3 inactPos;


    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {
        if (cam.GetComponent<cameraMovement>().onStart == true)
        {
            transform.position = startPos;
        }
        if (cam.GetComponent<cameraMovement>().onStart == false)
        {
            if (room1 == true)
            {
                if (cam.GetComponent<cameraMovement>().inRoom1 == true)
                {
                    transform.position = inactPos;
                }
                if (cam.GetComponent<cameraMovement>().inRoom1 == false)
                {
                    transform.position = startPos;
                }
            }
            if (room2 == true)
            {
                if (cam.GetComponent<cameraMovement>().inRoom2 == true)
                {
                    transform.position = inactPos;
                }
                if (cam.GetComponent<cameraMovement>().inRoom2 == false)
                {
                    transform.position = startPos;
                }
            }
            if (room3 == true)
            {
                if (cam.GetComponent<cameraMovement>().inRoom3 == true)
                {
                    transform.position = inactPos;
                }
                if (cam.GetComponent<cameraMovement>().inRoom3 == false)
                {
                    transform.position = startPos;
                }
            }
            if (room4 == true)
            {
                if (cam.GetComponent<cameraMovement>().inRoom4 == true)
                {
                    transform.position = inactPos;
                }
                if (cam.GetComponent<cameraMovement>().inRoom4 == false)
                {
                    transform.position = startPos;
                }
            }
        }
    }
}
