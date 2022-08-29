using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger2 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    
    [Multiline()]
    public string content;

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem2.Show(content, header);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem2.Hide();
    }
}
