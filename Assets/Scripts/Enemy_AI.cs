using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    private Hand hand;




    // Start is called before the first frame update
    void Start()
    {
        hand = gameObject.GetComponent<Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MakeMove()
    {
        //Se inicia un temporizador de 1s
        yield return new WaitForSeconds(1f);



        switch (Game_Manager.state)
        {
            case Game_Manager.State.Placing:
                hand.cartas[1].GetComponent<Carta>().Interact();
                break;

            case Game_Manager.State.Activating:
                //hand.cartas[1].GetComponent<Carta>().Interact();
                break;

            case Game_Manager.State.Attacking:
                hand.cartas[1].GetComponent<Carta>().Interact();
                print("pog");
                break;
        }

        if (Game_Manager.state != Game_Manager.State.Attacking) StartCoroutine(MakeMove());

        
        FindAnyObjectByType<Game_Manager>().PassTurn();
    }


    private void Prioretize()
    {

    }

}
