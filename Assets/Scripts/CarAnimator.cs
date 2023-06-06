using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimator : MonoBehaviour
{
    private const string IS_DRIVING = "IsDriving";
    [SerializeField] private CarController carController;
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool(IS_DRIVING, true);
    }
}
