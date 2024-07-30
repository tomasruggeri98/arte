using UnityEngine;

public class SkeletonControllerHp : MonoBehaviour
{
    public int health = 3; // Vida del esqueleto
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            TakeDamage(1); // Asumiendo que cada proyectil hace 1 da�o
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.Play("EsqueletoDie"); // Reproducir animaci�n de muerte
        Invoke("DestroySkeleton", 0.2f); // Destruir el objeto despu�s de 0.2 segundos
    }

    void DestroySkeleton()
    {
        Destroy(gameObject);
    }
}
