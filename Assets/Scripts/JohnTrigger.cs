using UnityEngine;
using TMPro;

public class JohnTrigger : MonoBehaviour {
    public static JohnTrigger ActiveJohn;

    public GameObject dialogPanel;
    public TMP_Text dialogText;

    private int dialogIndex = 0;

    private string[] firstDialog =
    {
        "John: What do you want?",
        "John: Where is your CV?",
        "John: Go print it. Now."
    };

    private string[] afterPrinterDialog =
    {
        "John: You brought the CV?",
        "John: Are you asking if you are hired?",
        "John: I will think about it.",
        "John: I think faster with coffee.",
        "John: Make me coffee."
    };

    private void Start() {
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ActiveJohn = this;
            dialogPanel.SetActive(true);

            if (QuestManager.Instance != null && QuestManager.Instance.johnAskedForCoffee)
                dialogText.text = "John: Where is my coffee?";
            else if (QuestManager.Instance != null && QuestManager.Instance.printerDefeated)
                dialogText.text = "Give CV to John";
            else if (QuestManager.Instance != null && QuestManager.Instance.talkedToJohn)
                dialogText.text = "John: Go print your CV.";
            else
                dialogText.text = "Talk to John";
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (ActiveJohn == this)
                ActiveJohn = null;

            dialogPanel.SetActive(false);
            dialogIndex = 0;
        }
    }

    public void Talk() {
        Debug.Log("Talk clicked");

        if (dialogPanel == null) {
            Debug.LogError("Dialog Panel is missing on JohnTrigger!");
            return;
        }

        if (dialogText == null) {
            Debug.LogError("Dialog Text is missing on JohnTrigger!");
            return;
        }

        if (QuestManager.Instance == null) {
            Debug.LogError("QuestManager.Instance is missing!");
            return;
        }

        dialogPanel.SetActive(true);

        if (QuestManager.Instance != null && QuestManager.Instance.johnAskedForCoffee) {
            dialogText.text = "John: Where is my coffee?";
            return;
        }

        if (QuestManager.Instance != null && QuestManager.Instance.printerDefeated) {
            dialogText.text = afterPrinterDialog[dialogIndex];

            dialogIndex++;

            if (dialogIndex >= afterPrinterDialog.Length) {
                QuestManager.Instance.JohnAskedForCoffee();
                dialogIndex = 0;
            }

            return;
        }

        dialogText.text = firstDialog[dialogIndex];

        dialogIndex++;

        if (dialogIndex >= firstDialog.Length) {
            QuestManager.Instance.JohnDialogFinished();
            dialogText.text = "John: Go print your CV.";
            dialogIndex = 0;
        }
    }
}