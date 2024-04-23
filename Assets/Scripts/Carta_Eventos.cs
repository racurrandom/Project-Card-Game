using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class Carta_Eventos : MonoBehaviour
{
    public Carta carta;

    public void Test()
    {
        Debug.Log("Esto es un test");
       
    }

    public void Heal()
    {

        carta.hand.health += carta.health;


    }

    public void DestroyUp()
    {

        carta.position += Vector3.up * 3;

    }




}
