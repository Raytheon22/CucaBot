using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ojota : MonoBehaviour
{
    private bool Mato;
    private bool Regresando;
    private GameObject UbicacionManoJugador;
    void OnCollisionEnter(Collision ObjetoColisionado)
    {
        if (ObjetoColisionado.gameObject.tag == "Enemigos")
        {
            ObjetoColisionado.gameObject.SendMessage("RecibirDaño");
            Invoke("Regresar", 0.5f);
        }
        else
        {
            Invoke("Regresar", 1);
        }

    }
    public void RecibirInformacion(GameObject Ubicacion)
    {
        UbicacionManoJugador = Ubicacion;
    }

    void Update() //! PRUEBA
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Regresar();
        }
        MovimientoDeRegreso();
    }
    void Regresar()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Regresando = true;
    }

    void MovimientoDeRegreso()
    {
        if (Regresando == true)
        {
            if (Vector3.Distance(transform.position, UbicacionManoJugador.transform.position) < 0.5f)
            {
                ManagerDeNivel.CantidadDeOjotas--;
                Debug.Log("Volver");
                Destroy(this.gameObject);
            }
            transform.position = Vector3.MoveTowards(transform.position, UbicacionManoJugador.transform.position, 100 * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, UbicacionManoJugador.transform.rotation, 500 * Time.deltaTime);
        }
    }
}
