using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5f;
    public SimpleJoystick joystick;
    private SpriteRenderer spriteRenderer;

    void Start() {
        // find sprite renderer on player
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update() {
        // INPUT FROM JOYSTICK
        float moveX = joystick.Horizontal; // AD
        float moveZ = joystick.Vertical;   // WS

        // Movement vector - in XZ plane
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        // Flip character left or right only (when 90 or 270 degrees -> player is flat)
        if (moveX > 0.1f) {
            spriteRenderer.flipX = false;
        } else if (moveX < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }
}