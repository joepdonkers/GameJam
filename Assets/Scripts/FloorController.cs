using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorController : MonoBehaviour
{
    public PhysicMaterial slipperyMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            // Apply slippery material to the floor
            Collider floorCollider = GetComponent<Collider>();
            floorCollider.material = slipperyMaterial;
        }
    }
}