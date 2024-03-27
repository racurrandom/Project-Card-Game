using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{

    //Components
    [HideInInspector] public GameObject handObj;
    public Hand hand => handObj.GetComponent<Hand>();

    //Variables
    [HideInInspector] public Vector3 position;
    Vector3 displacement;
    [SerializeField] float moveSpeed = 1f;

    //States
    [HideInInspector] public bool onHand;
    [HideInInspector] public bool active;
    [HideInInspector] bool beingHovered;

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
        transform.position = Vector3.MoveTowards(transform.position, position + displacement, moveSpeed * Time.deltaTime);
        displacement = Vector3.zero;
        if (onHand) OnHand();
        else Placed();
        
    }

    void OnHand()
    {
        //Levantar la carta si tiene el raton encima
        if (beingHovered) displacement = Vector3.up * 0.2f;

        //Mirar a la camara
        transform.LookAt(Camera.main.transform.position, Vector3.up);

        
    }

    void Placed()
    {
        //Levantar la carta si tiene el raton encima
        if (beingHovered) displacement = Vector3.up * 0.1f;


    }

    protected virtual void OnMouseDown()
    {
       if (onHand) PlaceCard();
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

        //Check si hay lugar disponible 
        for(int i = 0; i < hand.targets.Count; i++)
        {
            if (!hand.targets[i].GetComponent<Target>().ocupado)
            {
                onHand = false;
                position = hand.targets[i].transform.position;
                transform.localEulerAngles = -Vector3.right * 90f + Vector3.up * 180f;
                hand.targets[i].GetComponent<Target>().ocupado = true;

                break;
            }
        }

        //Actualizar posicion de mano
        hand.UpdateCardsPlacement();
    }



}
