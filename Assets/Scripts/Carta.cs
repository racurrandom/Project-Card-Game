using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    //Holograma
    [SerializeField] protected Material hologramMat => GetComponent<Carta_Helper>().hologramMat;
    [SerializeField] protected Material hologramMatAttack => GetComponent<Carta_Helper>().hologramMatAttack;
    [SerializeField] protected AnimatorController holoController => GetComponent<Carta_Helper>().holoController;
    [SerializeField] protected float hologramHieght => GetComponent<Carta_Helper>().hologramHieght;
    [SerializeField] protected float hologramSize => GetComponent<Carta_Helper>().hologramSize;
    [SerializeField] protected Mesh[] models => GetComponent<Carta_Helper>().models;
    protected GameObject hologram;

    //Animacion
    [SerializeField] private float moveSpeed => GetComponent<Carta_Helper>().moveSpeed;

    //Materiales
    [SerializeField] protected Material[] Faces => GetComponent<Carta_Helper>().Faces;

    

    //Components
    [HideInInspector] public GameObject handObj;
    public Hand hand => handObj.GetComponent<Hand>();
    Game_Manager game => hand.game;

    //Eventos
    protected delegate void ActivateAction();
    protected event ActivateAction Activate;
    public Carta_Eventos Events = new Carta_Eventos();

    //Variables
    [HideInInspector] public Vector3 position;
    protected Vector3 displacement;
    protected Game_Manager.State state => Game_Manager.state;
    protected String activeHand => Game_Manager.activeHand.gameObject.name;

    //States
    [HideInInspector] public bool onHand;
    [HideInInspector] public bool placed = false;
    [HideInInspector] public bool active;
    [HideInInspector] bool beingHovered;

    //Parameters
    public int health = 1;
    public int damage = 1;

    //Enums
    public enum Tipo
    {
        Monstruo,
        Hechizo,
        Equipo
    }
    [HideInInspector] public Tipo tipo;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        Events.carta = this;

        hologram = new GameObject();


        MeshFilter filter = hologram.AddComponent<MeshFilter>();
        MeshRenderer renderer = hologram.AddComponent<MeshRenderer>();
        Animator anim = hologram.AddComponent<Animator>();
        filter.mesh = this.models[0];
        renderer.material = this.hologramMat;
        anim.runtimeAnimatorController = holoController;
        hologram.transform.SetParent(this.transform);
        hologram.SetActive(false);

       

    }

    // Update is called once per frame
    protected virtual void Update()
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
        if(hand.player == Hand.Player.player1) transform.LookAt(Camera.main.transform.position, Vector3.up);

        
        
    }

    protected virtual void Placed()
    {
        //Levantar la carta si tiene el raton encima
        if (beingHovered) displacement = Vector3.up * 0.1f;

        

    }

    protected void OnMouseDown()
    {
        //Solo si es del jugador
        if (hand.player == 0) Interact();

    }

    private void OnMouseOver()
    {
        //Solo si es del jugador
        if(hand.player == 0) beingHovered = true;

    }

    private void OnMouseExit()
    {
        beingHovered = false;
    }

    public virtual void Interact()
    {
        if (activeHand == hand.name)
        {
            switch (state)
            {
                case Game_Manager.State.Placing:

                    if (onHand) PlaceCard();

                    break;

                case Game_Manager.State.Activating:

                    if (placed) ToggleActivate();

                    break;

                case Game_Manager.State.Attacking:

                    break;
            }

        }
    } 

    protected void PlaceCard()
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

                placed = true;
                hand.AddPlaced(this);

                break;
            }
        }

        //Actualizar posicion de mano
        hand.UpdateCardsPlacement();
    }


    public virtual void ToggleActivate()
    {
        //se cambia de estado
        active = !active;

        //se añade a la lista de activos de su mano si es monstruo
        

            

        if (active)
        {
               

            //realizamos la accion Activate
            if (Activate != null) Activate();
        }
        else
        {
                
                
        }
            
           
        

        
    }

    

    protected void ChangeFront(String name)
    {

        foreach(Material mat in Faces)
        {
            //Si el nombre del material coincide con el nombre de la carta
            if(mat.name == name)
            {
                //No se puede cambiar el material de un mesh renderer indivudualmente asi que se hace otro array y se sustituye
                Material[] array = { transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterials[0], mat };
                transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterials = array;
                
                return;
            }
        }

        Material[] error = { transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterials[0], Faces[0] };
        transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterials = error;

    }


    protected void DoActivate()
    {
        if (Activate != null) Activate();
    }

    public void GetDestroyed()
    {
        hand.RemoveActive(this);
        hand.RemoveAttacker(this);
        hand.RemoveCard(this);

        Destroy(this.gameObject);
    }

}
