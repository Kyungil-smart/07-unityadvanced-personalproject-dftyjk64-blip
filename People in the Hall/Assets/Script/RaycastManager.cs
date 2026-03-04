using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
using UnityEngine.AI;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] private LayerMask _targetHole; // Hole
    [SerializeField] private float _rayLength;
    [SerializeField] private NavMeshAgent _characterAgent; // charater
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
            _characterAgent.SetDestination(hit.point);
            Debug.Log($"{hit.transform.name} 감지, 거리: {hit.distance}, 감지 좌표: {hit.point}");
        }
    }

    private void Init()
    {
        _cam = Camera.main;
    }
}
