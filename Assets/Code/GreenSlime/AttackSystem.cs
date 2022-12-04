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

 
    void Update()
    {
        currentAttackCooldown -= Time.deltaTime;      
    }
    public void Attack()
    {
     
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
