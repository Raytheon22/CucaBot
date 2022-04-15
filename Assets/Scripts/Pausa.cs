using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject UIOpciones;
    [SerializeField] GameObject UIFondo;

    public void Fondo()
    {
        UIFondo.SetActive(true);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        SceneManager.LoadScene("Menu");
        ManagerDeNivel.Pausa = false;
    }
    public void Opciones()
    {
        GameObject UI = Instantiate(UIOpciones, Vector3.zero, Quaternion.identity);
        UI.SendMessage("RecibirUiAnterior", this.gameObject);
        this.gameObject.SetActive(false);
    }
    public void VolverAlJuego()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        ManagerDeNivel.Pausa = false;
        UIFondo.SetActive(false);
        this.gameObject.SetActive(false);
    }

}
