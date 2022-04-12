using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    //! Este script se encarga de administrar el lanzamiento de objetos.
    public GameObject chancla;
    public GameObject Mano;
    private GameObject ObjetoInstanciado;
    private float FuerzaDeLanzamiento;
    private bool CargandoLanzamiento;
    [SerializeField] float LimiteDeLanzamiento;
    void Start()
    {
        FuerzaDeLanzamiento = 50;
    }
    void Update()
    {
        if (ManagerDeNivel.CantidadDeOjotas == 0)
        {
            if ((Input.GetKeyDown(KeyCode.Mouse0)))
            {
                CargandoLanzamiento = true;
            }
            if (CargandoLanzamiento)
            {
                if (FuerzaDeLanzamiento < LimiteDeLanzamiento)
                {
                    FuerzaDeLanzamiento = FuerzaDeLanzamiento + 20 * Time.deltaTime;
                }
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                ManagerDeNivel.CantidadDeOjotas++;
                ObjetoInstanciado = Instantiate(chancla, Mano.transform.position, Mano.transform.rotation);
                ObjetoInstanciado.SendMessage("RecibirInformacion", Mano);
                ObjetoInstanciado.GetComponent<Rigidbody>().AddForce(Mano.transform.forward * FuerzaDeLanzamiento, ForceMode.Impulse);
                ObjetoInstanciado.GetComponent<Rigidbody>().AddTorque(transform.right * 2, ForceMode.Impulse);
                FuerzaDeLanzamiento = 50;
                CargandoLanzamiento = false;
            }
        }
    }
}
