using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breatheIcon : MonoBehaviour
{
    public Sprite[] sprites;
    public int spriteChoice;

    public GameObject breath;

    void Start()
    {
        
    }

    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];

        if (breath.GetComponent<ringGrow>().breatheIn == true)
        {
            spriteChoice = 1;
        }
        if (breath.GetComponent<ringGrow>().breatheOut == true)
        {
            spriteChoice = 2;
        }
        if (breath.GetComponent<ringGrow>().breatheIn == false && breath.GetComponent<ringGrow>().breatheOut == false)
        {
            spriteChoice = 0;
        }
    }
}
