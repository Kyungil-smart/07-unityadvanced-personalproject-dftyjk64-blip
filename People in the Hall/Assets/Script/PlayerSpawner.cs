using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _charaterPrefab;
    private Queue<GameObject> _charaters = new();

    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        GameObject charater;

        charater = Instantiate(_charaterPrefab);

        _charaters.Enqueue(charater);
    }

    private void DeSpawn()
    { 
     if (_charaters.Count == 0) return;

     GameObject charater = _charaters.Dequeue();

        Destroy(charater);
    }
}
