using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    //Listas de cartas
    public List<GameObject> cartas;
    public List<GameObject> placedCards;
    public List<GameObject> activeMonsters;
    public List<GameObject> attackingMonsters;
    public List<GameObject> targets;

    //Variables
    [SerializeField] float cardPadding;
    public int health = 20;


    //Components
    [HideInInspector] public Game_Manager game;

    //Enums
    public enum Player { player1, player2};
    [SerializeField] public Player player;

    private void Start()
    {
        //Get game
        game = GameObject.Find("GameManager").GetComponent<Game_Manager>();


        //Get all targets
        foreach (Target target in GameObject.FindObjectsOfType<Target>())
        {
            if(target.player.ToString() == player.ToString())
            {
                targets.Add(target.gameObject);
            }
        }
    }

    

    public void UpdateCardsPlacement()
    {
       
        Vector3 pos;

        //Recuento de crtas en mano
        int cardsOnHand = 0;
        for(int i = 0; i < cartas.Count; i++)
        {
            if (cartas[i].GetComponent<Carta>().onHand) cardsOnHand++;
        }
        float leftLimit = (cardsOnHand - 1) * cardPadding / 2f;

        int j;
        j = 0;
        //Dar posicion a las cartas
        for (int i = 0; i < cartas.Count; i++)
        {
            //Solo actualiza si la carta esta en la mano
            if (cartas[i].GetComponent<Carta>().onHand)
            {   
                pos = transform.position + (transform.right * (-leftLimit + j * cardPadding));
                cartas[i].GetComponent<Carta>().position = pos;
                j++;
            }
        }
    }

    public void AddCard(Carta carta)
    {
        //Se mete la carta a las cartas de la mano
        cartas.Add(carta.gameObject);

        //Se actualizan sus posiciones
        UpdateCardsPlacement();
    }

    public void RemoveCard(Carta carta)
    {
        cartas.Remove(carta.gameObject);
    }


    public void AddPlaced(Carta carta)
    {
        //Se mete la carta a las cartas de la mano
        placedCards.Add(carta.gameObject);

    }

    public void RemovePlaced(Carta carta)
    {
        placedCards.Remove(carta.gameObject);
    }

    public void AddActive(Carta carta)
    {
        //Se añade la carta a monstruos activos
        activeMonsters.Add(carta.gameObject);

    }

    public void RemoveActive(Carta carta)
    {
        activeMonsters.Remove(carta.gameObject);
    }


    public void AddAttacker(Carta carta)
    {
        //Se añade la carta a monstruos activos
        attackingMonsters.Add(carta.gameObject);

        

    }

    public void RemoveAttacker(Carta carta)
    {
        attackingMonsters.Remove(carta.gameObject);
    }
    private void Update()
    {
        
    }

}
