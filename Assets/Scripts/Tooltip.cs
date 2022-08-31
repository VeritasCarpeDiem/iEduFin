using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
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

        Vector3 position = Input.mousePosition;
        position.z = 10.0f;
        

        Vector2 corner = new Vector2(
            ((position.x > (Screen.width / 2f)) ? 1f : 0f),
            ((position.y > (Screen.height / 2f)) ? 1.5f : 0f));
        rectTrans.pivot = corner;

        transform.position = Camera.main.ScreenToWorldPoint(position);
        
    }
}
