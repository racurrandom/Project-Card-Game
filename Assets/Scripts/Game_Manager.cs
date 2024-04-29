using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    private static Game_Manager game;


    //Players
    private Hand _activeHand;
    public static Hand activeHand => game._activeHand;

    private Hand _watingHand;
    public static Hand watingHand => game._watingHand;

    private Hand _player;
    public static Hand player => game._player;

    private Hand _enemy;
    public static Hand enemy => game._enemy;


    //Componets
    [SerializeField] Deck deck;
    Settings settings;

    //Variables
    public enum State { Placing, Activating, Attacking};
    public State state;


    //TEMPORAL

    private void Awake()
    {
        //New level
        if (game)
        {
            game.NewLoad();
            Destroy(gameObject);
            return;
        }
        else
        {
            NewLoad();
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }

        
    }

    private void NewLoad()
    {
        game = this;
        try
        {
            _player = GameObject.Find("Player").GetComponent<Hand>();
            _enemy = GameObject.Find("Enemigo").GetComponent<Hand>();
        }
        catch 
        {

        }

    }

    private void Start()
    {
        state = State.Placing;
        _activeHand = player;
        _watingHand = enemy;
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
        if (Advance()) Attack();



    }



    void Attack()
    {
        int damage = 0;
       


        foreach(GameObject carta in watingHand.attackingMonsters)
        {

            damage += carta.GetComponent<Carta_Monstruo>().damage;

        }


        

        foreach (GameObject carta in activeHand.activeMonsters)
        {
            int prevdamage = damage;
            damage -= carta.GetComponent<Carta_Monstruo>().health;

            if (damage < 0) damage = 0;

            carta.GetComponent<Carta_Monstruo>().health -= prevdamage - damage;
            

        }


        activeHand.health -= damage;
        if (activeHand.health < 0) activeHand.health = 0;


    }


    bool Advance()
    {
        if(((int)state) == 2)
        {
            state = State.Placing;

            //Change active player
            _activeHand = activeHand == player ? enemy : player;
            _watingHand = watingHand == player ? enemy : player;

            return true;
        }

        state++;

        return false;
        
    }

}
