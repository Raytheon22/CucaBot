using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaOjota : MonoBehaviour
{

    [SerializeField] GameObject chancla;
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
                ObjetoInstanciado = Instantiate(chancla, transform.position, transform.rotation);
                ObjetoInstanciado.SendMessage("RecibirInformacion", gameObject);
                ObjetoInstanciado.GetComponent<Rigidbody>().AddForce(transform.forward * FuerzaDeLanzamiento, ForceMode.Impulse);
                ObjetoInstanciado.GetComponent<Rigidbody>().AddTorque(transform.up * -200, ForceMode.Impulse);
                FuerzaDeLanzamiento = 50;
                CargandoLanzamiento = false;
            }
        }
    }
}
