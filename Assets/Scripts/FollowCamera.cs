using UnityEngine;

public class FollowCamera : MonoBehaviour {
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smooth = 6f;

    void LateUpdate() {
        Vector3 target = new Vector3(player.position.x, player.position.y, offset.z);

        transform.position = Vector3.Lerp(transform.position, target, smooth * Time.deltaTime);
    }
}