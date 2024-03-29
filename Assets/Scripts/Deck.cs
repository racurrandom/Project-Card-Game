using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deck : MonoBehaviour
{

    [SerializeField] GameObject carta;
    [SerializeField] GameObject Hand;

    private void OnMouseDown()
    {
        //GenerateCard(true);
        StartCoroutine(GenerateMonster());
    }

    public void GenerateCard(bool monstruo)
    {
        //Se crea la carta
        GameObject obj = Instantiate(carta, transform.position + Vector3.up, transform.rotation);

        

        //Se crea carta de hechizo o equipo aleatoriamente
        switch (Random.Range(0, 1))
        {
            case 0:
                obj.AddComponent<Carta_Equipo>();
                break;
            case 1:
                obj.AddComponent<Carta_Hechizo>();
                break;
        }

        //Inicializacion
        obj.GetComponent<Carta>().handObj = Hand;
        obj.GetComponent<Carta>().onHand = true;
        obj.GetComponent<Carta>().active = false;

        //Se añade a la mano 
        Hand.GetComponent<Hand>().AddCard(obj.GetComponent<Carta>());

        //Se crea la carta de monstruo 
        if (monstruo) StartCoroutine(GenerateMonster());
        
    }

    private IEnumerator GenerateMonster()
    {
        //Espera 0.5 segundo a generar la carta 
        yield return new WaitForSeconds(0.5f);

        //Se crea la carta
        GameObject obj = Instantiate(carta, transform.position + Vector3.up, transform.rotation);

        //Se le da tipo monstruo
        obj.AddComponent<Carta_Monstruo>();

        //Inicializacion
        obj.GetComponent<Carta>().handObj = Hand;
        obj.GetComponent<Carta>().onHand = true;
        obj.GetComponent<Carta>().active = false;

        //Se añade a la mano 
        Hand.GetComponent<Hand>().AddCard(obj.GetComponent<Carta>());
    }



}
