using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        prep,
        pick,
        fight,
        result,
        victory
    }
    public GameState gState;
    public GameObject prefab;
    public TextBox textBox;
    private string message;
    private bool simulate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (simulate)
        {
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
                    Debug.Log("Picking fighters");
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.fight));
                    break;
                case GameState.fight:
                    //if(RandomFighterA.Stats.Health > 0 && RandomFighterB.Stats.Health > 0)
                    //Both are alive, keep fighting
                    //Else one of them is dead, check which one, and print the winner to the results
                    //Might be good to set message to be the attacks and health.
                    //A tip: message = "some random info" then call SendMessage so you can then send another
                    //line by setting message ="new info again.
                    //you can put as many phases as you like, consider how much code you're writing
                    if (Random.Range(1, 20) >= 15)
                    {
                        message = "Fight has ended";
                        StartCoroutine(TransitionTimer(2f, GameState.result));
                    }
                    else
                    {
                        message = "Fighting";
                        StartCoroutine(TransitionTimer(2f, GameState.fight));
                    }
                    Debug.Log(message);
                    textBox.NewMessage(message);
                    break;
                case GameState.result:
                    Debug.Log("Results are in!");
                    textBox.NewMessage(message);
                    StartCoroutine(TransitionTimer(2f, GameState.victory));
                    break;
                case GameState.victory:
                    Debug.Log("And the winner is...");
                    textBox.NewMessage(message);
                    break;
            }
        }
    }

    IEnumerator TransitionTimer(float delay, GameState newState)
    {
        yield return new WaitForSeconds(delay);
        gState = newState;
        simulate = true;
    }
}
