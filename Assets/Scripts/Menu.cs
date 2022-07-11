using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject[] enemy;
    public Button start;
    public Button options;
    public Button exit;
    public Button back;
    public Canvas opts;
    public Canvas menu;
    public Slider svol_slider;
    public Slider mvol_slider;

    // Start is called before the first frame update
    void Start()
    {
        Game.svol = 1f;
        Game.mvol = 1f;
        opts.enabled = false;
        menu.enabled = true;
        start.GetComponent<Button>().onClick.AddListener(StartClick);
        options.GetComponent<Button>().onClick.AddListener(OptClick);
        back.GetComponent<Button>().onClick.AddListener(BackClick);
        exit.GetComponent<Button>().onClick.AddListener(ExitClick);
        InvokeRepeating("Spawn", 0, 1.5f);
        Cursor.visible = true;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update()
    {
        Game.svol = svol_slider.value;
        Game.mvol = mvol_slider.value;
        GetComponent<AudioSource>().volume = Game.mvol;
        if (Input.GetKeyDown(KeyCode.Escape) && opts.enabled)
        {
            opts.enabled = false;
            menu.enabled = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && menu.enabled)
        {
            Application.Quit();
        }
    }

    void StartClick()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }

    void OptClick()
    {
        menu.enabled = false;
        opts.enabled = true;
    }

    void ExitClick()
    {
        Application.Quit();
    }

    void BackClick()
    {
        menu.enabled = true;
        opts.enabled = false;
    }

    void Spawn()
    {
        Instantiate(enemy[Random.Range(0, enemy.Length)], new Vector3(10f, Random.Range(-4.5f, 4.5f), 0), Quaternion.Euler(new Vector3(0, 0, 90)));
    }
}
