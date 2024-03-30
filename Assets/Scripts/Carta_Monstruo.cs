using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Carta_Monstruo : Carta
{

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

        
        switch (carta.ToString())
        {
            case "Chunky_Flying_Cat":
                print("gato");

                ChangeFront(carta.ToString());

                break;

            case "Mighty_Dragon":
                print("dragon");

                ChangeFront(carta.ToString());

                break;
        }




    }




}
