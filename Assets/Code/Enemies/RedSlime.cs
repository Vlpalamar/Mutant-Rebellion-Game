﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSlime : Enemy
{
    private Rigidbody2D rb;
    [SerializeField]private Transform shootPos;
    private bool readyForShoot;
    
    
    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        projectile.Damage = damage;
        projectile.Owner = this.gameObject;
        readyForShoot = true;
    }

    public void Update()
    {
        if (onEp != LoadManager.instance.CurrentEps || onLvl!= LoadManager.instance.CurrentLvls)   
        {
            Freeze();
            return;
            
        }
      
       

        
        if (ReadytoAttack() )
        {
            anim.speed = attackSpeed;
            anim.SetBool("ReadyToAttack",true);
            rb.velocity = new Vector2(0, 0);
            return;
        }
        else
        {
            if (!readyForShoot) 
                return;
            
            MoveToHero();
        }
       

    }

    void MoveToHero()
    {
        if (Flip())
            rb.velocity = new Vector2(speed, 0);

        else
            rb.velocity = new Vector2(-speed, 0);

        anim.speed = 1;
        anim.SetBool("ReadyToAttack", false);
    }

    void Shoot()
    {
        Instantiate(projectile, shootPos.position, shootPos.rotation);
    }

    void StartAttack()
    {
        readyForShoot = false;

    }

    void EndAttack()
    {
        readyForShoot = true;
    }


    protected override void Freeze()
    {
        rb.velocity = new Vector2(0, 0);
        anim.speed = 1;
        anim.SetBool("ReadyToAttack", false);
       
    }
}
