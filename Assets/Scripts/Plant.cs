using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private string plantName;
    [SerializeField] private int cost;
    [SerializeField] private int baseValue;
    [SerializeField] private int waterRequired;
    [SerializeField] private int lightRequired;

    private int waterLevel;
    private int lightLevel;

    public int Cost => cost;
    public int Value => baseValue;
    public bool ReadyToSell => waterLevel == waterRequired && lightLevel == lightRequired;
    public string Name => plantName;
    public int WaterLevel => waterLevel;
    public int WaterRequired => waterRequired;
    public int LightLevel => lightLevel;
    public int LightRequired => lightRequired;

    public void Water()
    {
        if (waterLevel == waterRequired)
            return;

        if (waterRequired > 0)
        {
            waterLevel += 1;
        }
    }

    public void GiveLight()
    {
        if (lightLevel == lightRequired)
            return;

        if (lightRequired > 0)
        {
            lightLevel += 1;
        }
    }
}
