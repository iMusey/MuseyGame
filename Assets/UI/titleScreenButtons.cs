using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleScreenButtons : MonoBehaviour
{
    public Button titlePlay;

    // Start is called before the first frame update
    void Start()
    {
        titlePlay.onClick.AddListener(LoadSelectScreen);
    }

    void LoadSelectScreen()
    {
        SceneManager.LoadScene(1);
    }
}
