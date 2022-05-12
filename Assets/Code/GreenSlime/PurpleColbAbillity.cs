using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurpleColbAbillity : MonoBehaviour
{
    [SerializeField] private Image[] UI_potions;
    [SerializeField] private string _Tag;
    [SerializeField] private int amount;
    [SerializeField] private int limit;
    [SerializeField] private float duration;
    [SerializeField]private float currentDuration;
    [SerializeField] private float cooldown;
    [SerializeField] private float currentCooldown;
    [SerializeField] private GameObject _Shield;
    private MainHealth health;
    private float currentHealth;
    private bool isWorking;


    public bool IsWorking
    {
        get { return isWorking; }
    }
    void Start()
    {
        for (int i = amount - 1; i >= 0; i--)
        {
            UI_potions[i].color = new Color(255, 255, 255, 255);
        }

        currentDuration = duration;
    }
    void Update()
    {
        
        if (isWorking)
            return;
        
        _Shield.SetActive(false);
        
    }

    void FixedUpdate()
    {
        if (isWorking)
            currentDuration -= Time.fixedDeltaTime;
        if (currentDuration <= 0)
        {
            isWorking = false;
            currentDuration = duration;
        }

        currentCooldown -= Time.fixedDeltaTime;
    }

    public void OnPurpleButtonPressed(Image UseColbButton)
    {
        UseColbButton.color = new Color(UseColbButton.color.r, UseColbButton.color.g, UseColbButton.color.b, 1);
        if (amount<=0 || currentCooldown>0) return;
        currentCooldown = cooldown;
        amount--;
        isWorking = true;
        _Shield.SetActive(true);
        UI_potions[amount ].color = new Color(0, 0, 0, 0);
        //редактируем UI
    }

    private void AddAmount(int Add=1)
    {
        amount += Add;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_Tag))
        {
            if (amount+1>limit) return;
            else
            {
                AddAmount();
                UI_potions[amount - 1].color = new Color(255, 255, 255, 255);
                Destroy(other.gameObject);
            }
        }
    }




}
