using UnityEngine;

public class Oscilar : MonoBehaviour
{
    public float range = 1f; // Rango de movimiento en unidades
    public float speed = 1f; // Velocidad de oscilaci�n

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Oscilaci�n en el eje Y
        float newY = Mathf.Sin(Time.time * speed) * range;

        // Aplicar el nuevo valor de Y a la posici�n del objeto
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }
}
