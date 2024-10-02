using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.XR;

public class gunslingerClass : classScript
{
    public Vector3 gunsPos;
    public GameObject body;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject barrel1;
    public GameObject barrel1Back;
    public GameObject barrel2;
    public GameObject barrel2Back;

    public float skill1DmgCoeff;
    public float skill2DmgCoeff;
    public float skill4DmgCoeff;

    public int LR = 1;
    public GameObject bulletPrefab;
    public SpriteRenderer[] gunSprites;
    float angle;
    Vector3 rollTarget;
    bool rolling = false;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        Colorize();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!pauseMenu.pMenu.paused)
        {
            base.Update();
            // POINT GUNS
            {
                // get target position based on mouse
                mousePos.z = 0;
                gunsPos = Vector3.ClampMagnitude(mousePos - transform.position, 0.5f);

                // get rotation based on mouse
                angle = (Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg);

                // correct positions
                if (gunsPos.x > 0)
                {
                    gunsPos = new Vector3(gunsPos.x + .05f, (gunsPos.y / 1.25f), 0);
                    gun1.transform.localScale = new Vector3(0.1f, 0.1f, 1);
                    gun2.transform.localScale = new Vector3(0.1f, 0.1f, 1);
                }
                else
                {
                    gunsPos = new Vector3(gunsPos.x - .05f, (gunsPos.y / 1.25f), 0);
                    gun1.transform.localScale = new Vector3(0.1f, -0.1f, 1);
                    gun2.transform.localScale = new Vector3(0.1f, -0.1f, 1);
                }

                //gunsPos *= 0.5f;
                gunsPos += transform.position;

                // apply position to both guns seperately
                gun1.transform.position = new Vector3(gunsPos.x - .2f, gunsPos.y, 0);
                gun2.transform.position = new Vector3(gunsPos.x + .2f, gunsPos.y, 0);

                // apply rotation to both guns seperately
                gun1.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                gun2.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }

            // ROLLING
            {
                if (Input.GetKey(playerScript.player.skill3) && !rolling && !softlock && !hardlock && (skill3Timer <= 0.001f))
                {
                    rollTarget = (moveVec * 2) + transform.position;
                    skill3Timer = skill3CD * cdReduction;

                    softlock = true;
                    rolling = true;
                }

                if (rolling)
                {
                    Roll();
                }
            }

            // SHOOT GUN
            {
                if (Input.GetKey(playerScript.player.skill1) && !hardlock && (skill1Timer <= 0.001f))
                {
                    // instantiate and set values of bullet
                    //  instantantiate
                    GameObject bullet = Instantiate(bulletPrefab);
                    bulletScript bScrip = bullet.GetComponent<bulletScript>();

                    //  set object references
                    bScrip.owner = playerScript.player;
                    bScrip.classScript = this;

                    //  set colors
                    bScrip.casing.color = playerScript.player.color1;
                    bScrip.tip.color = playerScript.player.color2;

                    //  calculate movement stats
                    float bulletAngle;

                    //   if LR is 2 shoot the left gun, if LR is 1 shoot the right gun
                    if (LR % 2 == 0)
                    {
                        bullet.transform.position = barrel1.transform.position;
                        bScrip.dir = (barrel1.transform.position - barrel1Back.transform.position).normalized;
                        bulletAngle = Mathf.Atan2(mousePos.y - barrel1.transform.position.y, mousePos.x - barrel1.transform.position.x) * Mathf.Rad2Deg;
                    }
                    else
                    {
                        bullet.transform.position = barrel2.transform.position;
                        bScrip.dir = (barrel2.transform.position - barrel2Back.transform.position).normalized;
                        bulletAngle = Mathf.Atan2(mousePos.y - barrel2.transform.position.y, mousePos.x - barrel2.transform.position.x) * Mathf.Rad2Deg;
                    }

                    //  set movement stats
                    bScrip.speed = projectileSpeed;
                    bScrip.transform.rotation = Quaternion.Euler(new Vector3(0, 0, bulletAngle - 90));
                    bScrip.rb.AddForce(bScrip.speed * bScrip.dir, ForceMode2D.Impulse);
                    bScrip.life = 10;

                    //  calculate and set damage stats
                    bScrip.transform.localScale = Vector3.one * attackSize;
                    bScrip.armorPen = armorPenetration;
                    bScrip.damage = damage * skill1DmgCoeff;
                    bScrip.crit = (Random.value < (critRate));
                    if (bScrip.crit)
                    {
                        bScrip.damage *= 1 + critDamage;
                    }


                    if (LR >= 2)
                    {
                        LR = 1;
                    }
                    else
                    {
                        LR++;
                    }

                    skill1Timer = skill1CD / attackSpeed;
                }
            }

            // COOLDOWNS
            {
                if (skill1Timer > 0)
                {
                    skill1Timer -= Time.deltaTime;
                }
                if (skill2Timer > 0)
                {
                    skill2Timer -= Time.deltaTime;
                }
                if (skill3Timer > 0)
                {
                    skill3Timer -= Time.deltaTime;
                }
                if (skill4Timer > 0)
                {
                    skill4Timer -= Time.deltaTime;
                }
            }
        }
    }

    void Roll()
    {

        // step toward the target location
        transform.position = Vector3.MoveTowards(transform.position, rollTarget, 0.05f * moveSpeed);


        // return control when target is reached
        if (Vector3.Distance(transform.position, rollTarget) <= 0.1f)
        {
            rolling = false;
            softlock = false;
        }
    }

    void Colorize()
    {
        bodySprite.color = playerScript.player.color1;
        for (int x = 0; x < 4; x++)
        {
            gunSprites[x].color = playerScript.player.color2;
        }
    }
}
