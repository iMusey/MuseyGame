using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class redItem : itemScript
{
    public GameObject[] triangles;

    public float radius;
    // true means add, false means subtract
    public bool radiusIO = true;
    public float radiusMax;
    public float radiusMin;

    public float angle;
    // true means add angle, false means subtract angle
    public bool angleLR = true;
    public float angleMax;
    public float angleMin;

    // Start is called before the first frame update
    void Start()
    {
        radiusMax = radius * 1.25f;
        radiusMin = radius * 0.5f;
        angle = 0;
        //color = colorManager.colorMan.colors[0];
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject tri in triangles)
        {
            tri.GetComponent<SpriteRenderer>().color = color;
        }
        Breath();
        AngleBob();
    }

    void Breath()
    {
        // get new radius
        if (radiusIO)
        {
            radius = Mathf.MoveTowards(radius, radiusMax, Time.deltaTime * (0.01f + (Mathf.Pow(radius - radiusMin, 2) / (radiusMax - radiusMin))));
            if (Mathf.Abs(radiusMax - radius) <= 0.00001f)
            {
                radiusIO = !radiusIO;
            }
        }
        else
        {
            radius = Mathf.MoveTowards(radius, radiusMin, Time.deltaTime * (0.01f + (Mathf.Pow(radius - radiusMin, 2) / (radiusMax - radiusMin))));
            if (Mathf.Abs(radiusMin - radius) <= 0.00001f)
            {
                radiusIO = !radiusIO;
            }
        }

        // calculate new positions for each triangle

        // triangle 1
        Vector3 pos1 = Vector3.zero;
        pos1.y = radius * transform.localScale.x;
        triangles[0].transform.position = pos1 + transform.position;
        
        // triangle 2
        Vector3 pos2 = Vector3.zero;
        pos2.x = -radius * transform.localScale.x * Mathf.Sin(60 * Mathf.Deg2Rad);
        pos2.y = -radius * transform.localScale.x * Mathf.Cos(60 * Mathf.Deg2Rad);
        triangles[1].transform.position = pos2 + transform.position;

        // triangle 3
        Vector3 pos3 = Vector3.zero;
        pos3.x = radius * transform.localScale.x * Mathf.Sin(60 * Mathf.Deg2Rad);
        pos3.y = -radius * transform.localScale.x * Mathf.Cos(60 * Mathf.Deg2Rad);
        triangles[2].transform.position = pos3 + transform.position;
    }

    void AngleBob()
    {
        // calculate new angle
        if (angleLR)
        {
            angle = Mathf.MoveTowards(angle, angleMax, Time.deltaTime * 0.7f);
            if (Mathf.Abs(angleMax - angle) <= 0.0001f)
            {
                angleLR = !angleLR;
            }
        }
        else
        {
            angle = Mathf.MoveTowards(angle, angleMin, Time.deltaTime * 0.9f);
            if (Mathf.Abs(angleMin - angle) <= 0.0001f)
            {
                angleLR = !angleLR;
            }
        }

        // set angle
        Quaternion temp = Quaternion.identity;
        temp.Set(0, 0, (angle * Mathf.Deg2Rad), gameObject.transform.rotation.w);
        gameObject.transform.rotation = temp;
    }
}
