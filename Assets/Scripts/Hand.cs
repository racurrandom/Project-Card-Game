using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<GameObject> cartas;
    public List<GameObject> targets;


    private void Start()
    {
        
        foreach (GameObject target in GameObject.FindObjectsOfType<GameObject>())
        {
            if (target.name == "Card Target") targets.Add(target);
        }
    }

}
