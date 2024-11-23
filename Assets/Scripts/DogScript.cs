using UnityEngine;

public class DogScript : MonoBehaviour
{

    public Animator animator;
    public GameObject objectToLookAt;
    public BoxCollider2D collider;
    public AudioSource audioSource;
    void Start()
    {

    }

    void Update()
    {
        float posX = objectToLookAt.transform.position.x - this.transform.position.x;
        float posY = objectToLookAt.transform.position.y - this.transform.position.y;



        animator.SetFloat("posX", posX);
        animator.SetFloat("posY", posY);
        animator.SetFloat("posHorizontalNegVertical", Mathf.Abs(posX) - Mathf.Abs(posY));



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            animator.SetTrigger("Bark");
            audioSource.Play();
        }

    }
}