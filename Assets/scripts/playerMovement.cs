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



    public bool idle;

    public bool angryIdle;
    public bool afraidIdle;
    public bool sadIdle;
    public bool shameIdle;

    public bool angryWalk;
    public bool sadWalk;
    public bool shameWalk;

    public bool climbDown;
    public bool climbUp;



    // Start is called before the first frame update
    void Start()
    {
        orientation = transform.localScale.x;

        transform.localScale = new Vector3(-orientation, orientation, orientation);
    }

    // Update is called once per frame
    void Update()
    {
        GetAnim();

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
                    // Hier wird Idle ersetzt durch die erste Animation
                    // Idle -> clumbUp
                    if(idle == true)
                    {
                        climbUp = true;
                        idle = false;
                    }

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

            if (isMoving == false && currRoom == 1)
            {
                // hier wird von der ersten zur zweiten animation gewechselt
                // climbUp -> afraidIdle
                if(climbUp == true)
                {
                    afraidIdle = true;
                    climbUp = false;
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
                        // Hier wird Idle ersetzt durch die erste Animation
                        // In diesem Fall kommt Nora von oben
                        // Idle -> climbDown
                        if(idle == true)
                        {
                            climbDown = true;
                            idle = false;
                        }

                        transform.position = enterRoom2a;
                        isMoving = true;
                    }
                    if (currRoom != 1 && currRoom != 2)
                    {
                        // Hier wird Idle ersetzt durch die erste Animation
                        // In diesem Fall kommt Nora von rechts
                        // Idle -> angryWalk
                        if(idle == true)
                        {
                            angryWalk = true;
                            idle = false;
                        }

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
            if (isMoving == false && currRoom == 2)
            {
                // hier wird von der ersten zur zweiten animation gewechselt

                // Nora kommt von oben?
                // climbDown -> angryIdle
                if(climbDown == true)
                {
                    angryIdle = true;
                    climbDown = false;
                }

                // Nora kommt von rechts?
                // angryWalk -> angryIdle
                if(angryWalk == true)
                {
                    angryIdle = true;
                    angryWalk = false;
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
                    
                    // Hier wird Idle ersetzt durch die erste Animation
                    // Idle -> sadWalk (?)

                    /*
                    if(idle == true)
                    {
                        sadWalk = true;
                        idle = false;
                    }
                    */

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

            /*
            if (isMoving == false && currRoom == 1)
            {
                // hier wird von der ersten zur zweiten animation gewechselt
                // sadWalk -> sadIdle

                if(sadWalk == true)
                {
                    sadIdle = true;
                    sadWalk = false;
                }
            }
            */
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
                        // Hier wird Idle ersetzt durch die erste Animation
                        // In diesem Fall kommt Nora von oben
                        // Idle -> shameWalk

                        /*
                        if(idle == true)
                        {
                            shameWalk = true;
                            idle = false;
                        }
                        */

                        // egal ob oben oder unten, die animation ist bei beiden Fällen gleich

                        transform.position = enterRoom4a;
                        isMoving = true;
                    }
                    if (currRoom == 3)
                    {
                        // Hier wird Idle ersetzt durch die erste Animation
                        // In diesem Fall kommt Nora von unten
                        // Idle -> shameWalk

                        /*
                        if(idle == true)
                        {
                            shameWalk = true;
                            idle = false;
                        }
                        */

                        // egal ob oben oder unten, die animation ist bei beiden Fällen gleich

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

            /*
            if (isMoving == false && currRoom == 1)
            {
                // hier wird von der ersten zur zweiten animation gewechselt
                // shameWalk -> shameIdle

                if(sadWalk == true)
                {
                    shameIdle = true;
                    shameWalk = false;
                }
            }
            */
        }

    }

    public void GetAnim()
    {
        if(idle == true)
        {
            anim.SetBool("Idle", true);
            anim.SetBool("angry", false);
            anim.SetBool("afraid", false);
            anim.SetBool("redwalk", false);
            anim.SetBool("redClimb", false);
            anim.SetBool("purpleClimb", false);
        }

        if(angryIdle == true)
        {
            anim.SetBool("angry", true);
            anim.SetBool("redClimb", false);
            anim.SetBool("redwalk", false);
            anim.SetBool("Idle", false);
        }

        if(afraidIdle == true)
        {
            anim.SetBool("afraid", true);
            anim.SetBool("Idle", false);
            anim.SetBool("purpleClimb", false);
        }

        if(sadIdle == true)
        {
            /*
            anim.SetBool("???", true);
            anim.SetBool("???", false);
            */
        }

        if(shameIdle == true)
        {
            /*
            anim.SetBool("???", true);
            anim.SetBool("???", false);
            */
        }

        if(angryWalk == true)
        {
            anim.SetBool("redwalk", true);
            anim.SetBool("Idle", false);
        }

        if(sadWalk == true)
        {
            /*
            anim.SetBool("???", true);
            anim.SetBool("???", false);
            */
        }

        if(shameWalk == true)
        {
            /*
            anim.SetBool("???", true);
            anim.SetBool("???", false);
            */
        }

        if(climbDown == true)
        {
            anim.SetBool("redClimb", true);
            anim.SetBool("Idle", false);
        }
        if (climbUp == true)
        {
            anim.SetBool("purpleClimb", true);
            anim.SetBool("Idle", false);
        }



    }

    public void ResetAnim()
    {
        idle = true;
        angryIdle = false;
        afraidIdle = false;
        sadIdle = false;
        shameIdle = false;
        angryWalk = false;
        sadWalk = false;
        shameWalk = false;
        climbDown = false;
        climbUp = false;
    }
}
