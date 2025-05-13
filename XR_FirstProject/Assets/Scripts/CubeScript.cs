using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;


#region Les differents Objectif realiser
    /* 
        Interation avec un gameObject
        Ajout d'evenement lorsque l'on passe devant
        Ajout d'evenement lorqque l'on clic
        Apprend a changer la couleur/taille/position
        realisation d'un timer qui modifie la couleur
    */
#endregion



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
    private bool _isRotating;
    private bool _toggleClic = false;

    private float _initialScaleX = 1f;
    private float _initialScaleY = 1f;
    private float _initialScaleZ = 1f;
    //[Header("Scale Settings")]

    //[SerializeField, Range(1, 3)]
    //private float _anotheScaleX = 1f;
    //[SerializeField,Range(1,3)]
    //private float _anotheScaleY = 1f;
    //[SerializeField,Range(1,3)]
    //private float _anotheScaleZ = 1f;


    private float _currentTime;
    [SerializeField]
    private float _colorChangeTime = 2f;


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
        
    }

    // Update is called once per frame
    private void Update()
    {
        _myTransform.position += _myTransform.forward * movementSpeed * Time.deltaTime;
        _currentTime += Time.deltaTime;
        if ( _currentTime >= _colorChangeTime )
        {
            _currentTime = 0;
            _randomX = Random.Range(0.0f, 1.0f);
            _randomY = Random.Range(0.0f, 1.0f);
            _randomZ = Random.Range(0.0f, 1.0f);
            _material.color = new Color(_randomX, _randomY, _randomZ);
            
        }


        //placer les actions qui doit etre realiser celon des condition
        if (!_isRotating) return; 
        
        Quaternion currentRotation = _myTransform.rotation;
        currentRotation = currentRotation * Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        _myTransform.rotation = currentRotation;
        
        if (!_toggleClic) return ;
        _myTransform.rotation *= Quaternion.Euler(rotationSpeed * Time.deltaTime, 0, 0);



    }
    //Lors du clic on change l'etat de toggleClic
    void OnMouseDown()
    {
        //_toggleClic = !_toggleClic;
        _isRotating = !_isRotating;
    }
    private void OnMouseOver()
    {
        
        //Intervien quand le curseur passe devant l'objet
        
            
    }
    //private void OnMouseEnter()
    //{
        
    //    _randomX = Random.Range(0.0f, 1.0f);
    //    _randomY = Random.Range(0.0f, 1.0f);
    //    _randomZ = Random.Range(0.0f, 1.0f);
    //    _material.color = new Color(_randomX, _randomY, _randomZ);
    //    _myTransform.localScale = new Vector3(_anotheScaleX ,_anotheScaleY ,_anotheScaleZ);  
        
    //}
    private void OnMouseExit()
    {
        _material.color = _colorInit;
        _myTransform.localScale = new Vector3(_initialScaleX, _initialScaleY, _initialScaleZ);
    }
    public void SayHello()
    {
        _isRotating=!_isRotating;
        _randomX = Random.Range(0.0f, 1.0f);
        _randomX = Random.Range(0.0f, 1.0f);
        _randomY = Random.Range(0.0f, 1.0f);
        _randomZ = Random.Range(0.0f, 1.0f);
        _material.color = new Color(_randomX, _randomY, _randomZ);
    }
}

