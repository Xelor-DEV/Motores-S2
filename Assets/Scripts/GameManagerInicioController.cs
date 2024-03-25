using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerInicioController : MonoBehaviour
{
    public void GoToScene(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }

}
