using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojota : MonoBehaviour
{
    private bool Regresando;
    private GameObject UbicacionManoJugador;


    [SerializeField] List<AudioClip> Sonidos;
    void OnCollisionEnter(Collision ObjetoColisionado)
    {
        if (ObjetoColisionado.gameObject.tag == "Enemigos")
        {
            ObjetoColisionado.gameObject.SendMessage("RecibirDaño", 1);
            GetComponent<AudioSource>().PlayOneShot(Sonidos[0], 2 * ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos);
            Invoke("Regresar", 0.5f);
        }
        else
        {
            Invoke("Regresar", 1.2f);
            GetComponent<AudioSource>().PlayOneShot(Sonidos[1], ManagerConfiguraciones.ConfiguracionesJuego.VolumenEfectos);
        }
    }
    public void RecibirInformacion(GameObject Ubicacion)
    {
        UbicacionManoJugador = Ubicacion;
    }

    void Update()
    {
        MovimientoDeRegreso();
    }
    void Regresar()
    {
        GetComponent<Collider>().enabled = false;
        Destroy(GetComponent<Rigidbody>());
        Regresando = true;

    }
    void MovimientoDeRegreso()
    {
        if (Regresando == true)
        {
            if (Vector3.Distance(transform.position, UbicacionManoJugador.transform.position) < 0.4f)
            {
                ManagerDeNivel.OjotaEnEscena = false;
                Destroy(this.gameObject);
            }
            transform.position = Vector3.MoveTowards(transform.position, UbicacionManoJugador.transform.position, 100 * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, UbicacionManoJugador.transform.rotation, 800 * Time.deltaTime);
        }
    }
}
