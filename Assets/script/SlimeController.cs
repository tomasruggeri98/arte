using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float speed = 2.0f;
    public float detectionRange = 5.0f;
    public int health = 3;
    private Transform player;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void ChasePlayer()
    {
        animator.SetBool("isMoving", true);
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.collider.CompareTag("Proyectil"))
        {
            TakeDamage(1);
        }
        else if (collision.collider.CompareTag("Player"))
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetBool("isDead", true);
        animator.SetBool("isMoving", false); // Detener animación de movimiento
        Destroy(gameObject, 0.5f); // Ajusta el tiempo si es necesario
    }
}
