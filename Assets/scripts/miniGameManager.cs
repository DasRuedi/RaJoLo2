using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState { STARTING, DRAWING, TRANSITION, PLAYING, PAUSE, PROCEED, END, DELETE }
public class miniGameManager : MonoBehaviour
{

    public GameState state;


    public static bool delete;

    public bool smash;
    public bool breathe;

    void Start()
    {
        if (smash == true)
        {
            state = GameState.STARTING;
        }
        if (breathe == true)
        {
            state = GameState.PLAYING;
        }
    }


    void Update()
    {
        if (state == GameState.DELETE)
        {
            delete = true;
        }
        else
        {
            delete = false;
        }

        if (state == GameState.PROCEED)
        {

            SceneManager.LoadScene("breathingGame");
        }

        if (state == GameState.END)
        {
            if (smash == true)
            {
                progressManager.angerGameDone = true;
                progressManager.comingFrom = 2;
            }

            SceneManager.LoadScene("House");
        }
    }
}
