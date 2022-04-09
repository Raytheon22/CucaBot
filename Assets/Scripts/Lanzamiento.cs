using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamiento : MonoBehaviour
{
    //! Este script se encarga de administrar el lanzamiento de objetos.
    public GameObject chancla;
    public GameObject ObjetoInstanciado;
    private float FuerzaDeLanzamiento;
    private bool CargandoLanzamiento;
    [SerializeField] float LimiteDeLanzamiento;
    void Start()
    {
        FuerzaDeLanzamiento = 500;
    }
    void Update()
    {
        Debug.Log(FuerzaDeLanzamiento);
        if ((Input.GetKeyDown(KeyCode.Mouse0)))
        {
            CargandoLanzamiento = true;
        }
        if (CargandoLanzamiento)
        {
            if (FuerzaDeLanzamiento < LimiteDeLanzamiento)
            {
                FuerzaDeLanzamiento = FuerzaDeLanzamiento + 500 * Time.deltaTime;
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            ObjetoInstanciado = Instantiate(chancla, this.gameObject.transform.position, Random.rotation);
            ObjetoInstanciado.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * FuerzaDeLanzamiento, ForceMode.Acceleration);
            FuerzaDeLanzamiento = 500;
            CargandoLanzamiento = false;
        }
    }
}
