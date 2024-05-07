using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta_Hechizo : Carta
{

    public enum Carta
    {
        Healing_Potion,
        Fire_Cristal,
        Magical_Wand,
        Mindbender_Mushrooms,
        Fire_Demon,
        Blessing_of_Nature,
        Second_Chance,
        True_Damage_Potion
    }

    public Carta carta;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        tipo = Tipo.Hechizo;

        //Select random card
        carta = (Carta)UnityEngine.Random.Range(0, (int)Enum.GetValues(typeof(Carta)).Cast<Carta>().Max() + 1);

        ChangeFront(carta.ToString());

        switch (carta.ToString())
        {
            case "Healing_Potion":

                Activate += Events.Heal;
                Activate += Events.DestroyUp;

                break;

            case "Fire_Cristal":



                break;

            case "Magical_Wand":



                break;
        }


    }

}
