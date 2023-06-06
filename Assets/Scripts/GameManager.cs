using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text loseText;
    public int ScoreToWin;
    public ParticleSystem particleSystem; // Reference to the particle system

    private bool gameEnded = false;

    void Start()
    {
        loseText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void Win()
    {
        EndGame("You Win!");
    }

    public void Die()
    {
        EndGame("You Lose!");
        PlayParticleEffect();
    }

    public void PlayParticleEffect()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }

    void EndGame(string endMessage)
    {
        if (!gameEnded)
        {
            gameEnded = true;
            loseText.text = endMessage;
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}