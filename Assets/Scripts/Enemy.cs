using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float speed = 3;
    public Transform laser;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
        if (transform.position.x < -Global.max_x) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("col");

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-8.5f, 0f, 0f);
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if((int)Random.Range(1,5)==1)
        {
            Instantiate(laser, new Vector3(transform.position.x - 1.7f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        }
    }
}
