using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsEliminator : MotherClassEnemy
{
    void Start()
    {
        da�o = 10;
    }
    public void Eliminar(PlayerController jugador)
    {
        Attack(jugador, da�o);
    }
}
