using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform red;
    public Transform green;
    public Transform black;

    Transform random;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",0,1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        switch(Random.Range(0, 3))
        {
            case 0:
                random = red;
                break;
            case 1:
                random = green;
                break;
            case 2:
                random = black;
                break;
        }
        Instantiate(random, new Vector3(8.5f, Random.Range(-Global.max_y, Global.max_y), 0), Quaternion.Euler(new Vector3(0, 0, -90)));
    }
}
