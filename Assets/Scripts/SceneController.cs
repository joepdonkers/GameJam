using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SwitchToSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}