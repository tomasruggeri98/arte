using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float pushForce = 10f; // Fuerza con la que se empuja la caja

    private Rigidbody2D rb;
    private bool shouldMove = false; // Controla si la caja debe moverse

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (shouldMove)
        {
            Move();
        }
    }

    void Move()
    {
        // Aplica una fuerza a la caja para moverla
        Vector2 movement = new Vector2(pushForce, 0); // Puedes ajustar la dirección y la fuerza según sea necesario
        rb.velocity = new Vector2(movement.x * moveSpeed * Time.deltaTime, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si la colisión es con el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activar el movimiento al colisionar con el jugador
            shouldMove = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Verificar si el jugador se aleja
        if (collision.gameObject.CompareTag("Player"))
        {
            // Desactivar el movimiento cuando el jugador se aleje
            shouldMove = false;
            rb.velocity = Vector2.zero; // Detener el movimiento inmediatamente
        }
    }
}
