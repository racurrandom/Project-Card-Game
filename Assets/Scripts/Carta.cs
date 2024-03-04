using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{

    bool facingDown;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            FlipCard();
        }

    }

    private void OnMouseDown()
    {
        FlipCard();
    }

    void FlipCard()
    {
        facingDown = !facingDown;
        transform.localEulerAngles = Vector3.forward * (facingDown ?  0f : 180f) ;
    }

}
