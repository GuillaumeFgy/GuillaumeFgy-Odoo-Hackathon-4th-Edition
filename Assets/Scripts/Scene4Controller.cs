using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour changer de scène

public class Scene4Controller : MonoBehaviour
{
    public AudioSource singleAudioSource;         // Source pour les audios uniques
    public AudioSource loopingAudioSource;        // Source pour les audios en boucle

    public AudioClip audio1;                      // Audio 1 (joué après 1 sec)
    public AudioClip audio2;                      // Audio 2 (joué après 1 sec)
    public AudioClip audio3Loop;                  // Audio 3 (en boucle, après 1 sec)
    public AudioClip audio4Loop;                  // Audio 4 (en boucle, après 1 sec)
    public AudioClip audio5;                      // Audio 5 (joué 2 sec après interaction)

    public GameObject telephoneObject;            // Téléphone que le joueur doit toucher

    private bool telephoneInteracted = false;     // Vérifie si le téléphone a été touché

    public LevelLoadScript levelLoad;

    void Start()
    {
        // Lancer les audios séquentiellement
        Invoke(nameof(PlayAudio1), 1f); // Audio 1 après 1 sec
    }

    void PlayAudio1()
    {
        PlaySingleAudio(audio1);
        Invoke(nameof(PlayAudio2), 1f); // Audio 2 après 1 sec
    }

    void PlayAudio2()
    {
        PlaySingleAudio(audio2);
        Invoke(nameof(StartAudio3Loop), 1f); // Audio 3 (boucle) après 1 sec
    }

    void StartAudio3Loop()
    {
        PlayLoopingAudio(audio3Loop);
        Invoke(nameof(StartAudio4Loop), 1f); // Audio 4 (boucle) après 1 sec
    }

    void StartAudio4Loop()
    {
        PlayLoopingAudio(audio4Loop);

        // Attendre que le joueur interagisse avec le téléphone
        if (telephoneObject != null)
        {
            telephoneObject.SetActive(true); // S'assurer que le téléphone est actif
        }
    }

    public void OnTelephoneInteracted()
    {
        if (!telephoneInteracted)
        {
            telephoneInteracted = true;

            // Arrêter les sons en boucle
            loopingAudioSource.Stop();

            // Jouer Audio 5 après 2 secondes
            Invoke(nameof(PlayAudio5), 2f);
        }
    }

    void PlayAudio5()
    {
        PlaySingleAudio(audio5);

        // Charger Scene5 1 seconde après la fin d'audio5
        float delay = audio5 != null ? audio5.length + 1f : 1f; // Calculer le délai
        Invoke(nameof(LoadNextScene), delay);
    }

    void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            levelLoad.LoadNextLevel();
        }
        else
        {
            Debug.Log("Toutes les scènes sont terminées !");
        }
    }

    void PlaySingleAudio(AudioClip clip)
    {
        if (singleAudioSource != null && clip != null)
        {
            singleAudioSource.clip = clip;
            singleAudioSource.loop = false; // Pas de boucle pour les sons uniques
            singleAudioSource.Play();
        }
    }

    void PlayLoopingAudio(AudioClip clip)
    {
        if (loopingAudioSource != null && clip != null)
        {
            loopingAudioSource.clip = clip;
            loopingAudioSource.loop = true; // Activer la boucle
            loopingAudioSource.Play();
        }
    }
}
