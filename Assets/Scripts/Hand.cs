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
        
        Vector3 pos;
        float leftLimit = (cartas.Count-1) * cardPadding / 2f;
       
        for (int i = 0; i < cartas.Count; i++)
        {
            pos = transform.position + (transform.right *  (-leftLimit + i * cardPadding));
            cartas[i].transform.position = pos;
        }
    }

    private void Update()
    {
        
    }

}
