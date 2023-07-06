using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moodIcon : MonoBehaviour
{
    public Sprite[] sprites;

    public int spriteChoice;

    public int progress;

    public int progressRate;

    public bool enough;

    void Start()
    {
        
    }



    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];

        if (progress >= progressRate && progress < progressRate * 2)
        {
            spriteChoice++;
            progress = 0;
        }

        if (spriteChoice >= sprites.Length)
        {
            enough = true;
            spriteChoice = sprites.Length -1;
        }
    }
}
