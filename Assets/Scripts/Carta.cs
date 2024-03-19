using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{

    [HideInInspector] public bool onHand;
    [HideInInspector] public bool active;
    [HideInInspector] bool beingHovered;
    [HideInInspector] public GameObject hand;

    public enum Tipo
    {
        Mounstruo,
        Hechizo,
        Equipo
    }

    [HideInInspector] public Tipo tipo;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (onHand) OnHand();
    }

    void OnHand()
    {
       // if (beingHovered) transform.position += transform.up * 0.2f;
        transform.LookAt(Camera.main.transform.position, Vector3.up);
        

    }
    
    protected virtual void OnMouseDown()
    {
        PlaceCard();
    }

    private void OnMouseOver()
    {
        beingHovered = true;
        
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
                transform.localEulerAngles = -Vector3.right * 90f + Vector3.up * 180f;
                hand.GetComponent<Hand>().targets[i].GetComponent<Target>().ocupado = true;
                return;
            }
        }
    }



}
