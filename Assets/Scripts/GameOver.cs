using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Button retry;
    public Text score_t;

    // Start is called before the first frame update
    void Start()
    {
        retry.GetComponent<Button>().onClick.AddListener(RetryClick);
        score_t.text = "Score:  "+Game.score.ToString();
    }

    void RetryClick()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }
}
