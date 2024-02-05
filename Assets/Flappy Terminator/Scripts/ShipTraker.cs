using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTraker : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private float _xOffset;
    
    void Update()
    {
        var position = transform.position;
        position.x = _ship.transform.position.x + _xOffset;
        transform.position = position;
    }
}
