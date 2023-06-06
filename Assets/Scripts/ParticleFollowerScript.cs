using UnityEngine;

public class ParticleFollowerScript : MonoBehaviour
{
    public Transform target; // Reference to the car's transform

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
        }
    }
}