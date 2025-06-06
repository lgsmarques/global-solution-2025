using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class EventUIManager : MonoBehaviour
{
    public GameObject eventPanel;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public List<Button> buttons = new();
    public EventManager eventManager;
    public GameEvent currentEvent;

    public void ShowEvent(GameEvent gameEvent)
    {
        currentEvent = gameEvent;
        eventPanel.SetActive(true);
        titleText.SetText(currentEvent.title);
        descriptionText.SetText(currentEvent.description);

        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[i].gameObject.SetActive(true);
            buttons[i].GetComponentInChildren<TMP_Text>().SetText(currentEvent.options[i].description);
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => SelectOption(index));
        }
    }

    public void SelectOption(int optionIndex)
    {
        Debug.Log(optionIndex);
        eventManager.ExecuteEvent(currentEvent, optionIndex);
        eventPanel.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
