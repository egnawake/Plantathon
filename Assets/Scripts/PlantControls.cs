using UnityEngine;
using TMPro;

public class PlantControls : MonoBehaviour
{
    [SerializeField] private TMP_Text selectedPlantNameText;
    [SerializeField] private TMP_Text selectedPlantCostText;
    [SerializeField] private TMP_Text selectedPlantValueText;

    public void SetSelectedPlant(Plant plant)
    {
        selectedPlantNameText.text = plant.Name;
        selectedPlantCostText.text = $"Cost: {plant.Cost.ToString()}";
        selectedPlantValueText.text = $"Value: {plant.Value.ToString()}";
    }
}
