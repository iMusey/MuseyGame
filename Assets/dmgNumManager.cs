using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgNumManager : MonoBehaviour
{
    public static dmgNumManager dNumMan;
    public GameObject dNumPfab;
    public GameObject canvas;

    void Awake()
    {
        dNumMan = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject dmgNum(string dmg, bool crt, float spd, float life, Vector3 pos)
    {
        dmgNum dNum = Instantiate(dNumPfab).GetComponentInChildren<dmgNum>();
        dNum.lifeTime = life;
        dNum.crit = crt;
        dNum.text.text = dmg;
        dNum.transform.position = pos;
        dNum.transform.parent = canvas.transform;

        return dNum.gameObject;
    }
}
