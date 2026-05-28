using UnityEngine;

public class QuestManager : MonoBehaviour {
    public static QuestManager Instance;

    public bool talkedToJohn = false;
    public bool printerDefeated = false;
    public bool johnAskedForCoffee = false;

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
        return talkedToJohn && !printerDefeated;
    }

    public void PrinterDefeated() {
        printerDefeated = true;
        Debug.Log("Quest updated: printer defeated = true");
    }

    public void JohnAskedForCoffee() {
        johnAskedForCoffee = true;
        Debug.Log("Quest updated: John wants coffee");
    }
}