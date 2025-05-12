using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // R�f�rence au personnage
    public Transform thirdPersonCameraPosition;  // Position de la cam�ra en TPS
    public float rotationSpeed = 5f;  // Vitesse de rotation de la cam�ra
    public float fpsRotationSpeed = 5f;  // Vitesse de rotation FPS (plus faible pour la sensibilit�)

    private Camera cam;
    private bool isInFirstPerson = true;
    private Vector3 thirdPersonPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;  // Obtient la cam�ra principale
        thirdPersonPosition = thirdPersonCameraPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraSwitch();  // Permet de passer de TPS � FPS
        if (isInFirstPerson)
        {
            HandleFirstPersonCamera();  // G�re la cam�ra FPS
        }
        else
        {
            HandleThirdPersonCamera();  // G�re la cam�ra TPS
        }
    }
    void HandleCameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C))  // Changer de vue avec la touche 'C'
        {
            isInFirstPerson = !isInFirstPerson;

            if (isInFirstPerson)
            {
                // Positionne la cam�ra � la t�te du joueur pour FPS
                cam.transform.SetParent(player);  // La cam�ra devient un enfant du joueur
                cam.transform.localPosition = new Vector3(0f, 1f, 0f);  // Ajuste la hauteur
                cam.transform.localRotation = Quaternion.identity;
            }
            else
            {
                // Repositionne la cam�ra en TPS derri�re le joueur
                cam.transform.SetParent(null);  // Lib�re la cam�ra de l'objet joueur
                cam.transform.position = thirdPersonPosition;  // Positionne la cam�ra � la position d�finie pour la vue TPS
            }
        }
    }

    void HandleFirstPersonCamera()
    {
        // Mouvement de la cam�ra FPS en fonction des mouvements de la souris
        //float horizontal = Input.GetAxis("Mouse X") * fpsRotationSpeed;
        float vertical = Input.GetAxis("Mouse Y") * fpsRotationSpeed;

        // Limiter l'angle de la cam�ra en FPS (pour �viter la rotation excessive)
        vertical = Mathf.Clamp(vertical, -90f, 90f);

        //player.Rotate(Vector3.up * horizontal);  // Rotation horizontale du joueur
        cam.transform.Rotate(Vector3.right * vertical);  // Rotation verticale de la cam�ra
    }

    void HandleThirdPersonCamera()
    {
        // Rotation de la cam�ra en TPS avec les touches de souris
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Appliquer la rotation au personnage (pour tourner dans la direction de la cam�ra)
        player.Rotate(Vector3.up * horizontal);

        // Rotation verticale de la cam�ra TPS (limite pour �viter trop d'inclinaison)
        thirdPersonPosition.x = Mathf.Clamp(thirdPersonPosition.x + vertical, -10f, 10f);

        // D�placer la cam�ra selon la position d�finie
        cam.transform.position = thirdPersonPosition;
    }
}
