using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset; // Desplazamiento desde la posición del jugador

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posición deseada de la cámara
            Vector3 desiredPosition = player.position + offset;
            // Interpola suavemente entre la posición actual de la cámara y la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Actualiza la posición de la cámara
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
