using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLvl : MonoBehaviour
{

    private bool isClose; 
    private Animator anim;
    private Collider2D coll;

    private bool flag;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        Physics2D.queriesHitTriggers = true;
    }

   
    
        
    void OnMouseDown()
    {
        print("!!");
        if (isClose)
        {
          LoadManager.instance.NextSceneLoad();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MainHealth>())
        {
            isClose = true;
            anim.SetBool("readyToNext", isClose);
          
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.GetComponent<MainHealth>())
        {
            isClose = false;
            anim.SetBool("readyToNext", isClose);
        }
    }
 
}
