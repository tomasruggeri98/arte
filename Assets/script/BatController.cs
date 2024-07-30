using UnityEngine;

public class BatController : MonoBehaviour
{
    public int health = 3; // Vida del murci�lago
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Aqu� podr�as agregar l�gica adicional si es necesario
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            TakeDamage(1);
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
        animator.Play("BatDie");
        Invoke("DestroyBat", 0.2f); // Destruir el objeto despu�s de 0.2 segundos
    }

    void DestroyBat()
    {
        Destroy(gameObject);
    }
}
