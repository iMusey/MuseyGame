using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public healthBarScript healthBar;
    public float hpBarHeight;

    public float maxHP;
    public float HP;
    public float armor;
    public float speed;
    public float attackSpeed;
    public float dmg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        healthBar.hpPercent = HP / maxHP;
    }

    /*
    void OnTriggerEnter2D(Collider2D other)
    {
    }*/

    public void TakeDamage(float dmg, bool crit, float armorPen)
    {
        dmg *= 1 / (armor - armorPen);
        HP -= dmg;

        dmgNumManager.dNumMan.dmgNum(dmg.ToString(), crit, 1, 2.5f, healthBar.transform.position);
    }
}
