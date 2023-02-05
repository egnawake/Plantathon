using UnityEngine;
using TMPro;

public class PlantTooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text plantNameText;
    [SerializeField] private GameObject waterLevelText;
    [SerializeField] private GameObject lightLevelText;

    private RectTransform rectTransform;
    private Vector2 originalPos;
    private TMP_Text waterLevelTextComponent;
    private TMP_Text lightLevelTextComponent;

    public string PlantName
    {
        set
        {
            plantNameText.text = value;
        }
    }

    public (int, int) WaterLevel
    {
        set
        {
            (int current, int total) = value;
            if (total <= 0)
            {
                waterLevelText.SetActive(false);
            }
            else
            {
                waterLevelText.SetActive(true);
                waterLevelTextComponent.text = $"Water: {current.ToString()}/{total.ToString()}";
            }
        }
    }

    public (int, int) LightLevel
    {
        set
        {
            (int current, int total) = value;
            if (total <= 0)
            {
                lightLevelText.SetActive(false);
            }
            else
            {
                lightLevelText.SetActive(true);
                lightLevelTextComponent.text = $"Light: {current.ToString()}/{total.ToString()}";
            }
        }
    }

    public void Open()
    {
        rectTransform.anchoredPosition = originalPos;
    }

    public void Close()
    {
        rectTransform.anchoredPosition = new Vector2(-1000f, -1000f);
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        rectTransform.anchoredPosition = new Vector2(-1000f, -1000f);
        waterLevelTextComponent = waterLevelText.GetComponent<TMP_Text>();
        lightLevelTextComponent = lightLevelText.GetComponent<TMP_Text>();
    }
}
