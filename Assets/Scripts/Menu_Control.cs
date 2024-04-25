using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour
{

    [SerializeField] GameObject Main;
    [SerializeField] GameObject Options;

    private void Start()
    {
        Main.SetActive(true);
        Options.SetActive(false);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Scenes/Scene Game/Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ToggleOptions()
    {
        Main.SetActive(!Main.activeSelf);
        Options.SetActive(!Options.activeSelf);
    }






}
