using UnityEngine;

public class MotherClassEnemy : MonoBehaviour
{
    protected int daño;
    protected void Attack(PlayerController jugador, int daño)
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
                jugador.Vida = jugador.Vida - daño;
                jugador.ActualizaBarraDeVida();
            }
        }
        if (jugador.Vida <= 0)
        {
            jugador.GameManager.Morir();
        }

    }
}
