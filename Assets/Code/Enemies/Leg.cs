using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();

    }

    protected override void Freeze()
    {
        
        return;
    }
    // Update is called once per frame
    void Update()
    {
       
        Flip();


      

    }

    void Attack()
    {
        Vector2 vA = new Vector2(transform.position.x + distance, transform.position.y);
        Vector2 vB = new Vector2(transform.position.x - distance, transform.position.y-distance);
        Collider2D[] colliders= Physics2D.OverlapAreaAll(vA, vB);
        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                 col.gameObject.GetComponent<MainHealth>().TakeDamage(damage);
              
            }
        }
    }
}
