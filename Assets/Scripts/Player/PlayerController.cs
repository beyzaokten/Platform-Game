using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player;
    [SerializeField] float speed;
    private float jump = 17;

    private float horizontalInput;

    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private float wallJumpCoolDown;


    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider=GetComponent<BoxCollider2D>();  

    }

    // Update is called once per frame
    void Update()
    {
         horizontalInput = Input.GetAxis("Horizontal");
       

        //flip player
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            animator.SetBool("isRun", true);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            animator.SetBool("isRun", true);
        }

        animator.SetBool("isRun", horizontalInput != 0);



        //wall jump controller
        if (wallJumpCoolDown > 0.2f)
        {
            player.velocity = new Vector2(horizontalInput * speed, player.velocity.y);
            if (isOnWall() && !isOnGround())
            {
                player.gravityScale = 0;
                player.velocity = Vector2.zero;
            }
            else { player.gravityScale = 5; }

            Jump();
        }
        else
            wallJumpCoolDown += Time.deltaTime;


    }
    //jump and jumping animation
    private void Jump ()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround())
        {
            player.velocity = new Vector2(player.velocity.x, jump);
            animator.SetBool("isJump", true);
        }
        else if (!Input.GetKey(KeyCode.Space))
        { animator.SetBool("isJump", false); }

        else if (isOnWall() && !isOnGround())
        {

            if(horizontalInput==0)
            {
                player.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale=new Vector3(-Mathf.Sign(transform.localScale.x),transform.localScale.y,transform.localScale.z);
            }
            else
            
                player.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
        
            wallJumpCoolDown = 0;
            
        }
    }

    
    private bool isOnGround()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f,groundLayer);
        return raycastHit.collider!=null;
    }

    private bool isOnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,new  Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    { return horizontalInput == 0 && isOnGround() && !isOnWall(); }

  
}
