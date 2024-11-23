using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool isCollected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;

            // Désactiver l'objet collecté
            gameObject.SetActive(false);

            // Vérifier si tous les objets de la phase sont collectés
            CheckPhaseCompletion();
        }
    }

    void CheckPhaseCompletion()
    {
        // Récupérer le parent (phase actuelle)
        Transform parentPhase = transform.parent;

        // Vérifier si tous les objets de cette phase sont désactivés
        foreach (Transform child in parentPhase)
        {
            if (child.gameObject.activeSelf) return; // Un objet reste actif
        }

        // Informer le ObjectifsManager que la phase est terminée
        ObjectifsManager objectifsManager = FindObjectOfType<ObjectifsManager>();
        if (objectifsManager != null)
        {
            objectifsManager.OnPhaseCompleted();
        }
    }
}
