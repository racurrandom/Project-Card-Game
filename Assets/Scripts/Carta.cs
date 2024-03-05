using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{

    bool onHand;
    bool active;
    bool beingHovered;

    [HideInInspector] public GameObject hand;

   

    // Start is called before the first frame update
    void Start()
    {


        onHand = true;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (onHand) OnHand();
    }

    void OnHand()
    {
        transform.position = hand.transform.position;
        if (beingHovered) transform.position += transform.up * 0.2f;
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        

    }
    
    private void OnMouseDown()
    {
        PlaceCard();
    }

    private void OnMouseOver()
    {
        beingHovered = true;
        print("hola");
    }

    private void OnMouseExit()
    {
        beingHovered = false;
    }

    void PlaceCard()
    {
        


        for(int i = 0; i < hand.GetComponent<Hand>().targets.Count; i++)
        {
            if (!hand.GetComponent<Hand>().targets[i].GetComponent<Target>().ocupado)
            {
                onHand = false;
                transform.position = hand.GetComponent<Hand>().targets[i].transform.position;
                transform.LookAt(Vector3.up, Vector3.up);
                return;
            }

        }

        


    }



}
