using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public int shootChance;
    public Transform laser;
    public GameObject explosion;
    Vector3 dir = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        speed += Game.level * 0.3f;
        shootChance += Game.level * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x <= 7f && Game.bossImmune)
        {
            dir = Vector3.up;
            InvokeRepeating("Shoot", 0, 0.5f);
            Game.bossImmune = false;
        }
        if(!Game.bossImmune)
        {
            if (transform.position.y >= 4.5f)
                dir = Vector3.down;
            if (transform.position.y <= -4.5f)
                dir = Vector3.up;
        }
        if(Game.bossHealth == 0)
        {
            Game.score += 200;
            Game.level++;
            Game.playerHealth++;
            Game.gameTime = 0;
            Spawner.bossSpawned = false;
            Game.bossHealth = Game.bossMaxHealth;
            Game.bossImmune = true;
            var exp = Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            exp.transform.localScale = new Vector3(2,2,1);
            Destroy(gameObject);
        }
        transform.position += dir * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, collision.gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            Destroy(collision.gameObject);
            Game.playerDestroyed = true;
            Game.playerHealth--;
            Game.bossHealth--;
        }
    }

    void Shoot()
    {
        if (Random.Range(0f, 1f) < shootChance / 100f)
        {
            Instantiate(laser, new Vector3(transform.position.x - 1.7f, transform.position.y+1f, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
            Instantiate(laser, new Vector3(transform.position.x - 1.7f, transform.position.y-1f, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        }
    }
}
