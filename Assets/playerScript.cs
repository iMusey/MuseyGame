using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class playerScript : MonoBehaviour
{
    public static playerScript player;
    public Camera cam;

    // Loadout
    public GameObject playerClass;
    //public GameObject color;
    public Color color1;
    public Color color2;
    public Color color3;

    public List<itemScript> items;


    // Controls
    public KeyCode up;
    public KeyCode left;
    public KeyCode down;
    public KeyCode right;

    public KeyCode skill1;
    public KeyCode skill2;
    public KeyCode skill3;
    public KeyCode skill4;

    public KeyCode pause;
    public KeyCode menuR;
    public KeyCode menuL;

    private void Awake()
    {
        player = this;

        color1 = colorManager.colorMan.colors[infoManager.infoMan.color];
        color2 = colorManager.colorMan.getColor(color1, 2);
        color3 = colorManager.colorMan.getColor(color1, 3);

        playerClass = infoManager.infoMan.playerClass;
        GameObject tempGO = Instantiate(playerClass);
        tempGO.transform.parent = this.transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    bool ModCheck(float mod)
    {
        if (mod != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ItemPickup(GameObject item)
    {

    }
}
