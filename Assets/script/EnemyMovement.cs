using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento
    public float lifeTime = 10f; // Tiempo de vida del enemigo en segundos

    private void Start()
    {
        // Destruir el enemigo después de lifeTime segundos
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        // Mover el enemigo hacia la izquierda
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
