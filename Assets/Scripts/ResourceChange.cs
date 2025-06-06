using UnityEngine;

[System.Serializable]
public class ResourceChange
{
    public int foodChange;
    public int waterChange;
    public int populationChange;
    public int workersChange;

    public ResourceChange(int foodChange, int waterChange, int populationChange, int workersChange)
    {
        this.foodChange = foodChange;
        this.waterChange = waterChange;
        this.populationChange = populationChange;
        this.workersChange = workersChange;
    }
}
