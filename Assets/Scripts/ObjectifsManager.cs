using UnityEngine;

public class ObjectifsManager : MonoBehaviour
{
    public Transform[] phases; // Liste des phases (Matin, Midi, etc.)
    private int currentPhaseIndex = 0; // Suivi de la phase actuelle

    void Start()
    {
        // Activer uniquement la première phase
        ShowPhase(currentPhaseIndex);
    }

    void ShowPhase(int index)
    {
        // Désactiver toutes les phases
        foreach (Transform phase in phases)
        {
            phase.gameObject.SetActive(false);
        }

        // Activer la phase courante si elle existe
        if (index < phases.Length)
        {
            phases[index].gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Toutes les phases sont terminées !");
        }
    }

    public void OnPhaseCompleted()
    {
        Debug.Log("Phase terminée : " + currentPhaseIndex);

        // Passer à la phase suivante
        currentPhaseIndex++;
        ShowPhase(currentPhaseIndex);

        // Jouer l'audio pour la prochaine période
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.OnPhaseCompleted();
        }
    }
}
