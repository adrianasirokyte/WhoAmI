using UnityEngine;

public class QuestManager : MonoBehaviour {
    public static QuestManager Instance;

    public bool talkedToJohn = false;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void JohnDialogFinished() {
        talkedToJohn = true;
        Debug.Log("Quest updated: talked to John = true");
    }

    public bool CanUsePrinter() {
        return talkedToJohn;
    }
}