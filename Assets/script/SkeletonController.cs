using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public float attackRange = 5f; // Rango de ataque
    
    public float attackCooldown = 0.5f; // Cooldown de ataque en segundos
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint; // Punto desde donde se dispara el proyectil
    public Animator animator; // Referencia al Animator del esqueleto
    public Transform player; // Referencia al transform del jugador

    private float lastAttackTime = -Mathf.Infinity; // Último tiempo de ataque

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


    private void Die()
    {
        animator.SetBool("isDead", true);
        // Eliminar el esqueleto después de un pequeño retraso
        Destroy(gameObject, 0.2f);
    }

}
