using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellBookTTP : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string message;
    public Text toolTip;
    public void OnPointerEnter(PointerEventData eventData)
    {
        toolTip.text = message;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        toolTip.text = "Spell Book";
    }
}
