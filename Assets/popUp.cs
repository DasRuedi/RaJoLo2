using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour
{

    public bool onGround;
    public bool onCeiling;
    public bool onWall;

    public float startRotation;
    public float endRotation;
    public float rotationSpeed;

    public bool flip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            flip = true;
        }

        if (flip == true)
        {

            if (transform.rotation.x < endRotation)
            {
                transform.Rotate(new Vector3(rotationSpeed, 0, 0) * Time.deltaTime);
            }

            if (transform.rotation.x <= endRotation)
            {
                transform.Rotate(new Vector3(endRotation, 0, 0));
            }
        }

    }
}
