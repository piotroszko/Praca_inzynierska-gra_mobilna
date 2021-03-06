using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _maxHealth = 200;
    
    public AudioSource audioHit;
    public float maxHealth { 
        get {
            return _maxHealth + additionalHealth; 
        }
        set { 
            _maxHealth = value; 
        }
     }
     private float _additionalHealth = 0;

    public float additionalHealth { 
        get { return _additionalHealth; }
        set { 
            _additionalHealth = value;
            healthBar.SetMaxHealth(maxHealth);
        }
    }

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
        if (currentHealth != healthBar.slider.value)
        {
            healthBar.slider.value = currentHealth;
        }
    }

    public void Damage(float damage)
    {
        if (!immortal)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            StartCoroutine(Immortality());
            audioHit.Play();
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