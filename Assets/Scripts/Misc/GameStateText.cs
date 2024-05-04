using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateText : MonoBehaviour
{

    //
    public Game_Manager game; 

    //texto 
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<Game_Manager>();


        
    }

    private void Update()
    {
        text.text = Game_Manager.activeHand.name +" "+ Game_Manager.state.ToString();
    }


}
