using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public AudioSource audioSource;         // Source pour jouer les sons
    public AudioClip startSound;            // Son joué au début
    public AudioClip afterFirstObjective;   // Son joué après le premier objectif
    public GameObject[] objectives;         // Les objectifs à collecter
    private int currentObjectiveIndex = 0;  // Index du prochain objectif à activer

    void Start()
    {
        // Désactiver tous les objectifs sauf le premier
        for (int i = 0; i < objectives.Length; i++)
        {
            objectives[i].SetActive(false);
        }

        // Activer le premier objectif
        ActivateNextObjective();

        // Jouer le son de début 1 seconde après le lancement de la scène
        Invoke(nameof(PlayStartSound), 1f);
    }

    void PlayStartSound()
    {
        if (audioSource != null && startSound != null)
        {
            audioSource.clip = startSound;
            audioSource.Play();
        }
    }

    public void OnObjectiveCollected(GameObject collectedObjective)
    {
        collectedObjective.SetActive(false);

        // Si c'est le premier objectif
        if (currentObjectiveIndex == 1)
        {
            // Jouer le son après le premier objectif
            Invoke(nameof(PlayAfterFirstObjectiveSound), 1f);
        }

        // Activer le prochain objectif, s'il existe
        ActivateNextObjective();
    }

    void PlayAfterFirstObjectiveSound()
    {
        if (audioSource != null && afterFirstObjective != null)
        {
            audioSource.clip = afterFirstObjective;
            audioSource.Play();
        }
    }

    void ActivateNextObjective()
    {
        if (currentObjectiveIndex < objectives.Length)
        {
            objectives[currentObjectiveIndex].SetActive(true);
            currentObjectiveIndex++;
        }
        else
        {
            // Tous les objectifs sont collectés, charger la scène suivante
            Invoke(nameof(LoadNextScene), 1f);
        }
    }

    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Toutes les scènes sont terminées !");
        }
    }
}
