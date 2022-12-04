using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rbRigidbody2D;
   [SerializeField]  private GameObject owner;
   [SerializeField] private LayerMask Ground;

    [SerializeField]private float damage;
    //TODO:добавить партиклы
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public GameObject Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    void Start()
    {
        rbRigidbody2D = GetComponent<Rigidbody2D>();
        rbRigidbody2D.velocity = transform.right * speed;
        Destroy(gameObject,5);
    }

   
    

}
