using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public GameObject[] shapes;
    public int amount;
    public Material[] mats;
    public string[] tags;
    public float secDelay = 1.0f;

    private List<GameObject> spawnedObjs = new List<GameObject>();
    private bool canTick = true;
    // Update is called once per frame
    void Update()
    {
        if (canTick)
        {
            if (spawnedObjs.Count < amount)
            {
                float randX = Random.Range(-20, 20);
                float randZ = Random.Range(-20, 20);
                Vector3 pos = new Vector3(transform.position.x + randX,
                                          transform.position.y,
                                          transform.position.z + randZ);
                spawnedObjs.Add(Instantiate(shapes[Random.Range(0, shapes.Length)], pos, transform.rotation));
                int rand = Random.Range(0, mats.Length);
                Material newMat = mats[rand];
                spawnedObjs[spawnedObjs.Count - 1].tag = tags[rand];
                spawnedObjs[spawnedObjs.Count - 1].GetComponent<MeshRenderer>().material = newMat;
            }
            canTick = false;
            StartCoroutine(Timer(secDelay));
        }
        UpdateObjs();
    }

    IEnumerator Timer(float delay)
    {
        //anything here runs immediately

        //this line, creates the delay
        yield return new WaitForSeconds(delay);
        //anything here, waits the delay

        canTick = true;
        /*
        //Hint for brief 2
        int phase = 0; //0 default, setup phase
        phase++; //phase would increase, next phase might pick fighters
        if(phase == 4) //if we hit the last phaase of our battle simulator, reset it
        {
            phase = 0;
        }
        switch(phase);
        */
    } 

    private void UpdateObjs()
    {
        foreach (GameObject obj in spawnedObjs)
        {
            switch (obj.tag)
            {
                case "Orange": //Go fwd
                    obj.transform.position += Vector3.forward * Time.deltaTime;
                    break;
                case "Blue": //Go up
                    obj.transform.position += Vector3.up * Time.deltaTime;
                    break;
                case "Yellow": //Go down
                    obj.transform.position += Vector3.down * Time.deltaTime;
                    break;
                case "Green": //Grow
                    obj.transform.localScale += Vector3.one * Time.deltaTime;
                    break;
            }
        }
    }
}