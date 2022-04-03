using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public int health;
    public int maxHealth = 150;

    public int bleed = 2;

    private AudioSource audioSource;

    private float timer;

    private PlayerBackpack playerBackpack;



    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;

        timer = Time.time + 1f;

        playerBackpack = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBackpack>();
    }

    private void Update()
    {
        if(Time.time > timer)
        {
            health -= bleed;
            timer = Time.time + 1f;
        }

        CheckHealth();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        CheckHealth();
    }

    void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;

            // show game over UI

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if (collision.GetComponent<PlayerBackpack>().currentNumberOfStoredFruits != 0) {
            //    audioSource.Play();
            //}

            //health += collision.GetComponent<PlayerBackpack>().TakeFruits();

            if (playerBackpack.currentNumberOfStoredFruits != 0)
                audioSource.Play();

            health += playerBackpack.TakeFruits();

            if (health > maxHealth)
                health = maxHealth;
        }
    }

} // class
