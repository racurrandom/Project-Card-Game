using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cartas;
    public List<GameObject> targets;
    [SerializeField] float cardPadding;

    private void Start()
    {
        
        foreach (GameObject target in GameObject.FindObjectsOfType<GameObject>())
        {
            if (target.name == "Card Target") targets.Add(target);
        }
    }

    public void AddCard(Carta carta)
    {
        cartas.Add(carta.gameObject);
        UpdateCardsPlacement();
    }

    private void UpdateCardsPlacement()
    {
        print(cartas.Count);
        Vector3 pos;
        for (int i = 0; i < cartas.Count; i++)
        {
            pos = transform.position;
            pos += (transform.right * ((cartas.Count - i - 1) * cardPadding))/2;

            cartas[i].transform.position = pos;
        }
    }

    private void Update()
    {
        
    }

}
