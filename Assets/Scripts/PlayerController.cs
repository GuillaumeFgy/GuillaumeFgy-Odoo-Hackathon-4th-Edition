using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Vitesse du personnage

    void Update()
    {
        // Récupérer les entrées des flèches directionnelles (ou WASD)
        float moveX = Input.GetAxis("Horizontal"); // Flèche gauche/droite
        float moveY = Input.GetAxis("Vertical");   // Flèche haut/bas

        // Calculer le déplacement
        Vector3 movement = new Vector3(moveX, moveY, 0f);

        // Appliquer le déplacement au personnage
        transform.position += movement * speed * Time.deltaTime;
    }
}
