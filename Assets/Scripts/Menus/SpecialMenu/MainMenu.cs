using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  
    public void OnClick_Tutorial()
    {
        MenuManager.OpenMenu(Menu.Setting_Menu, gameObject);
    }

    public void OnClick_Game()
    {
        SceneManager.LoadScene(12);
        // ABRIR ESCENA DE JUEGO
    }

    public void OnClick_Quit()
    {
        Application.Quit();
    }

    public void OnClick_Exploration()
    {
        SceneManager.LoadScene(1);
    }
}
