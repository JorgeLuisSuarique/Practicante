using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// se usa para cargar la escena del juego.
    /// </summary>
    /// <param name="nameScene"></param>
    public void CargarScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        
    }
    /// <summary>
    /// se usa para el boton de salir del juego.
    /// </summary>
    public void Salir()
    {
        Application.Quit();
    }
}
