using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    public playerScript owner;
    public classScript classScript;
    public Rigidbody2D rb;


    // not sure if i will use this method yet, but i think this stat would be assigned
    // to the bullet and assigned a value by the script that makes it
    public float procCoeff;
    public float damage;
    public bool crit = false;
    public float armorPen;
    public float speed;
    public float life;

    public Vector3 dir;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        life -= Time.deltaTime;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
}
