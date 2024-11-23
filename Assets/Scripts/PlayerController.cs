using System.Diagnostics;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Vitesse du personnage
    public AudioSource source;
    public float timerDuration = 2f; // Time in seconds
    private float timeRemaining;
    public Sonar sonar1;
    public Sonar sonar2;
    public Sonar sonar3;
    public Sonar sonar4;
    public Sonar sonar5;

    public bool timerRunning = false;

    void Update()
    {
        // Récupérer les entrées des flèches directionnelles (ou WASD)
        float moveX = Input.GetAxis("Horizontal"); // Flèche gauche/droite
        float moveY = Input.GetAxis("Vertical");   // Flèche haut/bas

        // Calculer le déplacement
        Vector3 movement = new Vector3(moveX, moveY, 0f);

        // Appliquer le déplacement au personnage
        transform.position += movement * speed * Time.deltaTime;

        Distance();
        TimerBip();
    }

    public void Distance() 
    {
        if (sonar1.detect) { timerDuration = sonar1.speed; timerRunning = true; }
        else if (sonar2.detect) { timerDuration = sonar2.speed; timerRunning = true; }
        else if (sonar3.detect) { timerDuration = sonar3.speed; timerRunning = true; }
        else if (sonar4.detect) { timerDuration = sonar4.speed; timerRunning = true; }
        else if (sonar5.detect) { timerDuration = sonar5.speed; timerRunning = true; }
        else { timerRunning = false; }
    }

    public void TimerBip()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;            }
            else
            {

                timeRemaining = timerDuration;
                source.Play();
            }
        }

    }

    public void StartTimer()
    {
        timeRemaining = timerDuration;
        timerRunning = true;
    }

    // Optional: Method to stop the timer.
    public void StopTimer()
    {
        timerRunning = false;
    }
}
