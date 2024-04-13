using UnityEngine;
public class MotherClassEnemy : MonoBehaviour
{
    protected int da�o;
    private GameManagerGame gameManager;
    private CinemachineController cinemachineController;
    protected void Attack(PlayerController jugador, int da�o)
    {
        if (gameManager == null)
        {
            gameManager = jugador.GameManager;
        }
        if (cinemachineController == null)
        {
            cinemachineController = jugador.CinemachineController;
        }
        if (jugador.Vida > 0)
        {
            string color = jugador.Color_;
            if (this.tag == color)
            {
                jugador.Se_puede_cambiar_color = false;
                this.GetComponent<Collider2D>().isTrigger = true;
            }
            else
            {
                jugador.Vida = jugador.Vida - da�o;
                gameManager.ActualizaBarraDeVida(jugador.Vida);
                cinemachineController.SacudirCamara(da�o);
            }
        }
        if (jugador.Vida <= 0)
        {
            gameManager.CuandoElJugadorEsDerrotado?.Invoke();
        }

    }
}

