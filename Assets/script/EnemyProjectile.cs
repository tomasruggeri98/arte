using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 10f;
    public float lifetime = 2f; // Tiempo en segundos antes de destruir el proyectil

    private Vector2 direction;

    private void Start()
    {
        // Destruir el proyectil después de 'lifetime' segundos
        Destroy(gameObject, lifetime);
    }

    public void Initialize(Vector2 shootingDirection)
    {
        // Configura la dirección inicial del proyectil
        direction = shootingDirection.normalized;
        // Establecer la velocidad inicial
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        // Ajustar la rotación del proyectil para que apunte en la dirección de movimiento
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Aplicar daño al jugador
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
       
            // Destruir el proyectil
            Destroy(gameObject);
        }
    }
}
