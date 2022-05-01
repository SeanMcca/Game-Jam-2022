using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDamage : MonoBehaviour
{

    public int maxHealth = 200;
    public int minHealth = 100;
    public float currentHealth;
    public HealthControl healthBar;
    public Animator transition;
    public float transitionTime;
    private bool canGetDamage = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (canGetDamage == false)
        {
            wait(3);
            canGetDamage = true;

        }
        healthBar.SetHealth((int)currentHealth);
        if (currentHealth < 100)
        {
            currentHealth = 100;
       

        }
    }
    IEnumerator wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collied");

        if (col.gameObject.tag == "Enemy1")
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        if (canGetDamage == true)
        {
            if (currentHealth > 100)
            {
                canGetDamage = false;
                currentHealth -= damage;
                healthBar.SetHealth((int)currentHealth);
            }
        }
    }
    void FixedUpdate()
    {
        heal(.065f);
    }

    void heal(float health)
    {
        if (currentHealth < 200)
        {
            currentHealth += health;
            healthBar.SetHealth((int)currentHealth);
        }

    }

    
}
