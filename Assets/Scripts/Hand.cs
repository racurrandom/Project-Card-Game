using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cartas;
    public List<GameObject> activeMonsters;
    public List<GameObject> targets;
    [SerializeField] float cardPadding;
    enum Player { player1, player2};
    [SerializeField] Player player;

    private void Start()
    {
        
        foreach (Target target in GameObject.FindObjectsOfType<Target>())
        {
            if(target.player.ToString() == player.ToString())
            {
                targets.Add(target.gameObject);
            }
        }
    }

    public void AddCard(Carta carta)
    {
        cartas.Add(carta.gameObject);
        UpdateCardsPlacement();
    }

    public void AddActive(Carta carta)
    {
        activeMonsters.Add(carta.gameObject);

    }

    public void RemoveActive(Carta carta)
    {
        activeMonsters.Remove(carta.gameObject);
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

    private void Update()
    {
        
    }

}
