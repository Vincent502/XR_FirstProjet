using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour
{
    [Header( "Option")]
    [SerializeField]
    public float maxLife = 100;
    [SerializeField, Range( 0, 100 )]
    public float currentLife = 100;
    [SerializeField]
    public float minLife = 0;
    [SerializeField]
    public TMP_Text _text;
    public Slider _lifeBar;
    private float healing;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lifeBar.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentLife > maxLife) _text.text = $"Tu essaie de tricher ?";

        if (currentLife <= minLife)
        {
            _text.text = $"tu es mort !";
        }
    }
    public void DecreaseLifePoint()
    {
        if (currentLife > minLife) 
        { 
            currentLife += -10;
            _lifeBar.value = currentLife;
        }



    }
    public void IncreaseLife()
    {
        if(currentLife < maxLife)
        {
            healing = maxLife - currentLife;
            currentLife += healing;
            _lifeBar.value = currentLife;
        }

    }
}
