using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyScript : enemyScript
{
    public Rigidbody2D head;
    public Vector3 rest;

    public int healing;
    public float healTime;

    // Start is called before the first frame update
    void Start()
    {
        rest = head.gameObject.transform.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (HP < maxHP)
        {
            healTime -= Time.deltaTime;
            if (healTime <= 0)
            {
                HP = Mathf.MoveTowards(HP, maxHP, healing);
                healTime += 5;
            }
        }

        if (head.velocity.sqrMagnitude <= 0.001f && (rest - head.transform.position).magnitude <= 0.001f)
        {
            head.transform.position = rest;
            head.velocity = Vector3.zero;
        }
        else
        {
            head.AddForce((rest - head.gameObject.transform.position).normalized * 10 * (rest - head.transform.position).magnitude);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        head.AddForce((head.transform.position - other.transform.position).normalized * 50);
    }
}
