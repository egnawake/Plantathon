using System;
using UnityEngine;
using TMPro;

public class Planter : MonoBehaviour
{
    [SerializeField] private Plant[] plants;
    [SerializeField] private PlantControls plantControls;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text modeText;
    [SerializeField] private int potCost;

    private Collider currentCollider;
    private int selectedPlant;
    private int interactionMode;
    private int coins;

    public int Coins {
        get => coins;
        set
        {
            if (coins + value < 0)
                coins = 0;
            else
                coins = value;

            coinsText.text = coins.ToString();
        }
    }
    
    private int SelectedPlant
    {
        get => selectedPlant;
        set
        {
            selectedPlant = value;
            plantControls.SetSelectedPlant(plants[selectedPlant].gameObject.name);
        }
    }

    public int PotCost => potCost;
    
    public void SelectNextPlant()
    {
        int selection = SelectedPlant + 1;
        if (selection >= plants.Length)
            selection = 0;

        SelectedPlant = selection;
    }

    public void SelectPreviousPlant()
    {
        int selection = SelectedPlant - 1;
        if (selection < 0)
            selection = plants.Length - 1;

        SelectedPlant = selection;
    }

    public void BeginPlanting()
    {
        interactionMode = 1;
        modeText.text = "Planting";
    }

    public void BeginSelling()
    {
        interactionMode = 2;
        modeText.text = "Selling";
    }

    public bool Buy(int cost)
    {
        if (Coins < cost)
            return false;

        Coins -= cost;
        return true;
    }

    private void UpdateCollider()
    {
        Camera cam = Camera.main;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
            currentCollider = hit.collider;
        else
            currentCollider = null;
    }

    private void ProcessClick()
    {
        if (currentCollider == null)
            return;

        Pot pot = currentCollider.GetComponent<Pot>();
        if (pot != null)
        {
            ProcessPot(pot);
        }
    }

    private void ProcessPot(Pot pot)
    {
        if (interactionMode == 0 && !pot.Placed)
        {
            pot.Place();
            return;
        }

        if (interactionMode == 1)
        {
            pot.Plant(plants[SelectedPlant]);
            return;
        }
        
        if (interactionMode == 2)
        {
            pot.Sell();
            return;
        }
    }

    private void Start()
    {
        SelectedPlant = 0;
        Coins = 100;
        interactionMode = 0;
        modeText.text = "Placing pots";
    }

    private void Update()
    {
        UpdateCollider();

        if (Input.GetButtonDown("Cancel"))
        {
            interactionMode = 0;
            modeText.text = "Placing pots";
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ProcessClick();
        }
    }
}
