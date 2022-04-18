using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjotaVisual : MonoBehaviour
{

    void Update()
    {
        if (ManagerDeNivel.OjotaEnEscena == true)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
