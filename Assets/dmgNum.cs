using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class dmgNum : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool crit;

    public float speed;
    public float lifeTime;
    public float life;

    // Start is called before the first frame update
    void Start()
    {
        life = lifeTime;
        if (crit)
        {
            text.color = colorManager.colorMan.colors[2];
            text.fontStyle = FontStyles.Bold;
            text.gameObject.transform.localScale *= 1.25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;

        Color currColor = text.color;
        currColor.a = life / lifeTime;
        text.color = currColor;

        Vector3 pos = transform.position;
        pos.y += Time.deltaTime / 2;
        transform.position = pos;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
