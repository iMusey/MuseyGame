using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class colorManager : MonoBehaviour
{
    public static colorManager colorMan;

    public Color red;
    public Color orange;
    public Color yellow;
    public Color green;
    public Color blue;
    public Color purple;
    public Color pink;
    public Color grey;
    public Color black;
    public Color[] colors = new Color[9];

    private void Awake()
    {
        colorMan = this;
    }
        // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        colors[0] = red;
        colors[1] = orange;
        colors[2] = yellow;
        colors[3] = green;
        colors[4] = blue;
        colors[5] = purple;
        colors[6] = pink;
        colors[7] = grey;
        colors[8] = black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Color getColor(Color c, int x)
    {
        Color newC = c;
        newC = newC * Mathf.Pow(0.75f, x - 1);
        newC.a = 1;
        return newC;
    }
}
