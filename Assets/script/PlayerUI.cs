using UnityEngine;
using TMPro; // Asegúrate de tener el paquete TextMeshPro importado

public class PlayerUI : MonoBehaviour
{
    public PlayerHealth playerHealth; // Referencia al script de salud del jugador
    public TextMeshProUGUI healthText; // Referencia al objeto de texto en la UI

    void Update()
    {
        // Actualiza el texto con la vida actual del jugador
        healthText.text = " " + playerHealth.CurrentHealth;
    }
}
