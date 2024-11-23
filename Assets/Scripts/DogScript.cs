using UnityEngine;

public class DogScript : MonoBehaviour
{

    public Animator animator;
    public GameObject objectToLookAt;
    void Start()
    {
        
    }

    void Update()
    {
        if (objectToLookAt.transform.position.x < this.transform.position.x)
        {
            animator.SetBool("toTheLeft", true);
        }else
        {
            animator.SetBool("toTheLeft", false);
        }

        if (objectToLookAt.transform.position.y < this.transform.position.y)
        {
            animator.SetBool("toTheDown", true);
        }
        else
        {
            animator.SetBool("toTheDown", false);
        }

    }
}
