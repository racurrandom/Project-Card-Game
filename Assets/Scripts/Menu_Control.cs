using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Scenes/Scene Game/Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
