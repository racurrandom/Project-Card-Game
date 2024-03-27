using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Target : MonoBehaviour
{
    public bool ocupado;
    public enum Player { player1, player2 };
    public Player player;

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        Gizmos.DrawWireCube(transform.position, transform.localScale);
#endif
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
