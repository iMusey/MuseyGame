﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visualMenu : MonoBehaviour
{
    public Image back;

    // Start is called before the first frame update
    void Start()
    {
        back.color = colorManager.colorMan.getColor(colorManager.colorMan.colors[0], 3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
