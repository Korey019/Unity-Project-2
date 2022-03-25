using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject[] spawnlocs;
    public int teamSize = 3;
    public UIManager uiM;
    public GameObject[] teamA;
    public GameObject[] teamB;
    private int spawnTracker;

    private void Awake()
    {
        teamA = SetupTeam();
        teamB = SetupTeam();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Find out UI manager in our scene, if we don't, don't try to use it
        //This avoids errors if we disable our UI
        uiM = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        if(uiM != null)
        {
            uiM.AssignBars(teamA);
            uiM.AssignBars(teamB);
            uiM.UpdateBars();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //randomly picking two characters to lose health
            GameObject randA = teamA[Random.Range(0, teamA.Length)];
            GameObject randB = teamB[Random.Range(0, teamB.Length)];
            randA.GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
            randB.GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
            if(uiM != null)
            {
                //always making sure our bars are up to date visually
                uiM.UpdateBars();
            }
        }
    }

    public GameObject[] SetupTeam()
    {
        //creating a new team
        GameObject[] newTeam = new GameObject[teamSize];
        for(int i = 0; i < teamSize; i++)
        {
            //using our spawn locations to control where they spawn at
            newTeam[i] = Instantiate(prefab, spawnlocs[spawnTracker].transform.position, transform.rotation);
            spawnTracker++;
        }
        return newTeam;
    }

    public void ButtonPressed()
    {
        //if we press our UI button, randomly pick a fighter to lose hp
        if(Random.Range(0,7) >=3)
        {
            teamB[Random.Range(0, 3)].GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
        }
        else
        {
            teamA[Random.Range(0, 3)].GetComponent<Stats>().UpdateHealth(Random.Range(-20, -5));
        }
        if(uiM != null)
        {
            uiM.UpdateBars();
        }
        //you'd want this in a single function rather than two for loops
        //but this could be used to determine if a team has been defeated
        //as well as picking a fighter who is still alive
        for (int i = 0; i < teamSize; i++)
        {
            int killed = 0;
            if (teamA[i].GetComponent<Stats>().health <= 0)
            {
                killed++;
            }
            if (killed >= teamSize)
            {
                Debug.Log("Team A is defeated!");
                Application.Quit();
            }
        }
        for (int x = 0; x < teamSize; x++)
        {
            int killed = 0;
            if (teamB[x].GetComponent<Stats>().health <= 0)
            {
                //character is dead
                killed++;
            }
            else
            {
                //pick this character to fight
            }
            if (killed >= teamSize)
            {
                Debug.Log("Team B is defeated!");
                Application.Quit();
            }
        }
    }
}
