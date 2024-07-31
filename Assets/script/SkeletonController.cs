using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de incluir este namespace

public class SkeletonController : MonoBehaviour
{
    public float attackRange = 5f; // Rango de ataque
    public float attackCooldown = 0.5f; // Cooldown de ataque en segundos
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se dispara el proyectil
    public Animator animator; // Referencia al Animator del esqueleto
    public int health = 3; // Vida del esqueleto

    private Transform player; // Referencia al transform del jugador
    private float lastAttackTime = -Mathf.Infinity; // Último tiempo de ataque

    private void Start()
    {
        // Asignar el jugador por tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (animator.GetBool("isDead"))
        {
            return; // No hacer nada si el esqueleto está muerto
        }

        // Calcular la distancia al jugador
        float distance = Vector2.Distance(transform.position, player.position);

        // Verificar si el jugador está dentro del rango de ataque
        if (distance <= attackRange)
        {
            animator.SetBool("isAttacking", true);

            // Verificar si ha pasado el tiempo de cooldown
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                // Disparar proyectil
                Attack();
                lastAttackTime = Time.time; // Actualizar el último tiempo de ataque
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void Attack()
    {
        if (firePoint != null && projectilePrefab != null)
        {
            // Instanciar el proyectil y configurar su dirección
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            EnemyProjectile projectileComponent = projectile.GetComponent<EnemyProjectile>();

            // Calcular la dirección del disparo basada en la orientación del esqueleto
            Vector2 shootingDirection = (player.position - firePoint.position).normalized;

            projectileComponent.Initialize(shootingDirection);
        }
    }

    public void TakeDamage(int damage)
    {
        // Reducir la vida del esqueleto y manejar la muerte si es necesario
        health -= damage;
        Debug.Log("Skeleton Health: " + health); // Mensaje de depuración
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (animator != null)
        {
            animator.SetBool("isDead", true);
        }

        // Mensaje de depuración
        Debug.Log("Skeleton is Dead. Loading next scene.");

        // Eliminar el esqueleto después de un pequeño retraso
        Destroy(gameObject, 0.2f);

        // Cambiar a la siguiente escena después de un retraso
        Invoke("LoadNextScene", 0.5f); // Ajusta el tiempo si es necesario
    }

    private void LoadNextScene()
    {
        // Reemplaza "NextSceneName" con el nombre de la escena a la que deseas ir
        string sceneName = "NextSceneName"; // Asegúrate de que este nombre es correcto
        if (Application.CanStreamedLevelBeLoaded(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene " + sceneName + " cannot be loaded.");
        }
    }
}
