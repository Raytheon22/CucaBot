using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    private float AceleracionY;

    void Update()
    {
        //* ROTACION VERTICAL DE LA CAMARA.
        AceleracionY += -Input.GetAxis("Mouse Y") * ManagerConfiguraciones.Sensibilidad * Time.deltaTime;
        AceleracionY = Mathf.Clamp(AceleracionY, -90, 90);
        transform.localRotation = Quaternion.Euler(AceleracionY, 0, 0f);
    }
}
