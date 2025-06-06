using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int food = 100;
    public int water = 100;
    public int population = 20;
    public int workers = 10;
    public TMP_Text foodText;
    public TMP_Text waterText;
    public TMP_Text populationText;
    public TMP_Text workersText;
    private ResourceChange nextDayChange = new();
    [SerializeField] private SceneController sceneController;

    public void ConsumeResources()
    {
        ResourceChange resourceChange = new(-population, -population * 2, 0, 0);
        ChangeResources(resourceChange);
    }

    public void ProduceResources()
    {
        ResourceChange resourceChange = new(workers, workers, 0, 0);
        ChangeResources(resourceChange);
    }

    public void ChangeResources(ResourceChange resourceChange)
    {
        food += resourceChange.foodChange;
        water += resourceChange.waterChange;
        population += resourceChange.populationChange;
        workers += resourceChange.workersChange;

        food = Mathf.Max(food, 0);
        water = Mathf.Max(water, 0);
        population = Mathf.Max(population, 0);
        workers = Mathf.Max(workers, 0);
    }

    public void AddToNextDayChange(ResourceChange resourceChange)
    {
        nextDayChange.foodChange += resourceChange.foodChange;
        nextDayChange.waterChange += resourceChange.waterChange;
        nextDayChange.populationChange += resourceChange.populationChange;
        nextDayChange.workersChange += resourceChange.workersChange;
    }

    public void ExecuteNextDayChange()
    {
        ChangeResources(nextDayChange);
        nextDayChange = new();
    }

    void Update()
    {
        foodText.SetText(food.ToString());
        waterText.SetText(water.ToString());
        populationText.SetText(population.ToString());
        workersText.SetText(workers.ToString());

         if (food == 0 || water == 0 || population == 0)
        {
            sceneController.GameOver();
        }
    }
}
