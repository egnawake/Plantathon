using System;
using UnityEngine;
using TMPro;

public class Planter : MonoBehaviour
{
    [SerializeField] private Plant[] plants;
    [SerializeField] private PlantControls plantControls;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text modeText;
    [SerializeField] private PlantTooltip plantTooltip;
    [SerializeField] private int potCost;

    private Collider currentCollider;
    private int selectedPlant;
    private Tool activeTool;
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
        activeTool = Tool.Planter;
        modeText.text = "Planting";
    }

    public void BeginSelling()
    {
        activeTool = Tool.Seller;
        modeText.text = "Selling";
    }

    public void BeginWatering()
    {
        activeTool = Tool.WateringCan;
        modeText.text = "Watering";
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

    private void ProcessHover()
    {
        if (currentCollider == null)
        {
            plantTooltip.Close();
            return;
        }

        Pot pot = currentCollider.GetComponent<Pot>();
        if (pot != null)
        {
            plantTooltip.PlantName = pot.PottedPlant != null ? pot.PottedPlant.Name : "Pot";
            plantTooltip.WaterLevel = pot.PottedPlant != null
                ? (pot.PottedPlant.WaterLevel, pot.PottedPlant.WaterRequired)
                : (0, -1);
            plantTooltip.Open();
        }
        else
        {
            plantTooltip.Close();
        }
    }

    private void ProcessPot(Pot pot)
    {
        if (activeTool == Tool.PotPlacer && !pot.Placed)
        {
            pot.Place();
            return;
        }

        if (activeTool == Tool.Planter)
        {
            pot.Plant(plants[SelectedPlant]);
            return;
        }
        
        if (activeTool == Tool.Seller)
        {
            pot.Sell();
            return;
        }

        if (activeTool == Tool.WateringCan)
        {
            pot.Water();
            return;
        }
    }

    private void Start()
    {
        SelectedPlant = 0;
        Coins = 100;
        activeTool = Tool.PotPlacer;
        modeText.text = "Placing pots";
    }

    private void Update()
    {
        UpdateCollider();

        ProcessHover();

        if (Input.GetButtonDown("Cancel"))
        {
            activeTool = Tool.PotPlacer;
            modeText.text = "Placing pots";
        }

        if (Input.GetButtonDown("Fire1"))
        {
            ProcessClick();
        }
    }
}
