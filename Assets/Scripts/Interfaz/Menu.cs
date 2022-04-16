using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    [SerializeField] GameObject UIOpciones;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void CargarNivel(string NombreDeNivel)
    {
        Efectos.reproducir();
        Time.timeScale = 1;
        Cursor.visible = false;
        ManagerDeNivel.Pausa = false;
        SceneManager.LoadScene(NombreDeNivel);
    }
    public void Opciones()
    {
        Efectos.reproducir();
        GameObject UI = Instantiate(UIOpciones, Vector3.zero, Quaternion.identity);
        UI.SendMessage("RecibirUiAnterior", this.gameObject);
        this.gameObject.SetActive(false);
    }
    public void Salir()
    {
        Efectos.reproducir();
        Application.Quit();
    }
}
