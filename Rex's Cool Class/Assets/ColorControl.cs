using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ColorShuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void ColorShuffle()
        {
            this.GetComponent<Renderer>().material.color = Color.red;

        }
}
