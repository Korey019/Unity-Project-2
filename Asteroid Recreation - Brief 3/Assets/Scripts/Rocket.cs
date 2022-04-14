Simple Asteroids Movement script;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject bullet;
    float thrust = 6f;
    float rotationSpeed = 180f;
    float MaxSpeed = 4.5f;

    Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();

    }
}
