using UnityEngine;

public class FightPlayerMovement : MonoBehaviour {
    public FightJoystick joystick;

    public float moveSpeed = 5f;

    void Update() {
        float moveX = joystick.Horizontal;

        Vector3 movement = new Vector3(moveX, 0f, 0f);

        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}