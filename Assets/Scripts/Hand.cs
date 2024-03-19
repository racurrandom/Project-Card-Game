using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cartas;
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

    private void UpdateCardsPlacement()
    {
       
        Vector3 pos;
        float leftLimit = (cartas.Count-1) * cardPadding / 2f;
       
        //Dar posicion a las cartas
        for (int i = 0; i < cartas.Count; i++)
        {
            //Solo actualiza si la carta esta en la mano
            if (cartas[i].GetComponent<Carta>().onHand)
            {
                pos = transform.position + (transform.right * (-leftLimit + i * cardPadding));
                cartas[i].transform.position = pos;
            }
        }
    }

    private void Update()
    {
        
    }

}
