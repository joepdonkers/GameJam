using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text loseText;
    public int ScoreToWin;
    public ParticleSystem particleSystem; // Reference to the particle system

    void Start()
    {
        loseText.text = "";
    }

    public void Win()
    {
        loseText.text = "You Win!";
    }

    public void Die()
    {
        loseText.text = "You Lose!";
        PlayParticleEffect();
    }

    public void PlayParticleEffect()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}