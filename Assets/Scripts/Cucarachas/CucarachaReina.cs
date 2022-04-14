using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CucarachaReina : Cucarachas
{
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
        for (int n = 0; n < 4; n++)
        {
            Instantiate(Entidad[Random.Range(0, Entidad.Length)], transform.position, transform.rotation);
        }
    }
    public override void Morir()
    {
        SceneManager.LoadScene("Menu");
    }
    public override void Curarse()
    {

    }
}

