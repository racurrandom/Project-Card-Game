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
        if (Input.GetKeyDown("a"))
        {
            FlipCard();
        }

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
        FlipCard();
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

    void FlipCard()
    {
       
    }



}
