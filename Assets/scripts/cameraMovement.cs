using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public GameObject player;

    public float baseSpeed;
    float speed;

    float limitLeft;
    float limitRight;
    float limitUp;
    float limitDown;


    public float[] limitStart;
    public float[] limit1;
    public float[] limit2;
    public float[] limit3;
    public float[] limit4;

    public Vector3 currPos;
    public Vector3 startPos;

    public Vector3 room1;
    public Vector3 room2;
    public Vector3 room3;
    public Vector3 room4a;
    public Vector3 room4b;

    public bool onStart;
    public bool inRoom1;
    public bool inRoom2;
    public bool inRoom3;
    public bool inRoom4;

    public bool repos;

    // Start is called before the first frame update
    void Start()
    {
        onStart = true;
        repos = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            if (transform.position.y < limitUp)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
            if (transform.position.y >= limitUp)
            {
                transform.position = new Vector3(transform.position.x, limitUp, transform.position.z);
            }
        }
        if (Input.GetKey("s"))
        {
            if (transform.position.y > limitDown)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            if (transform.position.y <= limitDown)
            {
                transform.position = new Vector3(transform.position.x, limitDown, transform.position.z);
            }
        }
        if (Input.GetKey("a"))
        {
            if (transform.position.x > limitLeft)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            if (transform.position.x <= limitLeft)
            {
                transform.position = new Vector3(limitLeft, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey("d"))
        {
            if (transform.position.x < limitRight)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            if (transform.position.x >= limitRight)
            {
                transform.position = new Vector3(limitRight, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey("q"))
        {
            if (player.GetComponent<playerMovement>().isMoving == false)
            {
                if (onStart == false)
                {
                    onStart = true;
                    inRoom1 = false;
                    inRoom2 = false;
                    inRoom3 = false;
                    inRoom4 = false;
                    repos = true;
                }
            }
        }

        if (onStart == true)
        {
            if (transform.position != startPos && repos == true)
            {
                transform.position = startPos;
                currPos = startPos;
                repos = false;
            }

            speed = baseSpeed * 2;

            limitLeft = limitStart[0];
            limitRight = limitStart[1];
            limitUp = limitStart[2];
            limitDown = limitStart[3];
        }



        if (inRoom1 == true)
        {
            if (transform.position != room1 && repos == true)
            {
                transform.position = room1;
                currPos = room1;
                repos = false;
            }

            speed = baseSpeed;

            limitLeft = limit1[0];
            limitRight = limit1[1];
            limitUp = limit1[2];
            limitDown = limit1[3];
        }

        if (inRoom2 == true)
        {
            if (transform.position != room2 && repos == true)
            {
                transform.position = room2;
                currPos = room2;
                repos = false;
            }

            speed = baseSpeed;

            limitLeft = limit2[0];
            limitRight = limit2[1];
            limitUp = limit2[2];
            limitDown = limit2[3];
        }
        if (inRoom3 == true)
        {
            if (transform.position != room3 && repos == true)
            {
                transform.position = room3;
                currPos = room3;
                repos = false;
            }

            speed = baseSpeed;

            limitLeft = limit3[0];
            limitRight = limit3[1];
            limitUp = limit3[2];
            limitDown = limit3[3];
        }
        if (inRoom4 == true)
        {
            if (player.GetComponent<playerMovement>().transform.position.y > -2)
            {
                if (transform.position != room4a && repos == true)
                {
                    transform.position = room4a;
                    currPos = room4a;
                    repos = false;
                }
            }
            if (player.GetComponent<playerMovement>().transform.position.y < -2)
            {
                if (transform.position != room4b && repos == true)
                {
                    transform.position = room4b;
                    currPos = room4b;
                    repos = false;
                }
            }

            speed = baseSpeed;

            limitLeft = limit4[0];
            limitRight = limit4[1];
            limitUp = limit4[2];
            limitDown = limit4[3];
        }
    }
}
