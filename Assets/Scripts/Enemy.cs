using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int shootChance;
    public Transform laser;
    Vector3 dir = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        if (name == "black(Clone)") dir = new Vector3(-1,Random.Range(-0.2f,0.2f),0);
        InvokeRepeating("Shoot", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
        if (transform.position.x < -Global.max_x) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-8.5f, 0f, 0f);
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        if(Random.Range(1,100/shootChance+1)==1)
        {
            Instantiate(laser, new Vector3(transform.position.x - 1.7f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        }
    }
}
