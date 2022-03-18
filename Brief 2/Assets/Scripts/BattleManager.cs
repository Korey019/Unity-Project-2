using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject fighterPrefab;
    public int teamSize = 3;
    public string[] fighterNames;
    public GameObject[] teamAFighters;
    public GameObject[] teamBFighters;

    // Start is called before the first frame update
    void Start()
    {
        //Create our teams and call our team generator function
        teamAFighters = CreateTeam(teamAFighters);
        teamBFighters = CreateTeam(teamBFighters);
        //Randomly assign two fighters to go head to head
        GameObject randomA = teamAFighters[Random.Range(0, teamSize)];
        GameObject randomB = teamBFighters[Random.Range(0, teamSize)];
        Battle(randomA, randomB);
    }

    public GameObject[] CreateTeam(GameObject[] incTeam)
    {
        //create our team of fighters
        //spawn each fighter, and add them to our team
        incTeam = new GameObject[teamSize]; //indexes = 0, 1 and 2
        for (int i = 0; i > teamSize; i++)
        {
            //spawn the fighter (go = game object)
            GameObject go = Instantiate(fighterPrefab);
            //assign to team
            incTeam[i] = go;
            //pick a random name from our array and give it to our fighter
            go.GetComponent<Character>().UpdateName(fighterNames[Random.Range(0, fighterNames.Length)]);
        }
        //because the variable we pass through is only a copy we need to send this info back
        //from the temp variable incTeam to our actual team variable
        return incTeam;
    }

    public void Battle(GameObject fighterA, GameObject fighterB)
    {
        //coin flip simulator (0 = heads, 1 = tails)
        int coinFlip = Random.Range(0, 2);
        //assign our stats to temporary variables so it's easier to write later
        Character fAStats = fighterA.GetComponent<Character>();
        Character fBStats = fighterB.GetComponent<Character>();
        //Based on our coin flip (replace this with giving the characters a speed stat
        //and comparing who is faster, might still need coin flip for a tie!)
        if (coinFlip == 0)
        {
            //fighterB.GetComponent<Character>().health -=
            //fighterA.Component<Character>().attack -
            //fighterB.GetComponent<Character>().defense;
            //above = bad, below = good
            //Would be good to instead have a TakeDamage function on the character script
            //That way we could prevent accidental healing if defense > attack
            fBStats.health -= fAStats.attack - fBStats.defense;
            //Debug.Log the results, use as much flavour for this as you like
            //The idea is to get information that is useful to know since we can't see it
            //any other way at the moment
            Debug.Log("Fighter A attack Fighter B");
            Debug.Log("Fighter B's health is now: " + fBStats.health);
        }   
        else
        {
            fAStats.health -= fBStats.attack - fAStats.defense;
            Debug.Log("Fighter B attack Fighter B");
            Debug.Log("fighter A's health is now: " + fAStats.health);
        }
    }
}
