using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] enemy;
    public Transform boss;

    public static bool bossSpawned = false;
    public static bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        bossSpawned = false;
        isSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Game.gameTime >= Game.levelTime && !bossSpawned)
        {
            CancelInvoke();
            Instantiate(boss, new Vector3(9.5f, 0, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
            bossSpawned = true;
            isSpawning = false;
        }
        if(Game.gameTime < Game.levelTime && !isSpawning)
        {
            if(Game.level<10) InvokeRepeating("Spawn", 0, 1-Game.level * 0.1f);
            else InvokeRepeating("Spawn", 0, 0.1f);
            isSpawning = true;
        }
    }

    void Spawn()
    {
        Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(9.5f, Random.Range(-4.5f, 4.5f), 0), Quaternion.Euler(new Vector3(0, 0, 90)));
    }
}
