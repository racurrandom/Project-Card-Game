using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [HideInInspector] public Hand ActiveHand;

    [SerializeField] Deck Deck;

    //TEMPORAL
    [SerializeField] Hand Enemy;




    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            GiveCardToEnemy();
        }
    }

    void GiveCardToEnemy()
    {
        Deck.GenerateCard(Enemy.gameObject, true);
    }

}
