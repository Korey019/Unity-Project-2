using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void WinAction(string printString);
    public static event WinAction OnWin;

    public static void GameWin(string printString)
    {
        OnWin(printString);
        print("EVENT FIRED: " + printString);
    }
}
