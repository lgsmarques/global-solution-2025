using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<GameEvent> possibleEvents;
    public int currentDay = 1;
    public float timeBetweenEvents = 60f;
    public int daysToEnd = 15;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private EventUIManager eventUIManager;
    [SerializeField] private SceneController sceneController;

    void Start()
    {
        TriggerRandomEvent();
    }

    IEnumerator WaitAndTriggerEvent()
    {
        yield return new WaitForSeconds(timeBetweenEvents);
        currentDay++;

        if (currentDay >= daysToEnd)
        {
            sceneController.EndGame();
        }
        else
        {
            TriggerRandomEvent();
        }
    }

    public void TriggerRandomEvent()
    {
        int index = Random.Range(0, possibleEvents.Count);
        eventUIManager.ShowEvent(possibleEvents[index]);
    }

    public void ExecuteEvent(GameEvent gameEvent, int optionIndex)
    {
        EventOption option = gameEvent.options[optionIndex];
        resourceManager.ResourcesChange(option.foodChange, option.waterChange, option.populationChange, option.workerChange);
        
        StartCoroutine(WaitAndTriggerEvent());
    }
}
