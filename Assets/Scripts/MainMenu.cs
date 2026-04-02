using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public Button loadButton;

    void Start() {
        UpdateLoadButton();
    }

    void UpdateLoadButton() {
        bool hasSave = PlayerPrefs.HasKey("save_0");

        loadButton.interactable = hasSave;
    }

    public void StartGame() {
        int slot = SaveManager.Instance.GetFreeSlot();
        SaveManager.Instance.currentSlot = slot;

        SaveManager.Instance.CreateGame(slot, Vector3.zero, 0);
        SceneManager.LoadScene("MainScene");
    }

    public void LoadGame() {
        SceneManager.LoadScene("LoadGame");
        Debug.Log("Load Game clicked");
    }

    public void OpenRewards() {
        Debug.Log("Rewards clicked");
    }

    public void OpenSettings() {
        Debug.Log("Settings clicked");
    }
}