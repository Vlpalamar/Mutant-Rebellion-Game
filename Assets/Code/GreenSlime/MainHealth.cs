using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainHealth : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField]private  Slider healthBar;
    [SerializeField] private float addHealth;
    
    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyProjectile"))
        {
            
            Projectile newProj =other.GetComponent<Projectile>();
            if (newProj.Owner == this.gameObject)
                return;
            
//               print(newProj.Damage);
            
            TakeDamage(newProj.Damage);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("HealthUp"))
        {
            TakeHeal(addHealth);
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(float damage)
    {

        if (health - damage <= 0)
        {
            Death();
            healthBar.value = 0;
        }
        else
        {
            health = health - damage;
            healthBar.value = health;
        }
    }

    private void Death()
    {
        print("Death");
    }

    private void TakeHeal(float addHealth)
    {
        if (health+addHealth>= healthBar.maxValue)
        {
            health = healthBar.maxValue;
        }
        else
        {
            health += addHealth;
            healthBar.value = health;
        }
    }



}
