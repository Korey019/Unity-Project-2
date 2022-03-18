using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{

    public string name;
    public int health = 100;
    public int attack;
    public int defense;

    public GameObject nameTag;

    // Awake is called before start, it bascially interrupts any current Start functions
    // This lets us generate our stats in the middle of being added to a team
    //Otherwise our stats would remain at 0
    void Awake()
    {
        InitStats();
    }

    private void InitStats()
    {
        attack = Random.Range(5, 20);
        defense = Random.Range(5, 20);
    }

    public void UpdateName(string newName)
    {
        name = newName;
        nameTag.GetComponent<TextMesh>().text = name;
    }
}
