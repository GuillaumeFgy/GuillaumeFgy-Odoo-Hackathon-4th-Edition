using System.Diagnostics;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform endMarker1;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endMarker1.position, speed * Time.deltaTime);
    }

    void ChangePosition() 
    {
        
    }
}
