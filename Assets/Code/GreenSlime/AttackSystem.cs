using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKey(KeyCode.X) && currentAttackCooldown<=0)
            Attack();
        
    }
    private void Attack()
    {
        currentAttackCooldown = attackCooldown;
        anim.SetTrigger("attack");
      
    }

    void Shoot()
    {
        Instantiate(projectile, shootPos.position, shootPos.rotation);
    }

}
