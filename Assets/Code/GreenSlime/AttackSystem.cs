using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackCooldown;
    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform shootPos;
    private Animator anim;

    private float currentAttackCooldown;
    void Start()
    {
        anim = GetComponent<Animator>();
        projectile.Damage = damage;
        projectile.Owner = this.gameObject;
    }

   
    // Update is called once per frame
    void Update()
    {
        currentAttackCooldown -= Time.deltaTime;
        //if (Input.GetKey(KeyCode.X) && currentAttackCooldown<=0)
        //    Attack();
        
    }
    public void Attack(Image attackSprite)
    {
        attackSprite.color = new Color(attackSprite.color.r, attackSprite.color.g, attackSprite.color.b, 1);
        if (currentAttackCooldown > 0)
            return;
        
        currentAttackCooldown = attackCooldown;
        anim.SetTrigger("attack");
      
    }

    void Shoot()
    {
        Instantiate(projectile, shootPos.position, shootPos.rotation);
    }

}
