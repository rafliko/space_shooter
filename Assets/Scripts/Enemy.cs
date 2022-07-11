using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int shootChance;
    public Transform laser;
    public GameObject explosion;
    Vector3 dir = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        if (name == "blue(Clone)") dir = new Vector3(-1,Random.Range(-0.2f,0.2f),0);
        speed += Game.level * 0.3f;
        shootChance += Game.level * 2;
        if(SceneManager.GetActiveScene().name != "menu") InvokeRepeating("Shoot", 0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
        if (transform.position.x < -10f) Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().name == "menu")
        {
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Game.score += 10;
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(collision.gameObject);
            Game.playerDestroyed = true;
            Destroy(gameObject);
            Game.playerHealth--;
        }
    }

    void Shoot()
    {
        if (Random.Range(0f, 1f) < shootChance/100f)
        {
            Instantiate(laser, new Vector3(transform.position.x - 1.7f, transform.position.y, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        }
    }
}
