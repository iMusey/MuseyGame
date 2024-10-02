using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : projectileScript
{
    public SpriteRenderer casing;
    public SpriteRenderer tip;



    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!pauseMenu.pMenu.paused)
        {
            base.Update();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // push
        /*
        Vector2 direction = dir;
        other.GetComponent<Rigidbody2D>().AddForce(direction.normalized * speed);
        */

        if (other.gameObject.GetComponent<enemyScript>() != null)
        {
            enemyScript eScrip = other.gameObject.GetComponent<enemyScript>();
            eScrip.TakeDamage(damage, crit, armorPen);
        }

        Destroy(gameObject);
    }
}
