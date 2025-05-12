using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;  // Référence au personnage
    public Transform thirdPersonCameraPosition;  // Position de la caméra en TPS
    public float rotationSpeed = 5f;  // Vitesse de rotation de la caméra
    public float fpsRotationSpeed = 5f;  // Vitesse de rotation FPS (plus faible pour la sensibilité)

    private Camera cam;
    private bool isInFirstPerson = true;
    private Vector3 thirdPersonPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;  // Obtient la caméra principale
        thirdPersonPosition = thirdPersonCameraPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleCameraSwitch();  // Permet de passer de TPS à FPS
        if (isInFirstPerson)
        {
            HandleFirstPersonCamera();  // Gère la caméra FPS
        }
        else
        {
            HandleThirdPersonCamera();  // Gère la caméra TPS
        }
    }
    void HandleCameraSwitch()
    {
        if (Input.GetKeyDown(KeyCode.C))  // Changer de vue avec la touche 'C'
        {
            isInFirstPerson = !isInFirstPerson;

            if (isInFirstPerson)
            {
                // Positionne la caméra à la tête du joueur pour FPS
                cam.transform.SetParent(player);  // La caméra devient un enfant du joueur
                cam.transform.localPosition = new Vector3(0f, 1f, 0f);  // Ajuste la hauteur
                cam.transform.localRotation = Quaternion.identity;
            }
            else
            {
                // Repositionne la caméra en TPS derrière le joueur
                cam.transform.SetParent(null);  // Libère la caméra de l'objet joueur
                cam.transform.position = thirdPersonPosition;  // Positionne la caméra à la position définie pour la vue TPS
            }
        }
    }

    void HandleFirstPersonCamera()
    {
        // Mouvement de la caméra FPS en fonction des mouvements de la souris
        //float horizontal = Input.GetAxis("Mouse X") * fpsRotationSpeed;
        float vertical = Input.GetAxis("Mouse Y") * fpsRotationSpeed;

        // Limiter l'angle de la caméra en FPS (pour éviter la rotation excessive)
        vertical = Mathf.Clamp(vertical, -90f, 90f);

        //player.Rotate(Vector3.up * horizontal);  // Rotation horizontale du joueur
        cam.transform.Rotate(Vector3.right * vertical);  // Rotation verticale de la caméra
    }

    void HandleThirdPersonCamera()
    {
        // Rotation de la caméra en TPS avec les touches de souris
        float horizontal = Input.GetAxis("Mouse X") * rotationSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Appliquer la rotation au personnage (pour tourner dans la direction de la caméra)
        player.Rotate(Vector3.up * horizontal);

        // Rotation verticale de la caméra TPS (limite pour éviter trop d'inclinaison)
        thirdPersonPosition.x = Mathf.Clamp(thirdPersonPosition.x + vertical, -10f, 10f);

        // Déplacer la caméra selon la position définie
        cam.transform.position = thirdPersonPosition;
    }
}
