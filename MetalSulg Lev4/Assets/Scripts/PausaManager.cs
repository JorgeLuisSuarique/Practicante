using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PausaManager : MonoBehaviour
{
    /// <summary>
    /// variables publicas
    /// </summary>
    public GameObject pausa;
    public GameObject PanelPausa;
    public static bool InputHabilitado = true;
    public static bool isPause = true;

    /// <summary>
    /// se llama la variable buleana em el Start y se pone verdadero.
    /// </summary>
    private void Start()
    {
        isPause = true;
    }
    /// <summary>
    /// es para cuando este en pausa se inabilite las funciones del juego.
    /// </summary>
    public void PausarJuego()
    {
        if (Time.timeScale == 1.0F)
        {
            InputHabilitado = false;
            PausarJ();
            Time.timeScale = 0.0F;
            isPause = !isPause;
        }
        else
        {
            Time.timeScale = 1.0F;
            PanelJuego();
            InputHabilitado = true;
            isPause = false;
        }
    }
    /// <summary>
    /// se utuliza para que el boton de pausa.
    /// </summary>
    public void PausarJ()
    {
        pausa.SetActive(true);
        PanelPausa.SetActive(true);
    }
    /// <summary>
    /// para que se active el panel del pausa en el juego.
    /// </summary>
    public void PanelJuego()
    {
        pausa.SetActive(true);
        PanelPausa.SetActive(false);
    }
    /// <summary>
    /// para que puda cambiar de escena con el boton.
    /// </summary>
    /// <param name="nombreScene"></param>
    public void MenuScene(string nombreScene)
    {
        SceneManager.LoadScene(nombreScene);
    }
}
