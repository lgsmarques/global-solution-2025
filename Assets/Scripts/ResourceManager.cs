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
    [SerializeField] SceneController sceneController;

    public void ConsumeResources()
    {
        food -= population * 2;
        water -= population * 3;

        food = Mathf.Max(food, 0);
        water = Mathf.Max(water, 0);
    }

    public void ResourcesChange(int foodChange, int waterChange, int populationChange, int workersChange)
    {

        food += foodChange;
        water += waterChange;
        population += populationChange;
        workers += workersChange;


        food = Mathf.Max(food, 0);
        water = Mathf.Max(water, 0);
        population = Mathf.Max(population, 0);
        workers = Mathf.Max(workers, 0);
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
