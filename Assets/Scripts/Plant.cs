using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private int baseValue;
    [SerializeField] private int waterRequired;

    private int waterLevel;

    public int Cost => cost;
    public int Value => baseValue;
    public bool ReadyToSell => waterLevel == waterRequired;
    public string Name => gameObject.name;
    public int WaterLevel => waterLevel;
    public int WaterRequired => waterRequired;

    public void Water()
    {
        if (waterLevel == waterRequired)
            return;

        if (waterRequired > 0)
        {
            waterLevel += 1;
        }
    }
}
