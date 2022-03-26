using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float speed = 12;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        if (tag == "plaser") dir = Vector3.right;
        if (tag == "elaser") dir = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
        if (transform.position.x > Global.max_x) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("col");

        if (collision.gameObject.tag == "enemy" && tag=="plaser")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player" && tag=="elaser")
        {
            collision.gameObject.transform.position = new Vector3(-8.5f, 0f, 0f);
            Destroy(gameObject);
        }
    }
}
