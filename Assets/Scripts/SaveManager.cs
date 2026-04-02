using UnityEngine;
using System;

public class SaveManager : MonoBehaviour {
    public static SaveManager Instance;
    public int currentSlot = -1;

    void Awake() {
        Instance = this;
    }

    public int GetFreeSlot() {
        for (int i = 0; i < 6; i++) {
            if (!PlayerPrefs.HasKey("save_" + i))
                return i;
        }

        return 0;
    }

    // CREATE / OVERWRITE SAVE
    public void CreateGame(int slotIndex, Vector3 position, int kills) {
        SaveData data = new SaveData();

        data.playerX = position.x;
        data.playerY = position.y;
        data.playerZ = position.z;

        data.marshmallowsKilled = kills;

        data.dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("save_" + slotIndex, json);
        PlayerPrefs.Save();
    }

    public void CreateSave(int slotIndex) {
        SaveData data = new SaveData();

        data.playerX = 0;
        data.playerY = 0;
        data.playerZ = 0;

        data.marshmallowsKilled = 0;

        data.dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("save_" + slotIndex, json);
        PlayerPrefs.Save();
    }

    public SaveData LoadSave(int slotIndex) {
        if (!PlayerPrefs.HasKey("save_" + slotIndex))
            return null;

        string json = PlayerPrefs.GetString("save_" + slotIndex);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public void DeleteSave(int slotIndex) {
        PlayerPrefs.DeleteKey("save_" + slotIndex);
        PlayerPrefs.Save();
    }
}