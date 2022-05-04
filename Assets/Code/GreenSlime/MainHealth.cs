using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHealth : MonoBehaviour
{

    [SerializeField] private float health;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            
            Projectile newProj =other.GetComponent<Projectile>();
            if (newProj.Owner == this.gameObject)
                return;
            
//               print(newProj.Damage);
            
            TakeDamage(newProj.Damage);
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(float damage)
    {
        health = health - damage;

    }
    
}
