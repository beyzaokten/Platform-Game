
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;

    private float lifeTime;

    private BoxCollider2D boxCollider;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed=speed*Time.deltaTime*direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit=true;
        boxCollider.enabled = false;
        animator.SetTrigger("explode");

        if(collision.tag=="Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }
    }

    //fires direction
    public void SetDirection(float _direction)
    {
        lifeTime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        boxCollider.enabled = true;
        hit=false;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX)!=_direction)
        { localScaleX = -localScaleX; }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
