using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoadScript : MonoBehaviour
{

    public Animator transition;
    public AudioSource audioSource;
    public int duration = 1;
    private bool played = false;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) 
    {
        transition.SetTrigger("Start");
        if (levelIndex == 1 && !played) 
        {
            played = true;
            audioSource.Play();
        }

        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene(levelIndex);
    }
}
