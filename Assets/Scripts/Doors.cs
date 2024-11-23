using UnityEngine;

public class Doors : MonoBehaviour
{

    public CameraScript camera;
    public Transform c1;
    public Transform c2;
    public Transform c3;
    public Transform c4;
    public Transform c5;
    public Transform c6;
    public Transform c7;
    public Transform c8;
    public Transform c9;
    public Transform c10;
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "door")
        {
            switch (other.transform.name) 
            {
                case "1":
                    camera.endMarker1 = c1; break;
                case "2":
                    camera.endMarker1 = c2; break;
                case "3":
                    camera.endMarker1 = c3; break;
                case "4":
                    camera.endMarker1 = c4; break;
                case "5":
                    camera.endMarker1 = c5; break;
                case "6":
                    camera.endMarker1 = c6; break;
                case "7":
                    camera.endMarker1 = c7; break;
                case "8":
                    camera.endMarker1 = c8; break;
                case "9":
                    camera.endMarker1 = c9; break;
                case "10":
                    camera.endMarker1 = c10; break;
            }
           
        }
    }
}
