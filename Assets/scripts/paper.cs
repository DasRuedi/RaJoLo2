using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paper : MonoBehaviour
{
    public GameObject bat;
    public GameObject paperAndLines;
    public GameObject objectToDestroy;

    public int dissapear;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bat.GetComponent<bat>().hits < dissapear && objectToDestroy.GetComponent<objectToDestroy>().reset == false)
        {
            paperAndLines.SetActive(true);
        }
        if (bat.GetComponent<bat>().hits >= dissapear)
        {
            paperAndLines.SetActive(false);
        }
    }
}
