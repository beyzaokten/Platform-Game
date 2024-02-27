using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : EnemyDamage
{
    [Header("SpikeHead")]
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float checkDelay;
    private float checkTimer;
    [SerializeField] LayerMask playerLayer;



    private Vector3 destination;
    private Vector3[] directions=new Vector3[4];

    private bool isAttacking;

    private void OnEnable()
    {
        Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves spikehead to the destination if isAttacking is true
        if(isAttacking)
        {
            transform.Translate(destination * Time.deltaTime * speed);

        }

        else
        {
            checkTimer+=Time.deltaTime;
            if (checkTimer > checkDelay)
                CheckForPlayer();
        }
    }

    //checks if spikehead sees player
    private void CheckForPlayer()
    {
        CalculateDirection();

        //check if spikehead sees player
        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit=Physics2D.Raycast(transform.position, directions[i],range,playerLayer);

            if(hit.collider!=null && !isAttacking)
            {
                isAttacking = true;
                destination = directions[i];
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirection()
    {
        directions[0] = transform.right * range; //right direction
        directions[1] = -transform.right * range; //left direction
        directions[2] = transform.up * range; //up direction
        directions[3] = -transform.up * range; //down direction
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        //makes spikehead stop when it hits something
        Stop();
    }

    private void Stop()
    {
        destination = transform.position;
        isAttacking=false;
    }
}
