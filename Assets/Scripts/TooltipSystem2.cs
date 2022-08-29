using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem2 : MonoBehaviour
{
    private static TooltipSystem2 current;

    public Tooltip2 tooltip;
    public void Awake()
    {
        current = this;
    }
    
    public static void Show(string content, string header = "")
    {
        current.tooltip.SetText(content, header);
        current.tooltip.gameObject.SetActive(true);
    }
    
    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);
    }
}
