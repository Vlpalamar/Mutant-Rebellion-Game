using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float damage;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected float distance;
    [SerializeField] protected float speed;
    [SerializeField] protected Projectile projectile;
    [SerializeField] protected int onLvl;
    protected Animator anim;
    protected bool isRight;


    protected GameObject mainHero;
    protected bool isSpoted;

    public virtual void  Start()
    {
        mainHero= GameObject.FindGameObjectWithTag("Player");
        print("!");
    }

    protected bool Flip()
    {
        if (mainHero.transform.position.x <this.transform.position.x)
        {
            this.transform.rotation = new Quaternion(0f, -180, 0f, 0);
            isRight = false;
            return false;
        }
        else
        {
            this.transform.rotation = new Quaternion(0f, 0f, 0f, 0);
            isRight = true;
            return true;
        }

    }

    protected bool ReadytoAttack()
    {
        //print(Vector2.Distance(mainHero.transform.position, this.transform.position));
        if (Vector2.Distance(mainHero.transform.position, this.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }

       
    }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            print("!");
            Projectile newProj =other.GetComponent<Projectile>();
            if (newProj.Owner == this.gameObject)
                return;

            TakeDamage(newProj.Damage);
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(float damage)
    {
        health = health - damage;

    }


   

}
