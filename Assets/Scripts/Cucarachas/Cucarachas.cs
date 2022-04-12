using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cucarachas : MonoBehaviour
{
    //!Este script se encarga de realizar el movimiento y acciones de las cucarachas.
    [SerializeField] int ResistenciaDeGolpe;
    [SerializeField] int Velocidad;
    [SerializeField] int AleatoriedadDeGiro;
    [SerializeField] int Nerviosa;
    private int CantidadDeGolpesRecibidos;
    private bool Herida;


    void Start()
    {
        Rotacion();
        ManagerDeNivel.CantidadDeCucarachas.Add(this);
    }
    void Update()
    {
        Sensores();
        Movimiento();
    }
    private void Movimiento()
    {
        transform.Translate(Vector3.forward * Velocidad * Time.deltaTime);
    }
    private void Rotacion()
    {
        int VelocidadRotacion = 1 * Random.Range(-AleatoriedadDeGiro, AleatoriedadDeGiro);
        transform.Rotate(0, VelocidadRotacion, 0);
        Invoke("Rotacion", Random.Range(1, Nerviosa));
    }
    private void Sensores()
    {
        RaycastHit Objetivo;
        Debug.DrawRay(transform.position, transform.forward * 0.5f, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out Objetivo, 0.5f))
        {
            if (Objetivo.transform.tag == "Escenario")
            {
                transform.rotation = Quaternion.FromToRotation(transform.up, Objetivo.normal) * transform.rotation;
            }
        }
    }

    public virtual void AtaqueEspecial()
    {

    }
    public virtual void RecibirDaño()
    {
        Herida = true;
        Velocidad = Velocidad / 2;
        CantidadDeGolpesRecibidos++;
        if (CantidadDeGolpesRecibidos == ResistenciaDeGolpe)
        {
            Morir();
        }
    }
    public virtual void Morir()
    {
        ManagerDeNivel.CucarachasMuertas++;
        ManagerDeNivel.CantidadDeCucarachas.Remove(this);
        Destroy(this.gameObject);
    }
}




