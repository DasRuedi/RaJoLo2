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
            scale += Time.deltaTime * growth;
        }
        if (breatheOut == true)
        {
            if (scale > baseScale)
            {
                scale -= Time.deltaTime * growth * 1.5f;
                bubbleBubbler.GetComponent<SeifenBlas>().BlowBubbles();
            }
            if (scale <= baseScale)
            {
                scale = baseScale;
                breaths++;
                breatheOut = false;
            }
        }

        if (breatheOut == false)
        {
            if (Input.GetKey("space") || Input.GetMouseButton(0))
            {
                breatheIn = true;
            }

        }
        if (Input.GetKeyUp("space") || Input.GetMouseButtonUp(0))
        {
            breatheIn = false;
            breatheOut = true;
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
    }
}

