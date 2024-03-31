using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Carta : MonoBehaviour
{
    //Holograma
    [SerializeField] private Material hologramMat => GetComponent<Carta_Helper>().hologramMat;
    [SerializeField] private AnimatorController holoController => GetComponent<Carta_Helper>().holoController;
    [SerializeField] private float hologramHieght => GetComponent<Carta_Helper>().hologramHieght;
    [SerializeField] private float hologramSize => GetComponent<Carta_Helper>().hologramSize;
    [SerializeField] private Mesh[] models => GetComponent<Carta_Helper>().models;
    private GameObject hologram;

    //Animacion
    [SerializeField] private float moveSpeed => GetComponent<Carta_Helper>().moveSpeed;

    //Materiales
    [SerializeField] protected Material[] Faces => GetComponent<Carta_Helper>().Faces;

    //Components
    [HideInInspector] public GameObject handObj;
    public Hand hand => handObj.GetComponent<Hand>();

    

    //Variables
    [HideInInspector] public Vector3 position;
    Vector3 displacement;
    

    //States
    [HideInInspector] public bool onHand;
    [HideInInspector] public bool placed = false;
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
    protected virtual void Start()
    {
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
        if (placed) ShowHologram();
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

                placed = true;

                break;
            }
        }

        //Actualizar posicion de mano
        hand.UpdateCardsPlacement();
    }


    private void ShowHologram()
    {

        GameObject obj = Instantiate(hologram, this.transform.position + Vector3.up * hologramHieght / 10, Quaternion.Euler(Vector3.zero), null);
        obj.transform.localScale = Vector3.one * hologramSize / 100;
        obj.SetActive(true);

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

}
