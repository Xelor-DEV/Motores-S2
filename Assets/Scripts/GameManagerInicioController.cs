using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerInicioController : MonoBehaviour
{
    public void GoToScene(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }
    public void Salir()
    {
        Debug.Log("Saliendo del juego.");
    }
}
