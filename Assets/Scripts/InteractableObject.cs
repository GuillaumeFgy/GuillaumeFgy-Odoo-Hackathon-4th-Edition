using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Scene4Controller controller = FindObjectOfType<Scene4Controller>();
            if (controller != null)
            {
                controller.OnTelephoneInteracted();
            }
        }
    }
}
