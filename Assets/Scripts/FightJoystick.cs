using UnityEngine;
using UnityEngine.EventSystems;

public class FightJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
    public RectTransform knob;

    private Vector2 inputVector;

    public float Horizontal {
        get { return inputVector.x; }
    }

    public void OnPointerDown(PointerEventData eventData) {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData) {
        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out position);

        position.x = (position.x / ((RectTransform)transform).sizeDelta.x);
        position.y = (position.y / ((RectTransform)transform).sizeDelta.y);

        inputVector = new Vector2(position.x * 2, position.y * 2);

        inputVector = (inputVector.magnitude > 1.0f)
            ? inputVector.normalized
            : inputVector;

        knob.anchoredPosition = new Vector2(
            inputVector.x * (((RectTransform)transform).sizeDelta.x / 3),
            inputVector.y * (((RectTransform)transform).sizeDelta.y / 3));
    }

    public void OnPointerUp(PointerEventData eventData) {
        inputVector = Vector2.zero;
        knob.anchoredPosition = Vector2.zero;
    }
}