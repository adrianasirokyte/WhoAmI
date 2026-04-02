using UnityEngine;

public class SaveButton : MonoBehaviour {
    public int slot;
    public Transform player;

    public void SaveGame() {
        Transform player = GameObject.FindWithTag("Player").transform;

        SaveManager.Instance.CreateGame(
            SaveManager.Instance.currentSlot,
            player.position,
            GameManager.Instance.marshmallowsKilled
        );

        Debug.Log("Game Saved!");
    }
}