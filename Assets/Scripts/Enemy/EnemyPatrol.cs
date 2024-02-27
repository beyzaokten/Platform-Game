using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] float speed;
    private Vector3 scale;
    private bool movingLeft;


    private void Awake()
    {
        scale = enemy.localScale;
    }
    private void Update()
    {
        if(movingLeft)
        {
            if(enemy.position.x>=leftEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(enemy.position.x<=rightEdge.position.x)
            {
                MoveInDirection(-1);

            }
            else
            {
                DirectionChange();
            }

        }
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }


    //Make enemy face direction and move 
    private void MoveInDirection(int direction)
    {
        enemy.localScale=new Vector3(Mathf.Abs(scale.x)*direction,scale.y,scale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed, enemy.position.y, enemy.position.z);
    }



}
