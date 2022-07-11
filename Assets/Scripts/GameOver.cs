using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button retry;
    public Button exit;
    public Text score_t;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = Game.mvol;
        retry.GetComponent<Button>().onClick.AddListener(RetryClick);
        exit.GetComponent<Button>().onClick.AddListener(ExitClick);
        score_t.text = "Score:  "+Game.score.ToString();
        Cursor.visible = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
    }

    void RetryClick()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }

    void ExitClick()
    {
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }
}
