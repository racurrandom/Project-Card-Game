using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private Deck _deck;
    public static Deck deck => game._deck;

    private UI_Manager _ui_manager;
    public static UI_Manager ui_manager => game._ui_manager;

    Settings settings;

    //Variables
    public enum State { Placing, Activating, Attacking};
    public static State state;
    

    [SerializeField] static int monsterTurns = 2;
    private static int _monsterCounter = 1;
    public static int monsterCounter
    {
        get => _monsterCounter;

        set
        {
            if (_monsterCounter > monsterTurns) _monsterCounter = 1;
            else _monsterCounter = value;
        }
    }


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
            _deck = FindAnyObjectByType<Deck>();
            _player = GameObject.Find("Player").GetComponent<Hand>();
            _enemy = GameObject.Find("Enemigo").GetComponent<Hand>();
            _activeHand = _player;
            _watingHand = _enemy;
            _ui_manager = FindAnyObjectByType<UI_Manager>();
            Debug.Log(activeHand.name);
            Debug.Log(watingHand.name);
        }
        catch 
        {

        }

    }

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

        if (Input.GetKeyDown("p"))
        {
            PassTurn();
        }

        try
        {

            if (player.health <= 0)
            {
                SceneManager.LoadScene("Scenes/Scenes EndGame/GameOver");
                Destroy(this);
            }

            if (enemy.health <= 0)
            {
                SceneManager.LoadScene("Scenes/Scenes EndGame/Win");
                Destroy(this);
            }
        }
        catch
        {

        }
    }

    void GiveCardToEnemy()
    {
        deck.GenerateCard(enemy.gameObject, true);
    }


    public bool PassTurn()
    {
        if (Advance()) {
            //Codigo de pasar turno aqui

            Attack();

            ui_manager.ToggleStateButton();

            
            deck.GenerateCard(watingHand.gameObject, monsterCounter == 1 ? true : false);
            if (activeHand == player) monsterCounter++;

            if(activeHand == enemy) StartCoroutine(enemy.gameObject.GetComponent<Enemy_AI>().MakeMove());
            Debug.Log(activeHand.name);

            return true;
        }

        return false;
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

            
            
            Debug.Log(activeHand.name + ", " + _activeHand);
            Debug.Log(watingHand.name+ ", " + _watingHand);

            return true;
        }

        state++;

        return false;
        
    }

}
