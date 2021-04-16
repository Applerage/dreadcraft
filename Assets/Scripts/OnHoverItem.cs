using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHoverItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string message;
    public Text infoText;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        infoText.text = message;
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        infoText.text = "";
    }
}
