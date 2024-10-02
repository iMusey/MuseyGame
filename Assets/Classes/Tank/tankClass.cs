using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankClass : classScript
{
    public GameObject body;
    public GameObject canon;
    public SpriteRenderer canonSprite;


    public Vector3 relativeMousePos;

    public float skill1DmgCoeff;
    public float skill2DmgCoeff;
    public float skill4DmgCoeff;

    float angle;

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
            // POINT CANON
            {
                mousePos.z = 0;
                relativeMousePos = (mousePos - transform.position).normalized;
                angle = Mathf.Asin(relativeMousePos.y / 1) * Mathf.Rad2Deg;

                if (relativeMousePos.x < 0)
                {
                    canon.transform.rotation = Quaternion.Euler(0, 0, -(angle - 90));
                }
                else
                {
                    canon.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                }
            }
        }


    }

    void Colorize()
    {
        bodySprite.color = playerScript.player.color2;
        canonSprite.color = playerScript.player.color1;
    }
}