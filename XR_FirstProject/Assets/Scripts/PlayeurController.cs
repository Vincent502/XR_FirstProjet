using UnityEngine;

public class PlayeurController : MonoBehaviour
{
    public float moveSpeed = 5f;// vitesse de deplacement
    public float jumpForce = 5f; // Force de saut
    private Rigidbody rb;
    private bool isGrounded;
    private bool isSprint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Récupère le Rigidbody attaché à l'objet
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprint = true;
            moveSpeed = moveSpeed * 2.5f;
           // print($"left shift pushed vitesse :{moveSpeed}");
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprint = false;
            moveSpeed = moveSpeed / 2.5f;
            //print($"left shift unpushed vitesse : {moveSpeed}");
        }
        // Déplacement du personnage
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou flèches gauche/droite
        float vertical = Input.GetAxis("Vertical"); // W/S ou flèches haut/bas
        
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        Vector3 sprint = new Vector3(horizontal, 0, vertical) * moveSpeed * 2 * Time.deltaTime;

        // Appliquer le mouvement
        if (isSprint)
        {
            rb.MovePosition(transform.position + sprint);
        }
        rb.MovePosition(transform.position + movement);
        

        // Saut (si le personnage est au sol)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

        void IsSprint(Input input)
        {
            
        }
        void OnCollisionEnter(Collision other)
        {
            // Vérifie si le personnage touche le sol pour savoir s'il peut sauter
            if (other.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
}
