using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject MainHero;
    [SerializeField] private List<Collider2D> eps;
   

    [SerializeField] private  CinemachineConfiner CM;
    [SerializeField] private int currentEps;
    [SerializeField] private int currentLvls;
    [SerializeField] private float distanceBetweenEps = 5f;
    [SerializeField] private float distanceBetweenLvls = 10f;
    [SerializeField] private float lvlPointXStart;
    
    
   private int defineEp;
    private int defineLvl;

    public static LoadManager instance = null; // Экземпляр объекта

    public int DefineEp
    {
        get { return defineEp; }
    }
    public int DefineLvl
    {
        get { return defineLvl; }
    }
    public int CurrentEps
    {
        get { return currentEps; }
    }
    public int CurrentLvls
    {
        get { return currentLvls; }
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
        CM.m_BoundingShape2D = eps[currentEps];
        defineEp = 15;
        defineLvl = 10;


    }

    public void LeftSceneLoad( )
    {
        anim.Play("LeftSceneLoad");
    }

    public void RightSceneLoad()
    {
        anim.Play("RightSceneLoad");
    }

    public void NextSceneLoad()
    {
        anim.Play("NextSceneLoad"); // в аним ивенте NextLvl();
    }


    public void EndLoad()
    {
        anim.Play("SceneAwake");
    }

    public void LeftScene()
    {
        MainHero.transform.position=  new Vector3(MainHero.transform.position.x-distanceBetweenEps, MainHero.transform.position.y);
        currentEps--;
        CM.m_BoundingShape2D = eps[currentEps];
        EndLoad();
        
    }

    public void RightScene()
    {
        MainHero.transform.position = new Vector3(MainHero.transform.position.x + distanceBetweenEps, MainHero.transform.position.y);
        currentEps++;
        CM.m_BoundingShape2D = eps[currentEps];
       
        EndLoad();
    }

    public void NextLvl(int SceneIndex)
    {
        MainHero.transform.position = new Vector3(lvlPointXStart, MainHero.transform.position.y- distanceBetweenLvls);
        currentEps = 0;
        currentLvls++;
        CM.m_BoundingShape2D = eps[SceneIndex];
        EndLoad();
    }
}
