using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collisionData)
    {
        print("ow");
        Destroy.GameObject(Asteroid);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Rocket")
        {
            Destroy.GameObject(Asteroid);
            print("Asteroid Destroyed!");
        }
    }
}
