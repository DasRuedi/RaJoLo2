using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoJiggle : MonoBehaviour
{
    public bool jittering;

    public Sprite[] sprites;
    public int spriteChoice;
    public float jitterTime;
    public float jitterRate;

    public bool jiggling;

    public float jiggleSpeed;
    public float jiggleTime;
    public float jiggleRate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (jittering == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[spriteChoice];
            jitterTime += Time.deltaTime;

            if (jitterTime >= jitterRate)
            {
                spriteChoice++;
                jitterTime = 0;
            }
            if (spriteChoice >= sprites.Length)
            {
                spriteChoice = 0;
            }
        }

        if (jiggling == true)
        {
            jiggleTime += Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, jiggleSpeed) * Time.deltaTime);

            if (jiggleTime >= jiggleRate)
            {
                jiggleSpeed *= -1;
                jiggleTime = 0;
            }
        }
    }
}
