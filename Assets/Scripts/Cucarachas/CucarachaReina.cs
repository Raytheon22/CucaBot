using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CucarachaReina : Cucarachas
{
    //! FALTA PULIR Y AGREGAR COSAS
    public override void RecibirDaño()
    {
        base.RecibirDaño();
        Velocidad = Velocidad * 2;
    }
    public override void Morir()
    {
        SceneManager.LoadScene("Menu");
    }
}

