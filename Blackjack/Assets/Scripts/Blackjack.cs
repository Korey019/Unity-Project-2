using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackjack : MonoBehaviour
{

    //variable is to store our current roll
    int myTotal = 0;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        // listen for the 'h' key to be pressed

        if (Input.GetKeyDown("h"))
        {
            //explain to the player what has happened
            print("Hit! Time to roll!");

            //call the hit function and store the return value in 'myTotal'
            myTotal = Hit();
            string printString;

            //explain to player what has happened, check for a win value
            printString = ("You rolled a " + myTotal + "\n");
                if(myTotal == 6)
            {
                printString += ("You win!");
            }
                else
            {
                printString += ("You lose!");
            }

            //print(printString);

            EventManager.GameWin(printString);
  
        }


    }
    //function to determine the value of a roll
    int Hit()
    {
        //generate a random number between 1-6

        int returnValue = Random.Range(1,7);

        //spit out a random number
        return returnValue;
    }
}
