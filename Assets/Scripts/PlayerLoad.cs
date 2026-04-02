using UnityEngine;

public class PlayerLoad : MonoBehaviour {
    public void LoadPlayer(SaveData data) {
        transform.position = new Vector3(
            data.playerX,
            data.playerY,
            data.playerZ
        );
    }
}