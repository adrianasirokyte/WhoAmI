using UnityEngine;
using UnityEngine.EventSystems;

public class SimpleJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler {
    public RectTransform handle;
    private Vector2 input = Vector2.zero;
    public float Horizontal => input.x;
    public float Vertical => input.y;

    public void OnPointerDown(PointerEventData eventData) {
        // When player touches joystick, player starts moving immediately
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData) {
        RectTransform bg = transform as RectTransform;

        Vector2 pos;

        // Convert screen touch position into local joystick position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            bg,
            eventData.position,
            eventData.pressEventCamera,
            out pos
        );

        // Normalize position based on joystick size
        pos.x /= bg.sizeDelta.x;
        pos.y /= bg.sizeDelta.y;

        // Convert to -1 to 1 input range
        input = new Vector2(pos.x * 2, pos.y * 2);

        // Limit movement to circle shape
        if (input.magnitude > 1)
            input = input.normalized;

        // Move joystick handle visually
        handle.anchoredPosition = new Vector2(
            input.x * (bg.sizeDelta.x / 2),
            input.y * (bg.sizeDelta.y / 2)
        );
    }

    public void OnPointerUp(PointerEventData eventData) {
        // Reset input when finger is lifted
        input = Vector2.zero;

        // Reset handle to center
        handle.anchoredPosition = Vector2.zero;
    }
}