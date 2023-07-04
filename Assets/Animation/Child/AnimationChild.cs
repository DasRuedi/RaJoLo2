using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChild : MonoBehaviour
{
    public Animator childAnim;

    void Start()
    {
       
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("W");
            childAnim.SetBool("RoomEntered", true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            childAnim.SetBool("Neutral", true);
            childAnim.SetBool("RoomEntered", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            childAnim.SetBool("Neutral", false);
            childAnim.SetBool("Happy", true);
        }

    }
}
