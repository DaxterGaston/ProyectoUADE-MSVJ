using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorBehavior : MonoBehaviour
{
    [SerializeField] private Blackboard memoria;

    public Blackboard Memoria { get => memoria; set => memoria = value; }
    protected virtual void Awake()
    {
        memoria = GetComponent<Blackboard>();
    }
    
}
