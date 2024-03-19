using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta_Monstruo : Carta
{

    public enum Carta
    {
        Fire_Crystal,
        Mighty_Dragon
    }

    public Carta carta;

    private void Start()
    {
        tipo = Tipo.Mounstruo;
    }




}
