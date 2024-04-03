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
        Chunky_Flying_Cat,
        Mighty_Dragon
    }

    public Carta carta;

    protected override void Start()
    {
        base.Start();
        tipo = Tipo.Mounstruo;

        //Select random card
        carta = (Carta)UnityEngine.Random.Range(0, (int)Enum.GetValues(typeof(Carta)).Cast<Carta>().Max() + 1);

        //Use correct front
        ChangeFront(carta.ToString());


        
      
        



        switch (carta.ToString())
        {
            case "Chunky_Flying_Cat":

                Activate += Events.Test;


                break;

            case "Mighty_Dragon":
                



                break;
        }




    }


}
