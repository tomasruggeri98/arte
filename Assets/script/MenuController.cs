using UnityEngine;
using UnityEngine.SceneManagement; // Para cargar escenas

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Cambia "SampleScene" por el nombre de tu escena de juego
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para detener el juego en el Editor de Unity
#endif
    }
}
