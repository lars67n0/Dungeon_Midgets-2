using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int health = 100;

    private int MAX_HEALTH = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = Color.white;

    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Amount has to be greater than 0");
        }
        this.health -= amount;
        StartCoroutine(VisualIndicator(Color.red));

        if(health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Amount has to be greater than 0");
        }

        if(health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
            StartCoroutine(VisualIndicator(Color.green));
        }

        
    }

    public void Die()
    {
       
        Destroy(gameObject);
    }
}
