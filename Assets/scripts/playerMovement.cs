using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public bool isMoving;

    public GameObject cam;

    public bool inCurrRoom;
    public bool getRoom;

    public int currRoom;

    public Vector3 enterRoom1;
    public Vector3 enterRoom2a;
    public Vector3 enterRoom2b;
    public Vector3 enterRoom3;
    public Vector3 enterRoom4a;
    public Vector3 enterRoom4b;

    public Vector3 room1Pos;
    public Vector3 room2Pos;
    public Vector3 room3Pos;
    public Vector3 room4PosA;
    public Vector3 room4PosB;

    public float orientation = 1;

    public float speed;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        orientation = transform.localScale.x;

        transform.localScale = new Vector3(-orientation, orientation, orientation);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (cam.GetComponent<cameraMovement>().inRoom1)
        {
            if (getRoom == true)
            {
                if (currRoom == 1)
                {
                    inCurrRoom = true;
                    getRoom = false;
                }
                else
                {
                    getRoom = false;
                    inCurrRoom = false;
                }
            }

            if (inCurrRoom == false && getRoom == false)
            {
                if (isMoving == false)
                {
                    transform.position = enterRoom1;
                    isMoving = true;
                }

                if (transform.position.y < room1Pos.y && isMoving == true)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * speed);

                    if (transform.localScale.x > 0)
                    {
                        transform.localScale = new Vector3(-orientation, orientation, orientation);
                    }
                }
                if (transform.position.y >= room1Pos.y && isMoving == true)
                {
                    inCurrRoom = true;
                    isMoving = false;
                    currRoom = 1;
                }
            }
        }

        if (cam.GetComponent<cameraMovement>().inRoom2)
        {
            if (getRoom == true)
            {
                if (currRoom == 2)
                {
                    inCurrRoom = true;
                    getRoom = false;
                }
                else
                {
                    inCurrRoom = false;
                    getRoom = false;
                }
            }

            if (inCurrRoom == false && getRoom == false)
            {
                if (isMoving == false)
                {
                    if (currRoom == 1)
                    {
                        transform.position = enterRoom2a;
                        isMoving = true;
                    }
                    if (currRoom != 1 && currRoom != 2)
                    {
                        transform.position = enterRoom2b;
                        isMoving = true;
                    }
                }

                if (isMoving == true)
                {
                    if (currRoom == 1)
                    {
                        if (transform.position.y > room2Pos.y)
                        {
                            transform.Translate(Vector3.down * Time.deltaTime * speed);

                            if (transform.localScale.x > 0)
                            {
                                transform.localScale = new Vector3(-orientation, orientation, orientation);
                            }
                        }

                        if (transform.position.y <= room2Pos.y && transform.position.x <= room2Pos.x)
                        {
                            inCurrRoom = true;
                            isMoving = false;
                            anim.SetBool("redwalk", false);
                            anim.SetBool("angry", true);
                            currRoom = 2;
                          
                        }
                    }
                    if (currRoom != 1 || currRoom != 2)
                    {
                        if (transform.position.x > room2Pos.x)
                        {
                            transform.Translate(Vector3.left * Time.deltaTime * speed);

                            if (transform.localScale.x > 0)
                            {
                                transform.localScale = new Vector3(-orientation, orientation, orientation);
                            }
                        }
                        if (transform.position.x <= room2Pos.x && transform.position.y <= room2Pos.y)
                        {
                            inCurrRoom = true;
                            isMoving = false;
                            currRoom = 2;
                        }
                    }
                }
            }
        }

        if (cam.GetComponent<cameraMovement>().inRoom3)
        {
            if (getRoom == true)
            {
                if (currRoom == 3)
                {
                    inCurrRoom = true;
                    getRoom = false;
                }
                else
                {
                    getRoom = false;
                    inCurrRoom = false;
                }
            }

            if (inCurrRoom == false && getRoom == false)
            {
                if (isMoving == false)
                {
                    transform.position = enterRoom3;
                    isMoving = true;
                }

                if (transform.position.x > room3Pos.x && isMoving == true)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speed);

                    if (transform.localScale.x > 0)
                    {
                        transform.localScale = new Vector3(-orientation, orientation, orientation);
                    }
                }
                if (transform.position.x <= room3Pos.x && isMoving == true)
                {
                    inCurrRoom = true;
                    isMoving = false;
                    currRoom = 3;
                }
            }
        }

        if (cam.GetComponent<cameraMovement>().inRoom4)
        {
            if (getRoom == true)
            {
                if (currRoom == 4)
                {
                    inCurrRoom = true;
                    getRoom = false;
                }
                else
                {
                    inCurrRoom = false;
                    getRoom = false;
                }
            }

            if (inCurrRoom == false && getRoom == false)
            {
                if (isMoving == false)
                {
                    if (currRoom != 3)
                    {
                        transform.position = enterRoom4a;
                        isMoving = true;
                    }
                    if (currRoom == 3)
                    {
                        transform.position = enterRoom4b;
                        isMoving = true;
                    }
                }

                if (isMoving == true)
                {
                    if (currRoom != 3)
                    {
                        if (transform.position.x < room4PosA.x)
                        {
                            transform.Translate(Vector3.right * Time.deltaTime * speed);

                            if (transform.localScale.x < 0)
                            {
                                transform.localScale = new Vector3(orientation, orientation, orientation);
                            }
                        }

                        if (transform.position.x >= room4PosA.x && transform.position.y == room4PosA.y)
                        {
                            inCurrRoom = true;
                            isMoving = false;
                            currRoom = 4;
                        }
                    }
                    if (currRoom == 3)
                    {
                        if (transform.position.x < room4PosB.x)
                        {
                            transform.Translate(Vector3.right * Time.deltaTime * speed);

                            if (transform.localScale.x < 0)
                            {
                                transform.localScale = new Vector3(orientation, orientation, orientation);
                            }
                        }
                        if (transform.position.x >= room4PosB.x && transform.position.y == room4PosB.y)
                        {
                            inCurrRoom = true;
                            isMoving = false;
                            currRoom = 4;
                        }
                    }
                }
            }
        }

    }
}
