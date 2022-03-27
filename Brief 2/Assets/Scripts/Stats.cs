using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int health = 100;

    public void UpdateHealth(int modifier)
    {
        health += modifier;
    }
}
