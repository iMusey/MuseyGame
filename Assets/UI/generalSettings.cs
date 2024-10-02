using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generalSettings : MonoBehaviour
{
    public Image back;

    public Button resume;
    public Button restart;
    public Button loadoutSelect;
    public Button mainMenu;
    public Button desktop;

    // Start is called before the first frame update
    void Start()
    {
        back.color = colorManager.colorMan.getColor(colorManager.colorMan.colors[4], 3);

        resume.onClick.AddListener(Resume);
        restart.onClick.AddListener(Restart);
        loadoutSelect.onClick.AddListener(LoadoutSelect);
        mainMenu.onClick.AddListener(MainMenu);
        desktop.onClick.AddListener(Desktop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Resume()
    {
        pauseMenu.pMenu.Pause();
    }
    void Restart()
    {

    }
    void LoadoutSelect()
    {

    }
    void MainMenu()
    {

    }
    void Desktop()
    {

    }
}
