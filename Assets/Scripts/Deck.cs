using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    [SerializeField] GameObject carta;
    [SerializeField] GameObject Hand;

    private void OnMouseDown()
    {
        Carta obj = Instantiate(carta).GetComponent<Carta>();
        obj.hand = Hand;

        Hand.GetComponent<Hand>().cartas.Add(obj.gameObject);

    }


}
