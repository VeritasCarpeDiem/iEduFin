using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class popup_controller : MonoBehaviour
{

    [SerializeField] Button exit_btn;
    [SerializeField] TMPro.TextMeshProUGUI popup_text;
    

    public void Init(Transform canvas, string popupMsg)
    {
        popup_text.text = popupMsg;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero;
        GetComponent<RectTransform>().offsetMax = Vector2.zero;

        exit_btn.onClick.AddListener(() =>
        {
            GameObject.Destroy(this.gameObject);
        });
    }
}
