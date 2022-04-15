using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void CollisionAction(Vector3 impactPosition);
    public static event CollisionAction OnImpact;

    public static void ImpactTrigger(Vector3 impactPosition)
    {
        OnImpact(impactPosition);
        printString("EVENT FIRED: " + impactPosition.x + impactPosition.z);
    }
}
