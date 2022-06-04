using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    float speed = 12;
    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        if (name == "laserBlue(Clone)") dir = Vector3.right;
        if (name == "laserRed(Clone)") dir = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
        if (transform.position.x > 8.5f || transform.position.x < -8.5f) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && name == "laserBlue(Clone)")
        {
            Game.score += 10;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player" && name == "laserRed(Clone)")
        {
            Game.playerHealth--;
            collision.gameObject.transform.position = new Vector3(-8.5f, 0f, 0f);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "boss" && name == "laserBlue(Clone)")
        {
            if (!Game.bossImmune) Game.bossHealth--;
            Destroy(gameObject);
        }
    }
}
