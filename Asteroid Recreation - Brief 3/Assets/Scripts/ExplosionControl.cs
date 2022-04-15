using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControl : MonoBehaviour
{

    public GameObject explosion;
    public int PlayParticle;

    void OnEnable()
    {

        EventManager.OnImpact += PlayParticle;

    }


    void PlaceExplosion(Vector3 location)
    {
        Instantiate(explosion, location, this.transform.rotation);
    }
}