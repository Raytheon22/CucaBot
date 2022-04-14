using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucarachaVeloz : Cucarachas
{
    public override void RecibirDaño(int Daño)
    {
        Morir();
    }
}

