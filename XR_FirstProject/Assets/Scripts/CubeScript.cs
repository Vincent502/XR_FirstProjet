using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;





public class Cube_Script : MonoBehaviour
{
    [Header ("Speed settings")]
    [SerializeField,Range(1,30)] private int rotationSpeed = 30;
    [SerializeField,Range(1,6)] private int movementSpeed = 3;


    private Color _colorInit = new Color(0.990566f, 0.4872297f, 0f);
    private Transform _myTransform;
    private Material _material;
    private MeshRenderer _meshRend;
    private Rigidbody rb;
    private bool isGrounded;
    public float jumpForce = 5f; // Force de saut

    
    private bool isMovingForward = false;
    private bool isMovingDownward = false;
    private bool isMovingRight = false;
    private bool isMovingLeft = false;

    private void Awake()
    {
        
        Debug.Log("Le programme se reveille - Awake Debug Log");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _myTransform = transform;
        _meshRend = GetComponent<MeshRenderer>();
        _material = _meshRend.material ;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Movement direction
        if (isMovingForward) _myTransform.position += _myTransform.forward * movementSpeed * Time.deltaTime;
        if (isMovingDownward) _myTransform.position -= _myTransform.forward * movementSpeed * Time.deltaTime;
        if (isMovingRight) _myTransform.position += _myTransform.right * movementSpeed * Time.deltaTime;
        if (isMovingLeft)_myTransform.position -= _myTransform.right * movementSpeed * Time.deltaTime;
    }

    //change le status pour le deplacement
    public void IsMovingForward()
    {
        isMovingForward = !isMovingForward;
    }    
    public void IsMovingDownward()
    {
        isMovingDownward= !isMovingDownward;
    }    
    public void IsMovingRight()
    {
        isMovingRight = !isMovingRight;
    }    
    public void IsMovingLeft()
    {
        isMovingLeft = !isMovingLeft;
    }


    // on verifie les collision
    private void OnCollisionEnter(Collision collision)
    {
        var layeur = collision.gameObject.layer;
        if(layeur == 3)
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        var layeur = collision.gameObject.layer;
        if (layeur != 3)
        {
            isGrounded = false;
        }
    }


    // Saut (si le personnage est au sol)
    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up* jumpForce, ForceMode.Impulse);
        }

    }
}