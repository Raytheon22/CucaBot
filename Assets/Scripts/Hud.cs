using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    //! Este script se encarga de manipular el HUD.
    [SerializeField] GameObject UIPausa;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ManagerDeNivel.Pausa == false)
        {
            UIPausa.SetActive(true);
            UIPausa.SendMessage("Fondo");
            ManagerDeNivel.Pausa = true;
            Time.timeScale = 0;
        }
    }
}
