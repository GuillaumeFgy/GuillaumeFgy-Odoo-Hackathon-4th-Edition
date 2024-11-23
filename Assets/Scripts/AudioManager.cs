using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // Source audio
    public AudioClip[] audioClips;  // Clips pour chaque période de la journée (0 = Matin, 1 = Midi, etc.)
    private int currentAudioIndex = 0; // Suivi de l'audio actuel

    void Start()
    {
        // Démarrer le premier audio après un délai
        PlayAudioAfterDelay(3f); // 3 secondes après le démarrage
    }

    // Joue l'audio actuel après un délai
    public void PlayAudioAfterDelay(float delay)
    {
        if (currentAudioIndex < audioClips.Length)
        {
            // Planifie l'audio avec un délai
            Invoke(nameof(PlayCurrentAudio), delay);
        }
    }

    // Joue l'audio actuel
    private void PlayCurrentAudio()
    {
        if (audioSource != null && currentAudioIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentAudioIndex];
            audioSource.Play();
        }
    }

    // Appelé lorsque la phase change
    public void OnPhaseCompleted()
    {
        // Passer à l'audio suivant
        currentAudioIndex++;

        // Jouer l'audio de la prochaine période (3 secondes après la transition)
        PlayAudioAfterDelay(3f);
    }
}
