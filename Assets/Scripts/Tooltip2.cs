using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip2 : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    
    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;

    public int characterWrapLimit;

    public bool contentEmpty;

    public RectTransform rectTrans;

    public void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
    }
    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerField.gameObject.SetActive(false);
        }
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        if (string.IsNullOrEmpty(content))
        {
            contentField.gameObject.SetActive(false);
            contentEmpty = true;
        }
        else
        {
            contentField.gameObject.SetActive(true);
            contentField.text = content;
            contentEmpty = false;
        }

    }
    private void Update()
    {
        if (Application.isEditor)
        {
            int headerLength = headerField.text.Length;
            int contentLength = contentField.text.Length;

            layoutElement.enabled =
                (headerLength > characterWrapLimit || contentLength > characterWrapLimit) ? true : false;
        }

        Vector2 position = Input.mousePosition;
        
        rectTrans.pivot = new Vector2(0f, 0f);
        transform.position = position;
        
    }
}
