using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    //Daltonicos
    public static bool modoDaltonico;
    public static int _currentType = 0;
    public static int blindType
    {
        get => _currentType;
        
        set
        {
            if (_currentType >= 8) _currentType = 0;
            else _currentType = value;
        }
    }


}