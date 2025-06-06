using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public List<GameEvent> possibleEvents;
    public float timeBetweenEvents = 60f;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private EventUIManager eventUIManager;
    [SerializeField] private DayManager dayManager;

    void Start()
    {
        TriggerRandomEvent();
    }

    IEnumerator WaitAndTriggerEvent()
    {
        yield return new WaitForSeconds(timeBetweenEvents);
        dayManager.ChangeDay();        
        TriggerRandomEvent();
    }

    public void TriggerRandomEvent()
    {
        int index = Random.Range(0, possibleEvents.Count);
        eventUIManager.ShowEvent(possibleEvents[index]);
    }

    public void ExecuteEvent(GameEvent gameEvent, int optionIndex)
    {
        ResourceChange currentDayResourceChange = gameEvent.options[optionIndex].currentDayResourceChange;
        ResourceChange nextDayResourceChange = gameEvent.options[optionIndex].nextDayResourceChange;
        resourceManager.ChangeResources(currentDayResourceChange);
        resourceManager.AddToNextDayChange(nextDayResourceChange);

        StartCoroutine(WaitAndTriggerEvent());
    }
}
