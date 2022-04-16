using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] bool PuedeSpawnear;
    [SerializeField] int TiempoDeSpawn;
    [SerializeField] int OrdenDeSpawn;
    [SerializeField] int CantidadPorSpawn;
    [SerializeField] GameObject[] Entidad;

    void Start()
    {
        Invoke("SpawnearEntidad", OrdenDeSpawn);
    }
    void Update()
    {

    }
    void SpawnearEntidad() //*RECURSIVIDAD.
    {
        if (PuedeSpawnear)
        {
            Invoke("SpawnearEntidad", TiempoDeSpawn);
        }
        for (int n = 0; n < CantidadPorSpawn; n++)
        {
            Instantiate(Entidad[Random.Range(0, Entidad.Length)], transform.position, transform.rotation);
        }
    }
}
