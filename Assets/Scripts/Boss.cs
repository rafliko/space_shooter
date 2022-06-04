using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    public int shootChance;
    public Transform laser;
    Vector3 dir = Vector3.left;

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
            Destroy(gameObject);
        }
        transform.position += dir * Time.deltaTime * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-8.5f, 0f, 0f);
            Game.playerHealth--;
            Game.bossHealth--;
        }
    }

    void Shoot()
    {
        if (Random.Range(1, 100 / shootChance + 1) == 1)
        {
            Instantiate(laser, new Vector3(transform.position.x - 1.7f, transform.position.y+1f, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
            Instantiate(laser, new Vector3(transform.position.x - 1.7f, transform.position.y-1f, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
        }
    }
}
