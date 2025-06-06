using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour
{

    public int currentDay = 1;
    public int daysToEnd = 15;
    public TMP_Text dayText;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private SceneController sceneController;

    public void ChangeDay()
    {
        resourceManager.ProduceResources();
        resourceManager.ConsumeResources();
        resourceManager.ExecuteNextDayChange();
        currentDay++;

        if (currentDay >= daysToEnd)
        {
            sceneController.EndGame();
        }
    }

    void Update()
    {
        dayText.SetText("Dia " + currentDay);
    }
}
