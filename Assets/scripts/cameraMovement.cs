using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float speed;

    public float limitX;
    public float limitY;

    public Vector3 currPos;
    public Vector3 startPos;

    public Vector3 room1;
    public Vector3 room2;
    public Vector3 room3;
    public Vector3 room4;

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
            if (transform.position.y < currPos.y + limitY)
            {
                transform.Translate(Vector3.up * Time.deltaTime * speed);
            }
            if (transform.position.y >= currPos.y + limitY)
            {
                transform.position = new Vector3(transform.position.x, currPos.y + limitY, transform.position.z);
            }
        }
        if (Input.GetKey("s"))
        {
            if (transform.position.y > currPos.y - limitY)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
            }
            if (transform.position.y <= currPos.y - limitY)
            {
                transform.position = new Vector3(transform.position.x, currPos.y - limitY, transform.position.z);
            }
        }
        if (Input.GetKey("a"))
        {
            if (transform.position.x > currPos.x - limitX)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            if (transform.position.x <= currPos.x - limitX)
            {
                transform.position = new Vector3(currPos.x - limitX, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey("d"))
        {
            if (transform.position.x < currPos.x + limitX)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            if (transform.position.x >= currPos.x + limitX)
            {
                transform.position = new Vector3(currPos.x + limitX, transform.position.y, transform.position.z);
            }
        }
        if (Input.GetKey("q"))
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

        if (onStart == true)
        {
            if (transform.position != startPos && repos == true)
            {
                transform.position = startPos;
                currPos = startPos;
                repos = false;
            }
        }

        if (inRoom1 == true)
        {
            if (transform.position != room1 && repos == true)
            {
                transform.position = room1;
                currPos = room1;
                repos = false;
            }
        }

        if (inRoom2 == true)
        {
            if (transform.position != room2 && repos == true)
            {
                transform.position = room2;
                currPos = room2;
                repos = false;
            }
        }
        if (inRoom3 == true)
        {
            if (transform.position != room3 && repos == true)
            {
                transform.position = room3;
                currPos = room3;
                repos = false;
            }
        }
        if (inRoom4 == true)
        {
            if (transform.position != room4 && repos == true)
            {
                transform.position = room4;
                currPos = room4;
                repos = false;
            }
        }
    }
}
