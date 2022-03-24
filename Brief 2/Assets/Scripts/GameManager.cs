using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Enums can be anything, use your imagination!
    public enum GameState
    {
        prep,
        pick,
        fight,
        result,
        victory
    }
    //using our enum as the variable TYPE we can create a variable to track our gameState
    public GameState gState;
    public GameObject prefab;
    public TextBox textBox;
    private string message;
    private bool simulate = true;

    // Update is called once per frame
    void Update()
    {
        //don't run this every frame
        if (simulate)
        {
            //stop it so we can see each step and it's not running multiple times
            simulate = false;
            switch (gState)
            {
                case GameState.prep:
                    message = "Preparing...";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.pick));
                    break;
                case GameState.pick:
                    message = "Picking fighters";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.fight));
                    break;
                case GameState.fight:
                    //if(RandomFighterA.Stats.Health > 0 && RandomFighterB.Stats.Health > 0)
                    //Both are alive, keep fighting
                    //Else one of them is dead, check which one, and print the winner to the results
                    //Might be good to set message to be the attacks and health. 
                    //A tip: message = "some random info" then call SendMessage so you can then send another
                    //line by setting message = "new info" again.
                    //you can put as many phases as you like, consider how much code you're writing
                    if (Random.Range(1, 20) >= 15)
                    {
                        message = "Fight has ended";
                        StartCoroutine(TransitionTimer(2f, GameState.result));
                    }
                    else
                    {
                        message = "Fighting...";
                        StartCoroutine(TransitionTimer(2f, GameState.fight));
                    }
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    break;
                case GameState.result:
                    message = "Results are in!";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.victory));
                    break;
                case GameState.victory:
                    message = "And the winner is...";
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    break;
            }
        }
    }

    IEnumerator TransitionTimer(float delay, GameState newState)
    {
        //the timer takes in a delay, and what state we want to switch to
        yield return new WaitForSeconds(delay);
        //set our new state
        gState = newState;
        //let our code run again in Update
        simulate = true;
    }
}
