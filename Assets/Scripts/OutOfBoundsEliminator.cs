using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsEliminator : MotherClassEnemy
{
    void Start()
    {
        daño = 10;
    }
    public void Eliminar(PlayerController jugador)
    {
        Attack(jugador, daño);
    }
}
