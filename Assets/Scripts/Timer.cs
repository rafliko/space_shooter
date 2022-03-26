using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Transform red;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",0,3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        Instantiate(red, new Vector3(8.5f, Random.Range(-Global.max_y, Global.max_y), 0), Quaternion.Euler(new Vector3(0, 0, -90)));
    }
}
