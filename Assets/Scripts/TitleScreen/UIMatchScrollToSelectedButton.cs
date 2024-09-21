using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIMatchScrollToSelectedButton : MonoBehaviour
{
    [SerializeField] GameObject currentSelected;
    [SerializeField] GameObject previouslySelected;
    [SerializeField] RectTransform currentSelectedTransform;


    [SerializeField] RectTransform contentPanel;
    [SerializeField] ScrollRect scrollRect;

    private void Update() {
        currentSelected = EventSystem.current.currentSelectedGameObject;

        if (currentSelected != null) {
            if (currentSelected != previouslySelected) {
                previouslySelected = currentSelected;
                currentSelectedTransform = currentSelected.GetComponent<RectTransform>();
                SnapTo(currentSelectedTransform);
            }
        }
    }

    private void SnapTo(RectTransform target) {
        Canvas.ForceUpdateCanvases();
        Vector2 newPos = 
            (Vector2)scrollRect.transform.InverseTransformDirection(contentPanel.position) - (Vector2)scrollRect.transform.InverseTransformDirection(target.position); 

        newPos.x = 0;

        contentPanel.anchoredPosition = newPos;
    }

}
