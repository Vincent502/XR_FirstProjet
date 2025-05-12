using UnityEngine;

public class MyFIrstScript : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Update()
    {
        // Rotation autour de l’axe X en continu
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }


    
}


