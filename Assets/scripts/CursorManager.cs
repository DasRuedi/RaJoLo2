using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public GameObject paper;

    public Texture2D[] cursorTexture;

    public Texture2D crayonTexture;

    public int spriteChoice;

    public Vector2 cursorHotspot;

    public bool jitter;
    public float jitterTime;
    public float jitterRate;



    void Start()
    {
        cursorHotspot = new Vector2(cursorTexture[0].width / 2, cursorTexture[0].height / 2);
    }


    void Update()
    {
        if (paper.GetComponent<paperClickEvent>().drawing == false)
        {
            Cursor.SetCursor(cursorTexture[spriteChoice], cursorHotspot, CursorMode.Auto);
        }

        if (jitter == true)
        {
            jitterTime += Time.deltaTime;

            if (jitterTime >= jitterRate)
            {
                spriteChoice++;
                jitterTime = 0;
            }
            if (spriteChoice <= 1)
            {
                spriteChoice = 1;
            }
            if (spriteChoice >= cursorTexture.Length)
            {
                spriteChoice = 1;
            }
        }

        if (jitter == false)
        {
            spriteChoice = 0;
        }

        if (paper.GetComponent<paperClickEvent>().drawing == true)
        {
            Cursor.SetCursor(crayonTexture, cursorHotspot, CursorMode.Auto);
        }
    }
}
