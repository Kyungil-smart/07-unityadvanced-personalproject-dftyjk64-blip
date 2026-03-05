using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.AI;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] private LayerMask _targetHole;
    [SerializeField] private float _rayLength = 100f;
    [SerializeField] private List<NavMeshAgent> _charaterAgent = new List<NavMeshAgent>();
    private Camera _cam;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            RayShot(); 
        } 
    }
    private void RayShot()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayLength, _targetHole))
        {
            HoleManager hole = hit.transform.GetComponent<HoleManager>();

            if (hole != null) 
            {
                foreach (NavMeshAgent corretAgent in _charaterAgent)
                { 
                    if (corretAgent != null)
                    {
                        hole.CallToHole(corretAgent);
                    }
                }
            }
        }
    }

    private void Init()
    {
        _cam = Camera.main;
    }
}
