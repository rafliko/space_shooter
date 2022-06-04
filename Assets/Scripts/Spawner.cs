using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] enemy;
    public Transform boss;

    public static bool bossSpawned = false;

    // Start is called before the first frame update
    void Start()
    { 

    }

    // Update is called once per frame
    void Update()
    {
        if(Game.gameTime >= Game.levelTime && !bossSpawned)
        {
            CancelInvoke();
            Instantiate(boss, new Vector3(9.5f, 0, 0), Quaternion.Euler(new Vector3(0, 0, 90)));
            bossSpawned = true;
        }
        if(Game.gameTime==0)
        {
            InvokeRepeating("Spawn", 0, 1);
        }
    }

    void Spawn()
    {
        Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(9.5f, Random.Range(-4.5f, 4.5f), 0), Quaternion.Euler(new Vector3(0, 0, -90)));
    }
}
