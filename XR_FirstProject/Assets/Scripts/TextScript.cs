using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    private string theName;
    public TMP_InputField _InputField;
    public TMP_Text _TextMeshPro;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {


    }



    void Start()
    {
        //code here

    }

    public void DisplayText()
    {
        theName = _InputField.text;
        if (string.IsNullOrWhiteSpace(theName))
        {
            _TextMeshPro.text = $"Me prend pas pour un idiot et met ton pseudo";
        }
        else
        {
            _TextMeshPro.text = $"Bienvenu {theName}";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    
}
