﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject MainHero;
    [SerializeField] private List<Collider2D> lvls;
    [SerializeField] private  CinemachineConfiner CM;
    private int currentLvl;
    [SerializeField] private float distanceBetweenLvls = 5f;

    public static LoadManager instance = null; // Экземпляр объекта

    public int CurrentLvl
    {
        get { return currentLvl; }
    }

    void Start()
    {
       
      
        if (instance == null)
        {
           
            instance = this; 
        }
        else if (instance == this)
        {
            Destroy(gameObject); 
        }

        InitializeManager();


    }

    private void InitializeManager()
    {
        anim = GetComponent<Animator>();
        currentLvl = 0;
    }

    public void LeftSceneLoad( )
    {
        anim.Play("LeftSceneLoad");
    }

    public void RightSceneLoad()
    {
        anim.Play("RightSceneLoad");
    }


    public void EndLoad()
    {
        anim.Play("SceneAwake");
    }

    public void LeftScene()
    {
        MainHero.transform.position=  new Vector3(MainHero.transform.position.x-distanceBetweenLvls, MainHero.transform.position.y);
        currentLvl--;
        CM.m_BoundingShape2D = lvls[currentLvl];
        EndLoad();
        
    }

    public void RightScene()
    {
        MainHero.transform.position = new Vector3(MainHero.transform.position.x + distanceBetweenLvls, MainHero.transform.position.y);
        currentLvl++;
        CM.m_BoundingShape2D = lvls[currentLvl];
       
        EndLoad();
    }
}