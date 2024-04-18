using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //Players
    public Hand activeHand;
    public Hand watingHand;
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
        watingHand = enemy;
    }


    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            GiveCardToEnemy();
        }

        if (Input.GetKeyDown("p"))
        {
            Pass();
        }
    }

    void GiveCardToEnemy()
    {
        deck.GenerateCard(enemy.gameObject, true);
    }


    public void Pass()
    {
        Advance();



    }



    void Attack()
    {
        int damage = 0;
        int defense = 0;


        foreach(GameObject carta in activeHand.attackingMonsters)
        {

            damage += carta.GetComponent<Carta_Monstruo>().damage;

        }

        foreach (GameObject carta in watingHand.activeMonsters)
        {

            defense += carta.GetComponent<Carta_Monstruo>().health;

        }





    }


    bool Advance()
    {
        if(((int)state) == 2)
        {
            state = State.Placing;

            //Change active player
            activeHand = activeHand == player ? enemy : player;
            watingHand = watingHand == player ? enemy : player;

            return true;
        }

        state++;

        return false;
        
    }

}
