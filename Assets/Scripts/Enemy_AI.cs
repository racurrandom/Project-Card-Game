using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{

    private Hand hand => Game_Manager.enemy;
    private Hand PlayerHand => Game_Manager.player;

    //Prioritaziation
    float agresiviness = 0.9f;
    List<Carta> DamageList = new List<Carta>();
    List<Carta> DefenseList = new List<Carta>();
    [SerializeField] float temperature = 1;

    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator MakeMove()
    {
        //Se inicia un temporizador de 1s
        yield return new WaitForSeconds(1f);

        List<Carta> priorizada = new List<Carta>();

        switch (Game_Manager.state)
        {
            case Game_Manager.State.Placing:

                priorizada.Clear();
                priorizada = Prioretize();

                foreach (Carta carta in priorizada)
                {
                    carta.Interact();
                }

                break;

            case Game_Manager.State.Activating:

                priorizada.Clear();
                priorizada = Prioretize();

                foreach (Carta carta in priorizada)
                {
                    if(!carta.active) carta.Interact();
                }

                break;

            case Game_Manager.State.Attacking:

                priorizada.Clear();
                priorizada = Prioretize();

                foreach (Carta carta in priorizada)
                {
                    if (!carta.active) carta.Interact();
                }

                break;
        }

        if (Game_Manager.state != Game_Manager.State.Attacking) StartCoroutine(MakeMove());

        
        FindAnyObjectByType<Game_Manager>().PassTurn();
    }

    private List<Carta> Prioretize()
    {
        List<Carta> lista = new List<Carta>();

        switch (Game_Manager.state)
        {
            case Game_Manager.State.Placing:
                //Damage List recive las cartas ordenadas por daño (descendente)
                DamageList.Clear();
                foreach (GameObject carta in hand.cartas.OrderByDescending(car => car.GetComponent<Carta>().damage))
                {
                    DamageList.Add(carta.GetComponent<Carta>());
                }

                //Defens List recive las cartas ordenadas por vida (descendente)
                DefenseList.Clear();
                foreach (GameObject carta in hand.cartas.OrderByDescending(car => car.GetComponent<Carta>().health))
                {
                    DefenseList.Add(carta.GetComponent<Carta>());
                }

                lista = Select(DamageList, agresiviness).Concat( Select(DefenseList, 1 - agresiviness)).ToList();

                

                break;

            case Game_Manager.State.Activating:

                //Damage List recive las cartas ordenadas por daño (descendente)
                DamageList.Clear();
                foreach (GameObject carta in hand.placedCards.OrderByDescending(car => car.GetComponent<Carta>().damage))
                {
                    DamageList.Add(carta.GetComponent<Carta>());
                }

                //Defens List recive las cartas ordenadas por vida (descendente)
                DefenseList.Clear();
                foreach (GameObject carta in hand.placedCards.OrderByDescending(car => car.GetComponent<Carta>().health))
                {
                    DefenseList.Add(carta.GetComponent<Carta>());
                }

                lista = Select(DamageList, agresiviness).Concat(Select(DefenseList, 1 - agresiviness)).ToList();

                break;

            case Game_Manager.State.Attacking:

                //Damage List recive las cartas ordenadas por daño (descendente)
                DamageList.Clear();
                foreach (GameObject carta in hand.placedCards.OrderByDescending(car => car.GetComponent<Carta>().damage))
                {
                    DamageList.Add(carta.GetComponent<Carta>());
                }

                lista = DamageList;

                break;
        }

        return lista;
    }


    private List<Carta> Select(List<Carta> lista, float num)
    {
        List<Carta> newList = new List<Carta>();
        
        for(int i = 0; i < hand.FreeTargets() * num; i++)
        {

            int j = (int)(Random.Range(0, 0.9999999f) * temperature);

            if (lista.Count == 0) break;

            newList.Add(lista[j]);
            lista.RemoveAt(j);

        }

        return newList;
    }


}
