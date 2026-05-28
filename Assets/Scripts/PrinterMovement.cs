using UnityEngine;

public class PrinterMovement : MonoBehaviour {
    public float speed = 2f;

    public float minX = -3f;
    public float maxX = 5f;

    private int direction = 1;

    void Update() {
        Vector3 pos = transform.position;

        pos.x += direction * speed * Time.deltaTime;

        if (pos.x >= maxX) {
            pos.x = maxX;
            direction = -1;
        }

        if (pos.x <= minX) {
            pos.x = minX;
            direction = 1;
        }

        transform.position = pos;
    }
}