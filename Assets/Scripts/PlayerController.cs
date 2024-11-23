using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Vitesse du personnage
    public AudioSource source;
    public float timerDuration = 2f; // Time in seconds
    private float timeRemaining;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public bool timerRunning = false;

    void Update()
    {
        // Récupérer les entrées des flèches directionnelles (ou WASD)
        float moveX = Input.GetAxis("Horizontal"); // Flèche gauche/droite
        float moveY = Input.GetAxis("Vertical");   // Flèche haut/bas

        // Calculer le déplacement
        Vector3 movement = new Vector3(moveX, moveY, 0f);
        animator.SetFloat("moveY", moveY);
        animator.SetBool("isWalking", Mathf.Abs(moveX)+Mathf.Abs(moveY)!=0);
        animator.SetBool("isWalkSide", moveX!=0);
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
        } else if (moveX > 0) 
        {
            spriteRenderer.flipX= false;
        }

        // Appliquer le déplacement au personnage
        transform.position += movement * speed * Time.deltaTime;


        TimerBip();
    }

    public void PlayBip(int speedSound)
    {


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
                timeRemaining = 0;
                source.Play();
                StartTimer();
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
