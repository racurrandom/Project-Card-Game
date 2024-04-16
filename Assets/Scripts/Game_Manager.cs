using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //Players
     public Hand activeHand;
    [SerializeField] Hand player;
    [SerializeField] Hand enemy;


    //Componets
    [SerializeField] Deck deck;



    //Variables
    public enum State { Placing, Activating, Attacking};
    public State state;


    //TEMPORAL
    



    private void Start()
    {
        state = State.Placing;
        activeHand = player;
    }


    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            GiveCardToEnemy();
        }

        if (Input.GetKeyDown("p"))
        {
            Advance();
        }
    }

    void GiveCardToEnemy()
    {
        deck.GenerateCard(enemy.gameObject, true);
    }


    bool Advance()
    {

       

        if(((int)state) == 2)
        {
            state = State.Placing;

            //Change active player
            activeHand = activeHand == player ? enemy : player;

            return true;
        }

        state++;

        return false;
        
    }

}
