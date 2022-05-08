using System.Collections;
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
    [SerializeField] private int currentLvl;
    [SerializeField] private float distanceBetweenLvls = 5f;
    [SerializeField] private GameObject _UI;
    private int defineLvl;

    public static LoadManager instance = null; // Экземпляр объекта

    public int DefineLvl
    {
        get { return defineLvl; }
    }
    public int CurrentLvl
    {
        get { return currentLvl; }
    }

    void Awake()
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
    void Start()
    {
       
      
      

    }

    private void InitializeManager()
    {
        anim = GetComponent<Animator>();
        currentLvl = 0;
        defineLvl = 15;
        
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
