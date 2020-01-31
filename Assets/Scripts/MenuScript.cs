using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PrefMenu;

    private void Start()
    {

        MainMenu.SetActive(true);
        PrefMenu.SetActive(false);
    }

    public void ToggleMenuPanels()
    {
        MainMenu.SetActive(!MainMenu.activeSelf);
        PrefMenu.SetActive(!PrefMenu.activeSelf);
    }

    public void PreferencesButton()
    {
        MainMenu.SetActive(false);
        PrefMenu.SetActive(true);
    }

    public void BackButton()
    {
        MainMenu.SetActive(true);
        PrefMenu.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }

}