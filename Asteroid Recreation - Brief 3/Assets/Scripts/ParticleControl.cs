using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    ParticleSystem myParticle;

    void OnEnable()
    {
        EventManager.OnWin += PlayParticle();
    }

    // Start is called before the first frame update
    void Start()
    {
        myParticle = this.GetComponent<ParticleSystem>();
    }


    void PlayParticle(string printString)
    {
        myParticle.Play();
    }
}