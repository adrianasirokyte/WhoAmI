using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveSlotUI : MonoBehaviour {
    public int index;
    public TextMeshProUGUI dateText;

    void Start() {
        Refresh();
    }

    public void Refresh() {
        SaveData data = SaveManager.Instance.LoadSave(index);

        if (data != null)
            dateText.text = data.dateTime;
        else
            dateText.text = "EMPTY";
    }

    public void Load() {
        SaveManager.Instance.currentSlot = index;
        SceneManager.LoadScene("MainScene");
    }

    public void Delete() {
        SaveManager.Instance.DeleteSave(index);
        Refresh();
    }
}