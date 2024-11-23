using UnityEngine;

public class CatScript : MonoBehaviour
{

    public Animator animator;
    public BoxCollider2D collider;
    public AudioSource audioSource;
    float time = 0;
    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 10) 
        {
            time = 0;
            animator.SetTrigger("AFKTrigger");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioSource.Play();
        }

    }
}