using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button start;

    // Start is called before the first frame update
    void Start()
    {
        start.GetComponent<Button>().onClick.AddListener(StartClick);
    }

    void StartClick()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
    }
}
