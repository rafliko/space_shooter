using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject bg1, bg2;

    // Update is called once per frame
    void Update()
    {
        bg1.transform.position += Vector3.left * 0.01f;
        bg2.transform.position += Vector3.left * 0.01f;
        if (bg1.transform.position.x <= -32f)
        {
            bg1.transform.position = new Vector3(49.92f,0f,0f);
        }
        if (bg2.transform.position.x <= -32f)
        {
            bg2.transform.position = new Vector3(49.92f, 0f, 0f);
        }
    }
}
