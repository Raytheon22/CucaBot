using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Cucarachas : MonoBehaviour
{
    //!Este script se encarga de realizar el movimiento y acciones de las cucarachas.
    [SerializeField] int ResistenciaDeGolpe;
    public int Velocidad;
    [SerializeField] protected int TiempoDeAtaqueEspecial;
    [SerializeField] int AleatoriedadDeGiro;
    [SerializeField] int Nerviosa;
    [SerializeField] float Sensor;
    private int CantidadDeGolpesRecibidos;
    private bool Herida;
    void Start()
    {
        Rotacion();
        ManagerDeNivel.CantidadDeCucarachas.Add(this);
        Invoke("AtaqueEspecial", TiempoDeAtaqueEspecial);

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
    protected void Rotacion()
    {
        int VelocidadRotacion = 1 * Random.Range(-AleatoriedadDeGiro, AleatoriedadDeGiro);
        transform.Rotate(0, VelocidadRotacion, 0);
        Invoke("Rotacion", Random.Range(1, Nerviosa));
    }
    private void Sensores()
    {
        RaycastHit Objetivo;
        Debug.DrawRay(transform.position, transform.forward * Sensor, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out Objetivo, Sensor))
        {
            if (Objetivo.transform.tag == "Escenario")
            {
                transform.rotation = Quaternion.FromToRotation(transform.up, Objetivo.normal) * transform.rotation;
            }
        }
    }
    public virtual void AtaqueEspecial()
    {
        Invoke("AtaqueEspecial", TiempoDeAtaqueEspecial);
    }
    public virtual void RecibirDaño(int Daño)
    {
        Herida = true;
        Velocidad = Velocidad / 2;
        CantidadDeGolpesRecibidos += Daño;
        if (CantidadDeGolpesRecibidos == ResistenciaDeGolpe || CantidadDeGolpesRecibidos > ResistenciaDeGolpe)
        {
            Morir();
        }
    }
    public virtual void Morir()
    {
        ManagerDeNivel.CargaDeAerosol++;
        ManagerDeNivel.CucarachasMuertas++;
        ManagerDeNivel.CantidadDeCucarachas.Remove(this);
        Destroy(this.gameObject);
    }

    public virtual void Curarse()
    {
        if (Herida == true)
        {
            Velocidad = Velocidad * CantidadDeGolpesRecibidos * 2;
            CantidadDeGolpesRecibidos = 0;
            Herida = false;
        }
    }
}




