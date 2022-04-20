using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Cucarachas : MonoBehaviour
{
    //!Este script se encarga de realizar el movimiento y acciones de las cucarachas.
    public int ResistenciaDeGolpe;
    public int Velocidad;
    [SerializeField] List<AudioClip> Sonidos;
    [SerializeField] protected int TiempoDeAtaqueEspecial;
    [SerializeField] int AleatoriedadDeGiro;
    [SerializeField] int Nerviosa;
    [SerializeField] float Sensor;
    public int CantidadDeGolpesRecibidos;
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
        RaycastHit Abajo;
        Debug.DrawRay(transform.position, -transform.up * Sensor, Color.blue);
        if (!Physics.Raycast(transform.position, -transform.up, out Abajo, Sensor))
        {
            Vector3 v = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(v.x, v.y, 0);
        }
    }
    public virtual void AtaqueEspecial()
    {
        Invoke("AtaqueEspecial", TiempoDeAtaqueEspecial);
    }
    public virtual void RecibirDaño(int Daño)
    {
        if (Daño == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(Sonidos[Random.Range(1, Sonidos.Count)], 3 * ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos);
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(Sonidos[0], 3 * ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos);

        }
        Herida = true;
        Velocidad = Velocidad / 2;
        CantidadDeGolpesRecibidos += Daño;
        if (CantidadDeGolpesRecibidos == ResistenciaDeGolpe || CantidadDeGolpesRecibidos > ResistenciaDeGolpe)
        {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            if (Daño == 1)
            {
                ManagerDeNivel.CargaDeAerosol++;
            }
            ManagerDeNivel.CucarachasMuertas++;
            ManagerDeNivel.CantidadDeCucarachas.Remove(this);
            Velocidad = 0;
            GetComponent<Collider>().enabled = false;
            Invoke("Morir", 4f);
        }
    }
    public virtual void Morir()
    {
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

    public void MuerteTotal()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().useGravity = true;
        Velocidad = 0;
        GetComponent<Collider>().enabled = false;
    }
}




