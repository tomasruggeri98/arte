using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    private Vector2 direction;

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    void Start()
    {
        Destroy(gameObject, 5f); // Destruir el proyectil después de 5 segundos
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destruir el proyectil al colisionar
        Destroy(gameObject);
    }
}
