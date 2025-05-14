using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    
    public GameObject _buttonConfirm;
    public GameObject _buttonInteraction;
    public GameObject _inputFieldDisplay;
    public TMP_InputField _inputField;

    
    //target panel for display
    public GameObject _menuPanel;
    public GameObject _inteactionPanel;
    


    //variuable prenant le nom de depart
    private string theName;
    public TextMesh _textMesh;
    public TMP_Text _textMeshPro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _inteactionPanel.SetActive(false);
       _buttonInteraction.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
          
    }
    
    public void DisplayText()
    {
        theName = _inputField.text;
        Debug.Log(theName);
        if (string.IsNullOrWhiteSpace(theName))
        {
            _textMeshPro.text = $"Me prend pas pour un idiot et met ton pseudo";
        }
        else
        {
            _textMesh.text = theName;
            _buttonInteraction.SetActive(true);
            _textMeshPro.text = $"Bienvenu {theName}";
            _buttonConfirm.SetActive(false);
            _inputFieldDisplay.SetActive(false);
        }

    }
    public void DisplayInteractionMenu() 
    { 
        
        _inteactionPanel.SetActive(true);
        _menuPanel.SetActive(false);
        Debug.Log("le menu est fermer");
    }
}
