using UnityEngine;

public class ColliderTriggerSound : MonoBehaviour
{
    public BoxCollider2D collider;
    public AudioSource audioSource;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        { 

        }
    }
}
