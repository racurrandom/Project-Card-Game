using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Control : MonoBehaviour
{

    [SerializeField] GameObject Main;
    [SerializeField] GameObject Options;
    [SerializeField] TMP_Dropdown BlindOptions;

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


    public void UpdateBlindOptions()
    {
        Settings._currentType = BlindOptions.value;

    }




}
