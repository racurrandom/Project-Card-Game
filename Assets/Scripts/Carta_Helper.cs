using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
using UnityEngine.Events;
using TMPro;

public class Carta_Helper : MonoBehaviour
{

    [Header("Hoologramas")]
    [SerializeField] public Material hologramMat;
    [SerializeField] public Material hologramMatAttack;
    [SerializeField] public AnimatorController holoController;
    [SerializeField] public float hologramHieght = 4;
    [SerializeField] public float hologramSize = 2;
    [SerializeField] public Mesh[] models;

    [Header("Animación")]
    [SerializeField] public float moveSpeed = 14;

    [Header("Materiales")]
    [SerializeField] public Material[] Faces;

    [Header("Stats")]
    [SerializeField] public GameObject stats;
    [SerializeField] public TextMeshPro attackNum;
    [SerializeField] public TextMeshPro healthNum;



}
