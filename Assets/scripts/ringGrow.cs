using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ringGrow : MonoBehaviour
{
    public GameObject bubbleBubbler;

    public float growth;
    public float scale;
    public float baseScale;

    public bool breatheIn;
    public bool breatheOut;

    public float limit;

    public GameObject ringEffect;
    public bool effect;
    public int effectRate;

    public int breaths;

    public bool bubblable;

    public float breathTime;
    public float holdTime;
    public float blowTime;

    public int instructionStep;


    void Start()
    {
        baseScale = transform.localScale.x;
        scale = baseScale;
    }


    void Update()
    {
        transform.localScale = new Vector3(scale,scale,scale);

        if (breatheIn == true)
        {
            if (scale < limit)
            {
                scale += Time.deltaTime * growth;
                breathTime += Time.deltaTime;
            }
            if (scale >= limit)
            {
                scale += Time.deltaTime * (growth / 3f);
                holdTime += Time.deltaTime;
            }

        }
        if (breatheOut == true)
        {
            
            if (scale > baseScale)
            {
                scale -= Time.deltaTime * growth * 0.8f;
                blowTime += Time.deltaTime;
                bubbleBubbler.GetComponent<SeifenBlas>().BlowBubbles();

            }
            if (scale <= baseScale)
            {
                scale = baseScale;
                breaths++;
                breathTime = 0;
                holdTime = 0;
                breatheOut = false;
            }
        }

        if (breatheOut == false)
        {
            if (bubblable == true)
            {
                if (Input.GetKey("space") || Input.GetMouseButton(0))
                {
                    breatheIn = true;
                    blowTime = 0;
                }
            }

        }
        if (Input.GetKeyUp("space") || Input.GetMouseButtonUp(0))
        {
            breatheIn = false;
            breatheOut = true;
            FindObjectOfType<AudioManager>().Play("Wind3");
            FindObjectOfType<AudioManager>().Play("bubble");
        }



        if (scale >= limit)
        {
            if (breatheIn == true)
            {
                if (effect == true)
                {
                    effectRate = Random.Range(3, 6);

                    for (int i = 0; i < effectRate; i++)
                    {
                        Instantiate(ringEffect, transform.position, Quaternion.identity);
                    }
                }
                effect = false;
            }
        }

        if (scale < limit)
        {
            if (breatheIn == false)
            {
                effect = true;
            }
        }

        if (bubblable == true)
        {
            if (breatheIn == false && breatheOut == false)
            {
                instructionStep = 1;
            }

            if (breatheIn == true)
            {
                if (holdTime < 3.5f)
                {
                    instructionStep = 2;
                }
                if (holdTime >= 3.5f)
                {
                    instructionStep = 3;
                }
            }
        }
    }
}

