using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

[System.Serializable]
public enum JoystickDir
{
    Horizontal,
    Vertical,
    Both
}
public class FloatingJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform Background;

    public RectTransform Handle;

    [Range(0, 2f)] public float HandleLimit = 1f;

    private Vector2 input = Vector2.zero;

    public JoystickDir _JoystickDir = JoystickDir.Both;

    private Vector2 JoystickPosition = Vector2.zero;
    public float Vertical
    {
        get { return input.y; }
    }

    public float Horizontal
    {
        get { return input.x; }
    }

    public void OnDrag(PointerEventData eventData)
    {
        print("Drag");
        Vector2 JoystickDirection = eventData.position -
                                    JoystickPosition;
        input = (JoystickDirection.magnitude > Background.sizeDelta.x / 2f)
            ? JoystickDirection.normalized
            : JoystickDirection / (Background.sizeDelta.x / 2f);
        if (_JoystickDir == JoystickDir.Horizontal)
            input = new Vector2(input.x, 0f);
        if (_JoystickDir == JoystickDir.Vertical)
            input = new Vector2(0f, input.y);
        Handle.anchoredPosition = (input * Background.sizeDelta.x / 2f) * HandleLimit;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
        Background.gameObject.SetActive(true);
        OnDrag(eventData);
        JoystickPosition = eventData.position;
        Background.position = eventData.position;
        Handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Up");
        Background.gameObject.SetActive(false);
        input = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }
}
