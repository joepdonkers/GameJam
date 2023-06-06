using UnityEngine;

public class HideObjectsScript : MonoBehaviour
{
    private void Start()
    {
        HideObjects();
    }

    private void HideObjects()
    {
        GameObject[] objectsToHide = GameObject.FindGameObjectsWithTag("HideObjects");

        foreach (GameObject obj in objectsToHide)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
    }
}