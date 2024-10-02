using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classScript : MonoBehaviour
{
    // Object References
    public SpriteRenderer bodySprite;
    public playerScript player;
    public healthBarScript healthBar;

    public Sprite passive;
    public Sprite skill1;
    public Sprite skill2;
    public Sprite skill3;
    public Sprite skill4;


    // Base Stats
    //  base stats are only changed by level
    public float maxHP;
    public float HP;
    public bool invincible;

    public float baseMoveSpeed;
    public float baseAttackSpeed;
    public float baseAttackSize;
    public float baseDamage;
    public float baseCDReduction;
    public float baseProjectileSpeed;
    public float baseArmorPenetration;
    public float baseCritRate;
    public float baseCritDamage;


    //  these stats are affected by items
    protected float moveSpeed;
    protected float attackSpeed;
    protected float attackSize;
    protected float damage;
    protected float cdReduction;
    protected float projectileSpeed;
    protected float armorPenetration;
    protected float critRate;
    protected float critDamage;

    //  modifiers
    public List<float> speedMod;
    public List<float> atkSpeedMod;
    public List<float> atkSizeMod;
    public List<float> dmgMod;
    public List<float> cdMod;
    public List<float> projSpeedMod;
    public List<float> armorPenMod;
    public List<float> critRateMod;
    public List<float> critDamageMod;

    // Position Refs
    protected Vector3 mousePos;
    protected Vector3 prevPos;
    protected Vector3 moveVec;

    // Cooldowns
    public float skill1CD;
    protected float skill2CD;
    public float skill3CD;
    protected float skill4CD;

    public float skill1Timer;
    protected float skill2Timer;
    public float skill3Timer;
    protected float skill4Timer;


    // Misc
    public bool softlock = false;
    public bool hardlock = false;
    public Color multiplier;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = playerScript.player;
        CheckStats();
        healthBar = FindObjectOfType<healthBarScript>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // HEALTH BAR
        healthBar.hpPercent = HP / maxHP;

        // CAM FOLLOW
        Vector3 camPos = transform.position;
        camPos.z = -10;
        player.cam.transform.position = camPos;

        // GET MOUSE POSITION
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // PLAYER MOVING
        prevPos = transform.position;
        if (!softlock && !hardlock)
        {
            Vector3 pos = transform.position;
            if (Input.GetKey(playerScript.player.up))
            {
                pos.y += 1 * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(playerScript.player.down))
            {
                pos.y -= 1 * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(playerScript.player.right))
            {
                pos.x += 1 * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(playerScript.player.left))
            {
                pos.x -= 1 * Time.deltaTime * moveSpeed;
            }
            transform.position = pos;
        }
        moveVec = (transform.position - prevPos).normalized;
    }

    float CheckStatMult(float baseStat, List<float> mods)
    {
        float newStat = baseStat;

        if (mods.Count > 0)
        {
            for(int i = 0; i < mods.Count; i++)
            {
                newStat *= mods[i];
            }
        }
        return newStat;
    }

    float CheckStatAdd(float baseStat, List<float> mods)
    {
        float newStat = baseStat;

        if (mods.Count > 0)
        {
            for (int i = 0; i < mods.Count; i++)
            {
                newStat += mods[i];
            }
        }
        return newStat;
    }

    void CheckSpeed()
    {
        moveSpeed = CheckStatMult(baseMoveSpeed, speedMod);
    }
    
    void CheckAtkSpeed()
    {
        attackSpeed = CheckStatMult(baseAttackSpeed, atkSpeedMod);
    }

    void CheckAtkSize()
    {
        attackSize = CheckStatMult(baseAttackSize, atkSizeMod);
    }

    void CheckDmg()
    {
        damage = CheckStatMult(baseDamage, dmgMod);
    }

    void CheckCD()
    {
        cdReduction = baseCDReduction;
        if (cdMod.Count > 0)
        {
            float temp = 0;
            for (int i = 0; i < cdMod.Count; ++i)
            {
                temp += cdMod[i];
            }
            cdReduction /= temp;
        }
    }

    void CheckProjSpeed()
    {
        projectileSpeed = CheckStatMult(baseProjectileSpeed, projSpeedMod);
    }

    void CheckArmorPen()
    {
        armorPenetration = CheckStatMult(baseArmorPenetration, armorPenMod);
    }

    void CheckCritRate()
    {
        critRate = CheckStatMult(baseCritRate, critRateMod);
    }

    void CheckCritDamage()
    {
        critDamage = CheckStatMult(baseCritDamage, critDamageMod);
    }

    void CheckStats()
    {
        CheckSpeed();
        CheckAtkSpeed();
        CheckAtkSize();
        CheckDmg();
        CheckCD();
        CheckProjSpeed();
        CheckArmorPen();
        CheckCritRate();
        CheckCritDamage();
    }
}