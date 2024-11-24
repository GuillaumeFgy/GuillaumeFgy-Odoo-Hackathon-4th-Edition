using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public AudioClip sceneStartSound; // Ajoutez une variable pour le clip audio
    private AudioSource audioSource;

    void Start()
    {
        // Configurez l'AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sceneStartSound;
        audioSource.playOnAwake = false;

        // Jouez le son dès que la scène est lancée
        PlaySceneSound();
    }

    public void GoToScene5()
    {
        SceneManager.LoadScene("Scene5");
    }

    private void PlaySceneSound()
    {
        if (sceneStartSound != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Aucun son assigné à 'sceneStartSound'");
        }
    }
}
