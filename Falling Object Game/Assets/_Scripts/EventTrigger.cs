using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject imageToShow;
    [SerializeField] private TMP_Text textToChangeColor;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (imageToShow != null)
        {
            imageToShow.SetActive(true);
            textToChangeColor.color = new Color32(62, 159, 62, 255); // #3E9F3E

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (imageToShow != null)
        {
            imageToShow.SetActive(false);
            textToChangeColor.color = Color.white; // Reset to default color
        }
    }
}
