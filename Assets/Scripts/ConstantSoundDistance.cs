using JetBrains.Annotations;
using UnityEngine;

public class ConstantSoundDistance : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - target.transform.position.x,2)+Mathf.Pow(
            this.transform.position.y-target.transform.position.y,2));
        if (distanceToTarget < 5)
        {

        }
    }
}
