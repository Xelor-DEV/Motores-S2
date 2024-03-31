using UnityEngine;

public class MotherClassEnemy : MonoBehaviour
{
    protected int da�o;
    protected void Attack(PlayerController jugador, int da�o)
    {
        if(jugador.Vida > 0)
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
                jugador.ActualizaBarraDeVida();
            }
        }
        if (jugador.Vida <= 0)
        {
            jugador.GameManager.Morir();
        }

    }
}
