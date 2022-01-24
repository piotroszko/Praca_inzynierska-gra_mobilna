using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 200;
    public float currentHealth;
    public HealthBar healthBar;

    //immortality

    private float iFramesDuration = 1;
    private int numberOfFlashes = 3;
    private SpriteRenderer sprite;
    public bool immortal;
    public bool longerDuration;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        if (!immortal)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            StartCoroutine(Immortality());
        }
    }

    public IEnumerator Immortality()
    {
        immortal = true;
        for (int i = 0; i < numberOfFlashes; i++)
        {
            if (longerDuration)
            {
                sprite.color = Color.red;
                yield return new WaitForSeconds((iFramesDuration + 1) / (numberOfFlashes * 2));
                sprite.color = Color.white;
                yield return new WaitForSeconds((iFramesDuration + 1) / (numberOfFlashes * 2));
            }
            else
            {
                sprite.color = Color.red;
                yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
                sprite.color = Color.white;
                yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            }
        }

        immortal = false;
    }
}