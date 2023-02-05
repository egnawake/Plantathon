using UnityEngine;
using TMPro;

public class PlantTooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text plantNameText;
    [SerializeField] private TMP_Text waterLevelText;

    private RectTransform rectTransform;
    private Vector2 originalPos;

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
            waterLevelText.text = $"Water: {current.ToString()}/{total.ToString()}";
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
    }
}
