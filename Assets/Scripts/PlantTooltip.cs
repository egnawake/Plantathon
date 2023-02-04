using UnityEngine;

public class PlantTooltip : MonoBehaviour
{
    private RectTransform rectTransform;

    public void Open()
    {
        Vector3 mousePos = Input.mousePosition;
        rectTransform.anchoredPosition = mousePos;
    }

    public void Close()
    {
        rectTransform.anchoredPosition = new Vector2(-1000f, -1000f);
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
