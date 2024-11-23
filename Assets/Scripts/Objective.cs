using UnityEngine;

public class Objective : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Informer le SceneController que cet objectif est collecté
            SceneController sceneController = FindObjectOfType<SceneController>();
            if (sceneController != null)
            {
                sceneController.OnObjectiveCollected(gameObject);
            }
        }
    }
}
