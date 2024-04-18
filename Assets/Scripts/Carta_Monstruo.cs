using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Carta_Monstruo : Carta
{
    //Parameters
    public int health = 1;
    public int damage = 1;


    //States
    bool defense = false;
    bool attack = false;


    protected Carta_Eventos Events = new Carta_Eventos();

    public enum Carta
    {
        Chonky_Flying_Cat,
        Mighty_Dragon,
        The_Dead_of_the_Cuteness,
        Ethereal_Jellyfish
    }

    public Carta carta;

    protected override void Placed()
    {
        base.Placed();
        
        if(active) displacement += Vector3.up * 0.3f;

    }

    public override void ToggleActivate()
    {
        //se cambia de estado
        active = !active;
        defense = !defense;
        
        ToggleHologram(hologramMat);

        print("a");

        //se añade a la lista de activos de su mano si es monstruo
        if (active)
        {
            hand.AddActive(this);

            DoActivate();
        }
        else
        {
            hand.RemoveActive(this);
        }
    }

    public void ToggleAttack()
    {
        //se cambia de estado
        active = !active;
        attack = !attack;

        ToggleHologram(hologramMatAttack);

        //se añade a la lista de activos de su mano si es monstruo
        if (active)
        {
            hand.AddAttacker(this);

            DoActivate();
        }
        else
        {
            hand.RemoveAttacker(this);
        }



    }

    protected override void OnMouseDown()
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

                if (!defense) ToggleAttack();

                break;
        }
    }


    protected override void Start()
    {
        base.Start();
        tipo = Tipo.Monstruo;

        //Select random card
        carta = (Carta)UnityEngine.Random.Range(0, (int)Enum.GetValues(typeof(Carta)).Cast<Carta>().Max() + 1);

        //Use correct front
        ChangeFront(carta.ToString());


        switch (carta.ToString())
        {
            case "Chonky_Flying_Cat":

                Activate += Events.Test;


                break;

            case "Mighty_Dragon":
                



                break;
        }




    }



    protected void ToggleHologram(Material mat)
    {

        if (active)
        {
            GameObject obj = Instantiate(hologram, this.transform.position + Vector3.up * hologramHieght / 10, Quaternion.Euler(Vector3.zero), transform);
            obj.transform.localScale = Vector3.one * hologramSize / 100;
            obj.name = "holograma";
            obj.SetActive(true);
            obj.GetComponent<MeshRenderer>().material = mat;
        }
        else
        {
            Destroy(transform.Find("holograma").gameObject);
        }



    }


}
