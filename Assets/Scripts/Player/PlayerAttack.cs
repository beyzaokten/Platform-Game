using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;

    [SerializeField] private float attackCoolDown;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;


    private float coolDownTimer=Mathf.Infinity;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)&& coolDownTimer>attackCoolDown && playerController.canAttack())
        { Attack(); }

        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("attack");
        coolDownTimer = 0;

        fireBalls[FindFireBall()].transform.position = firePoint.position;
        fireBalls[FindFireBall()].GetComponent<Fire>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireBall()
    {
        for(int i=0;i<fireBalls.Length;i++)
        {
            if (!fireBalls[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
