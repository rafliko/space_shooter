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

    public static int bossMaxHealth = 40;
    public static int bossHealth = bossMaxHealth;
    public static bool bossImmune = true;
    public static float gameTime = 0f;
    public static float levelTime = 20f;
    public static int playerHealth = 4;
    public static int score = 0;
    public static int level = 0;


    void Start()
    {
        bossMaxHealth = 40;
        bossHealth = bossMaxHealth;
        bossImmune = true;
        gameTime = 0f;
        levelTime = 20f;
        playerHealth = 4;
        score = 0;
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        lives.text = "Lives:  " + playerHealth;
        score_t.text = "Score:  " + score.ToString();
        level_t.text = "Level:  " + (level+1).ToString();

        if (gameTime < levelTime) progress.GetComponent<Slider>().value = gameTime / levelTime;
        else progress.GetComponent<Slider>().value = bossHealth / (float)bossMaxHealth;
        
        if(playerHealth <= 0)
        {
            SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
        }
    }
}
