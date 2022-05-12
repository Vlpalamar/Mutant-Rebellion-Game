using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Enemy
{
    private Rigidbody2D rb;
    [SerializeField] private Transform shootPos;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        projectile.Damage = damage;
        projectile.Owner = this.gameObject;
        anim.speed = attackSpeed;
        rb.velocity = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (onEp != LoadManager.instance.CurrentEps || onLvl != LoadManager.instance.CurrentLvls)
        {
            Freeze();
            return;
        }
        

        Flip();

        if (ReadytoAttack())
        {
            anim.speed = attackSpeed;
            anim.SetBool("readyToAttack", true);

        }
        else
        {
           Freeze();
           
        }


    }
    void Shoot()
    {
        Instantiate(projectile, shootPos.position, shootPos.rotation);
    }

    protected override void Freeze()
    {
        anim.speed = 1;
        anim.SetBool("readyToAttack", false);
        return;
    }
}
