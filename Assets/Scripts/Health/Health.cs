using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float startingHealth;

    public float currentHealth { get; private set; }
    private Animator animator;

    private bool isDead;


   
    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth= Mathf.Clamp(currentHealth-damage, 0, startingHealth);

        if(currentHealth>0)
        {
            animator.SetTrigger("hurt");
            
        }
        else
        {
            if(!isDead)
            {
                animator.SetTrigger("die");
                //for player
                if(GetComponent<PlayerController>() != null)
                GetComponent<PlayerController>().enabled = false;

                //for enemy
                if (GetComponent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;

                if (GetComponent<GhostHalo>() != null)
                {
                    GetComponent<GhostHalo>().enabled = false;
                }
                    

                if(GetComponent<Enemy>() != null)
                {
                    gameObject.SetActive(false);
                }
               

          
                isDead = true;
            }
           
        }

    }

    public void Heal(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

   
}
