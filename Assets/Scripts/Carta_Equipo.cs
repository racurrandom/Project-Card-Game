using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Carta_Equipo : Carta
{

    public enum Carta
    {
        Power_Vanisher,
        Force_Redistribution,
        Temporary_Cage,
        Golden_Key

    }

    public Carta carta;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        tipo = Tipo.Equipo;

        //Select random card
        carta = (Carta)UnityEngine.Random.Range(0, (int)Enum.GetValues(typeof(Carta)).Cast<Carta>().Max() + 1);

        ChangeFront(carta.ToString());

        switch (carta.ToString())
        {
            case "Power_Vanisher":

                

                break;

            case "Force_Redistribution":

               

                break;

            case "Temporary_Cage":



                break;
        }
    }
}
