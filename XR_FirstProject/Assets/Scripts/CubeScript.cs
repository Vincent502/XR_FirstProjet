using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class Cube_Script : MonoBehaviour
{
    
    private float rotationSpeed = 30f;
    private float movementSpeed = 3f;
    private Color _colorInit = new Color(0.990566f, 0.4872297f, 0f);
    private float _randomX;
    private float _randomY;
    private float _randomZ;
    private Transform _myTransform;
    private Material _material;
    private MeshRenderer _meshRend;
    private bool _toggleClic = false;

    private void Awake()
    {
        
        Debug.Log("Le programme se reveille - Awake Debug Log");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _myTransform = transform;
        _meshRend = GetComponent<MeshRenderer>();
        _material = _meshRend.material ;
        _randomX = Random.Range(0.0f, 1.0f);
        _randomY = Random.Range(0.0f, 1.0f);
        _randomZ = Random.Range(0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_toggleClic)
        {
            _myTransform.rotation *= Quaternion.Euler(rotationSpeed * Time.deltaTime, 0, 0);
        }
        Quaternion currentRotation = _myTransform.rotation;
        currentRotation = currentRotation * Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        _myTransform.rotation = currentRotation;


        _myTransform.position += _myTransform.forward * movementSpeed * Time.deltaTime;

    }
    void OnMouseDown()
    {
        print("j'ai eu un click");
        _toggleClic = !_toggleClic;

        print(_toggleClic);
        
        
    }
    private void OnMouseOver()
    {
        
        // peut afficher les data playeur en viser 
        print("ca passe devant");
        //_material.color = Color.red;
        
            
    }
    private void OnMouseEnter()
    {
        _material.color = new Color(_randomX, _randomY, _randomZ);
    }
    private void OnMouseExit()
    {
        _material.color = _colorInit;
    }
}

