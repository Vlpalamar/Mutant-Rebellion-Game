using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainHealth : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField]private  Slider healthBar;
    [SerializeField] private float addHealth;
    private PurpleColbAbillity colb;

    public float Health
    {
        get { return health; }
        set
        {
            health = value;
            healthBar.value = value;
        }
    }


    void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = health;
        healthBar.value = health;
        colb = GetComponent<PurpleColbAbillity>();
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

    public void TakeDamage(float damage)
    {
        if (colb.IsWorking)
            return;
        

        if (health - damage <= 0)
        {
            StartDie();
            healthBar.value = 0;
        }
        else
        {
            health = health - damage;
            healthBar.value = health;
        }
    }

    private void StartDie()
    {
        // анимация будет вызывать слудующую функцию 
        Death();
    }

    private void Death()
    {
        //логика
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        }
        healthBar.value = health;
    }



}
