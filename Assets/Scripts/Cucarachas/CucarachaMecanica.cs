using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucarachaMecanica : Cucarachas
{
    public override void AtaqueEspecial()
    {
        base.AtaqueEspecial();
        foreach (Cucarachas ObjectoDeLista in ManagerDeNivel.CantidadDeCucarachas)
        {
            ObjectoDeLista.Curarse();
        }
    }
}
