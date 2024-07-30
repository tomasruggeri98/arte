using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public Vector3 offset; // Desplazamiento desde la posici�n del jugador

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posici�n deseada de la c�mara
            Vector3 desiredPosition = player.position + offset;
            // Interpola suavemente entre la posici�n actual de la c�mara y la posici�n deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Actualiza la posici�n de la c�mara
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
