using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    //
    private Game_Manager game;

    //Componentes
    public TextMeshProUGUI stateText;
    public Slider playerHealth;
    public Slider enemyHealth;

    public GameObject Button;
    public GameObject ButtonBad;


    // Start is called before the first frame update
    void Start()
    {

        game = FindAnyObjectByType<Game_Manager>();



    }

    private void Update()
    {
        enemyHealth.value = Game_Manager.enemy.health;
        playerHealth.value = Game_Manager.player.health;


        stateText.text = Game_Manager.activeHand.name + " " + Game_Manager.state.ToString();
        
    }

    public void PassTurn()
    {

        game.PassTurn();
        

    }

    public void ToggleStateButton()
    {
        Button.SetActive(!Button.activeSelf);
        ButtonBad.SetActive(!ButtonBad.activeSelf);

    }

}
