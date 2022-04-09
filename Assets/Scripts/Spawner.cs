using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //! Este script se encarga de administrar los spawners.
    [SerializeField] bool PuedeSpawnear;
    [SerializeField] int TiempoDeSpawn;
    [SerializeField] int OrdenDeSpawn;
    [SerializeField] int CantidadPorSpawn;
    [SerializeField] GameObject Entidad;

    void Start()
    {
        Invoke("SpawnearEntidad", OrdenDeSpawn);
    }
    void Update()
    {
        if (ManagerDeNivel.CantidadDeCucarachas > 10)
        {
            PuedeSpawnear = false;
        }
        else
        {
            PuedeSpawnear = true;
        }
    }
    void SpawnearEntidad() //*RECURSIVIDAD.
    {
        if (PuedeSpawnear)
        {
            Invoke("SpawnearEntidad", TiempoDeSpawn);
        }
        for (int n = 0; n < CantidadPorSpawn; n++)
        {
            ManagerDeNivel.CantidadDeCucarachas++;
            Instantiate(Entidad, transform.position, transform.rotation);
        }
    }
}
