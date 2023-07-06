using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class objectToDestroy : MonoBehaviour
{
    public GameObject bat;
    public GameObject gameManager;
    public GameObject mood;

    public int hitsTaken;

    Vector3 startScale;
    public Vector3 currScale;

    public int damageThreshold;
    Vector3 damageScale;
    public float damageValue;
    public int destroyThreshold;
    Vector3 destroyScale;
    public float destroyValue;

    public float nextThreshold;

    public float swipeSpeed;

    public Vector3 resetPos;

    public bool reset;
    public bool repos;


    void Start()
    {
        startScale = transform.localScale;
        currScale = startScale;
        damageScale = new Vector3(startScale.x, startScale.y * damageValue, startScale.z);
        destroyScale = new Vector3(startScale.x, startScale.y * destroyValue, startScale.z);

    }


    void Update()
    {
        hitsTaken = bat.GetComponent<bat>().hits;

        transform.localScale = currScale;

        if (hitsTaken >= damageThreshold && hitsTaken < destroyThreshold)
        {
            currScale = damageScale;
        }
        if (hitsTaken >= destroyThreshold)
        {
            transform.localScale = destroyScale;
        }
        if (hitsTaken >= nextThreshold)
        {
            bat.GetComponent<bat>().canHit = false;
            transform.Translate(Vector3.left * Time.deltaTime * swipeSpeed);
        }



        if (transform.position.x <= -40)
        {
            reset = true;
            repos = true;
        }
        if (repos == true)
        {
            transform.position = resetPos;
            repos = false;
        }

        if (reset == true)
        {
            bat.GetComponent<bat>().hits = 0;
            currScale = startScale;

            if (transform.position.x > 0)
            {
                transform.Translate(Vector3.left * Time.deltaTime * swipeSpeed);
            }
            if (transform.position.x <= 0)
            {
                reset = false;
                bat.GetComponent<bat>().canHit = true;
                mood.GetComponent<moodIcon>().progress++;
            }
        }
    }
}
