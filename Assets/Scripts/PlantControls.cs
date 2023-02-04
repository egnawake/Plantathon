using UnityEngine;
using TMPro;

public class PlantControls : MonoBehaviour
{
    [SerializeField] private TMP_Text selectedPlantNameText;

    public void SetSelectedPlant(string name)
    {
        selectedPlantNameText.text = name;
    }
}
