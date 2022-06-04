using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Slider progress;
    public Text lives;
    public Text score_t;
    public Text level_t;

    public static int bossHealth = 40;
    public static int bossMaxHealth = 40;
    public static bool bossImmune = true;
    public static float gameTime = 0f;
    public static int playerHealth = 3;
    public static int score = 0;
    public static float levelTime = 20f;
    public static int level = 1;


    void Start()
    {
        gameTime = 0f;
        playerHealth = 3;
        bossHealth = bossMaxHealth;
        score = 0;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        lives.text = "Lives:  " + playerHealth;
        score_t.text = "Score:  " + score.ToString();
        level_t.text = "Level:  " + level.ToString();

        if (gameTime < levelTime) progress.GetComponent<Slider>().value = gameTime / levelTime;
        else progress.GetComponent<Slider>().value = bossHealth / (float)bossMaxHealth;
        
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
        }
    }
}
