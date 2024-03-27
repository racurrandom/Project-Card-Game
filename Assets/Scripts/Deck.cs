using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    [SerializeField] GameObject carta;
    [SerializeField] GameObject Hand;

    private void OnMouseDown()
    {

        Carta obj = Instantiate(carta, transform.position + Vector3.up, transform.rotation).GetComponent<Carta>();

        //Hacer que se meta script de carta random, bro

        obj.handObj = Hand;
        obj.onHand = true;
        obj.active = false;

        Hand.GetComponent<Hand>().AddCard(obj);

    }

    

}
