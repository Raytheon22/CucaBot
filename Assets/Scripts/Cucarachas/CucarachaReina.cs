using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CucarachaReina : Cucarachas
{
    [SerializeField] GameObject BarraDeVida;
    [SerializeField] GameObject[] Entidad;
    void Start()
    {
        Rotacion();
        Invoke("AtaqueEspecial", TiempoDeAtaqueEspecial);
    }
    public override void RecibirDaño(int Daño)
    {
        base.RecibirDaño(Daño);
        Velocidad = Velocidad * 2;

    }
    public override void AtaqueEspecial()
    {
        base.AtaqueEspecial();
        for (int n = 0; n < 2; n++)
        {
            Instantiate(Entidad[Random.Range(0, Entidad.Length)], transform.position, transform.rotation);
        }
    }
    public override void Morir()
    {
        ManagerDeNivel.Victoria = true;
        Invoke("cargarNivel", 4);
    }
    public override void Curarse()
    {

    }
    void cargarNivel()
    {
        SceneManager.LoadScene("Menu");
    }
}

