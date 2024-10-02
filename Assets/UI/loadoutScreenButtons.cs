using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadoutScreenButtons : MonoBehaviour
{
    public infoManager infoMan;

    public Button play;
    public Button exit;

    //color swap buttons
    public Button R;
    public Button O;
    public Button Y;
    public Button Gn;
    public Button U;
    public Button Pu;
    public Button Pi;
    public Button Gy;
    public Button B;

    public int classNum = 0;
    public Button class_R;
    public Button class_L;

    public Image currentSprite;
    public Image[] wheelSprites;
    public Sprite[] classes;
    public GameObject[] classPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        infoMan = infoManager.infoMan;

        // FUCKIN BUTTONS
        play.onClick.AddListener(Play);
        exit.onClick.AddListener(Exit);
        R.onClick.AddListener(ColorR);
        O.onClick.AddListener(ColorO);
        Y.onClick.AddListener(ColorY);
        Gn.onClick.AddListener(ColorGn);
        U.onClick.AddListener(ColorU);
        Pu.onClick.AddListener(ColorPu);
        Pi.onClick.AddListener(ColorPi);
        Gy.onClick.AddListener(ColorGy);
        B.onClick.AddListener(ColorB);
        class_R.onClick.AddListener(ChangeClassR);
        class_L.onClick.AddListener(ChangeClassL);

        // Set Colors and Sprites
        infoMan.playerClass = classPrefabs[classNum];
        currentSprite.sprite = classes[classNum];

        currentSprite.color = colorManager.colorMan.colors[infoMan.color];
        for (int x = 0; x < wheelSprites.Length; x++)
        {
            wheelSprites[x].color = colorManager.colorMan.colors[x];
            wheelSprites[x].transform.Rotate(new Vector3(0,0,-40*x));
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Menu navigation
    void Play()
    {
        SceneManager.LoadScene(2);
    }
    void Exit()
    {
        SceneManager.LoadScene(0);
    }


    void ColorR()
    {
        currentSprite.color = colorManager.colorMan.colors[0];
        infoMan.color = 0;
    }
    void ColorO()
    {
        currentSprite.color = colorManager.colorMan.colors[1];
        infoMan.color = 1;
    }
    void ColorY()
    {
        currentSprite.color = colorManager.colorMan.colors[2];
        infoMan.color = 2;
    }
    void ColorGn()
    {
        currentSprite.color = colorManager.colorMan.colors[3];
        infoMan.color = 3;
    }
    void ColorU()
    {
        currentSprite.color = colorManager.colorMan.colors[4];
        infoMan.color = 4;
    }
    void ColorPu()
    {
        currentSprite.color = colorManager.colorMan.colors[5];
        infoMan.color = 5;
    }
    void ColorPi()
    {
        currentSprite.color = colorManager.colorMan.colors[6];
        infoMan.color = 6;
    }
    void ColorGy()
    {
        currentSprite.color = colorManager.colorMan.colors[7];
        infoMan.color = 7;
    }
    void ColorB()
    {
        currentSprite.color = colorManager.colorMan.colors[8];
        infoMan.color = 8;
    }


    void ChangeClassR()
    {
        if (classNum < classes.Length-1)
        {
            classNum++;
        }
        else
        {
            classNum = 0;
        }
        infoMan.playerClass = classPrefabs[classNum];
        currentSprite.sprite = classes[classNum];
    }
    void ChangeClassL()
    {
        if (classNum > 0)
        {
            classNum--;
        }
        else
        {
            classNum = classes.Length-1;
        }
        infoMan.playerClass = classPrefabs[classNum];
        currentSprite.sprite = classes[classNum];
    }
}
