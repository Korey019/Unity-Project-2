using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public string name;
    public int health = 100;
    public int attack;
    public int defense;

    public GameObject nameTag;

    // Start is called before the first frame update
    void Start()
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
