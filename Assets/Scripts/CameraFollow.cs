using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Le personnage à suivre
    public Vector3 offset;   // Décalage entre la caméra et le personnage
    public float smoothSpeed = 0.125f; // Vitesse de suivi lisse

    void LateUpdate()
    {
        // Position cible de la caméra
        Vector3 desiredPosition = target.position + offset;

        // Transition fluide vers la position cible
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Appliquer la position
        transform.position = smoothedPosition;
    }
}
