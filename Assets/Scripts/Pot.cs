using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private MeshRenderer activeModel;
    [SerializeField] private MeshRenderer inactiveModel;
    [SerializeField] private Transform plantPivot;
    [SerializeField] private Planter planter;

    private Plant pottedPlant = null;

    public bool Placed { get; private set; }
    public bool Planted => pottedPlant != null;
    public Plant PottedPlant => pottedPlant;

    public void Place()
    {
        if (!planter.Buy(planter.PotCost))
            return;

        Placed = true;
        activeModel.enabled = true;
        inactiveModel.enabled = false;
    }

    public void Plant(Plant plant)
    {
        if (!Placed)
            return;

        if (pottedPlant != null)
            return;

        if (!planter.Buy(plant.Cost))
            return;

        pottedPlant = Instantiate(plant, plantPivot.transform.position,
            plantPivot.transform.rotation);
    }

    public void Water()
    {
        pottedPlant.Water();
    }

    public void GiveLight()
    {
        pottedPlant.GiveLight();
    }

    public void Sell()
    {
        if (pottedPlant == null)
            return;

        if (!pottedPlant.ReadyToSell)
            return;

        planter.Coins += pottedPlant.Value;
        Destroy(pottedPlant.gameObject);
        pottedPlant = null;
    }
}
