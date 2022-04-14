using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CucarachaReina : Cucarachas
{
    //! FALTA PULIR Y AGREGAR COSAS
    void Start()
    {
        Rotacion();
    }
    public override void RecibirDaño(int Daño)
    {
        base.RecibirDaño(Daño);
        Velocidad = Velocidad * 2;
    }
    public override void Morir()
    {
        SceneManager.LoadScene("Menu");
    }
}

