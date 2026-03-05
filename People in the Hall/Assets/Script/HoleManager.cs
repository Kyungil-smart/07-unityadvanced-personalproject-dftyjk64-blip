using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.AI;

public class HoleManager : MonoBehaviour
{
    [SerializeField] private string _holeColor;

    public void CallToHole(NavMeshAgent agent)
    {
        if (agent.name.Contains(_holeColor))
        {
            CharaterManager charManager = agent.GetComponent<CharaterManager>();

            if (charManager != null) 
            {
                Debug.Log($"{agent.name}이 {name}으로 이동");
                charManager.MoveToHole(transform.position);
            }
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains(_holeColor))
        {
            Destroy(other.gameObject, 0.5f);
        }
    }
}
