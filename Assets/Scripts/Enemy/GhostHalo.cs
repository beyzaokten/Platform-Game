using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHalo : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] float attackCoolDown;
    [SerializeField] float range;
    [SerializeField] int damage;

    [Header("Collider")]
    [SerializeField] float colliderDistance;
    [SerializeField] BoxCollider2D boxCollider;

    private float coolDownTimer = Mathf.Infinity;

    [Header("Player")]
    [SerializeField] LayerMask playerLayer;
    private Health playerHealth;


    private void Update()
    {
        coolDownTimer += Time.deltaTime;

        if(IsPlayerInSight())
        {
            //attack the player
            if (coolDownTimer >= attackCoolDown)
            {
                coolDownTimer = 0;
            }

           
        }
        
    }

    private bool IsPlayerInSight()
    {
        RaycastHit2D hit =
          Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
          new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
          0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
            
        }

        return hit.collider!=null;


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        //attacks player if player is in range
        if(IsPlayerInSight())
        {
            playerHealth.TakeDamage(damage);
           
           
        }
    }
}
