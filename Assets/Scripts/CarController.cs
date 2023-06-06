using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;

    public UnityEvent onPickupCollision;
    public UnityEvent onEnemyCollision;

    private bool isDisabled = false;

    private void Update()
    {
        if (!isDisabled)
        {
            // Move the car forward
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            // Rotate the car
            float rotationAxis = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * rotationAxis * rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isDisabled)
            return;

        if (other.gameObject.CompareTag("Obstacle"))
        {
            onEnemyCollision.Invoke();
            DisableCar();
        }
    }

    private void DisableCar()
    {
        isDisabled = true;
        gameObject.SetActive(false);

        ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem ps in particleSystems)
        {
            ps.Stop();
        }
    }
}