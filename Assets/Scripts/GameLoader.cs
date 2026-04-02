using UnityEngine;

public class GameLoader : MonoBehaviour {
    public Transform player;
    public PlayerLoad playerLoad;

    void Start() {
        if (!PlayerPrefs.HasKey("currentSave"))
            return;

        int slot = int.Parse(PlayerPrefs.GetString("currentSave"));
        SaveData data = SaveManager.Instance.LoadSave(slot);

        if (data == null) 
            return;

        playerLoad.LoadPlayer(data);
        GameManager.Instance.marshmallowsKilled = data.marshmallowsKilled;
    }
}