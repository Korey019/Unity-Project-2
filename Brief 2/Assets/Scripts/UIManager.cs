using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider[] hpBars;
    private List<Stats> charStats;

    private void Awake()
    {
        //create our list so it's not null
        charStats = new List<Stats>();
    }
    public void AssignBars(GameObject[] incTeam)
    {
        //assign the UI bars to the stats scripts so the positions march
        for(int i = 0; i < incTeam.Length; i++)
        {
            charStats.Add(incTeam[i].GetComponent<Stats>());
        }
    }

    public void UpdateBars()
    {
        for (int i = 0; i < hpBars.Length; i++)
        {
            //sliders value between o.of and 1.0f. So we need to make a float
            float percent = charStats[i].health / 100f;
            hpBars[i].value = percent;
        }
    }
}
  