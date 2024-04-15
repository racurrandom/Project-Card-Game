using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //Players
    [HideInInspector] public Hand activeHand;
    [SerializeField] Hand player;
    [SerializeField] Hand enemy;


    //Componets
    [SerializeField] Deck deck;



    //Variables
    public enum State { Placing, Activating, Atacking};
    public State state;


    //TEMPORAL
    



    private void Start()
    {
        state = State.Placing;
        
    }


    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            GiveCardToEnemy();
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
            return true;
        }

        state++;

        return false;
        
    }

}
