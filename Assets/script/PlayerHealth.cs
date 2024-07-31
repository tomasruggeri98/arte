using System.Collections; // Añade esta línea
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    private bool isInvulnerable = false;
    public float invulnerabilityDuration = 1f; // Duración de la invulnerabilidad en segundos

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isInvulnerable && collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvulnerable && collision.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Invulnerability());
        }
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
    }

    void Die()
    {
        Debug.Log("Player Died");


        Destroy(gameObject);

        SceneManager.LoadScene("Menu");
    }
}

