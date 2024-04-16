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

        
        ToggleHologram();

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


}
