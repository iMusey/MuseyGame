using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoManager : MonoBehaviour
{
    public static infoManager infoMan;


    // stored player info
    public GameObject player;
    public GameObject playerClass;
    public int color = 0;

    private void Awake()
    {
        infoMan = this;
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
