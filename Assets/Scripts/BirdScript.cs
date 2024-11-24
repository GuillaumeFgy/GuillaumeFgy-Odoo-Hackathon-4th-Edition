using UnityEngine;
using UnityEngine.Audio;

public class BirdScript : MonoBehaviour
{
    public BoxCollider2D collider;
    public AudioSource audioSource;
    public Animator animator;
    bool isFlying = false;

    void Update()
    {
        Fly();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Play();
            animator.SetTrigger("isPlayerNear");
            isFlying = true;
            
        }

    }

    private void Fly()
    {
        if (isFlying)
        {
            Vector3 targetPos = new Vector3(-15, -3, -1);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, 3 * Time.deltaTime);
        }
        
    }


}
