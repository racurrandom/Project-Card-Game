using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    //
    public Game_Manager game;

    //Componentes
    public TextMeshProUGUI stateText;
    public Slider playerHealth;
    public Slider enemyHealth;


    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<Game_Manager>();

        

    }

    private void Update()
    {
        enemyHealth.value = Game_Manager.enemy.health;
        playerHealth.value = Game_Manager.player.health;
        

        stateText.text = Game_Manager.activeHand.name + " " + game.state.ToString();
    }
}
