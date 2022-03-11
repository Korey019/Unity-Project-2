using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingScript : MonoBehaviour
{
    int laps = 0;

    float curLapProgress = 0f;
    float reqLapProgress = 100f;

    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainProgress(speed);
        }
    }

    public void GainProgress(float progress)
    {
        curLapProgress += progress;
        Debug.Log("Progress gained: " + progress);
        Debug.Log("Current progress is: " + curLapProgress);
        CheckProgress(curLapProgress);
    }

    public void CheckProgress(float progress)
    {
        if (progress >= reqLapProgress)
        {
            //Completed a lap!
            LapCompleted();
            Debug.Log("We reached the required progress!");
        }
    }

    public void LapCompleted()
    {
        //update our laps
        laps += 1; //laps++;
        //reset our current lap progress to 0
        curLapProgress = 0f;
        //either, increase our required lap progress, or change our speed
        reqLapProgress *= 1.15f;
        Debug.Log("Completed a lap!");
        Debug.Log("Laps completed: " + laps);
    }
}
