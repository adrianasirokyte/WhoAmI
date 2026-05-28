using UnityEngine;
using TMPro;

public class JohnTrigger : MonoBehaviour {
    public static JohnTrigger ActiveJohn;

    public GameObject dialogPanel;
    public TMP_Text dialogText;

    private int dialogIndex = 0;

    private string[] dialogLines =
    {
        "John: What do you want?",
        "John: Where is your CV?",
        "John: Go print it. Now."
    };

    private void Start() {
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ActiveJohn = this;
            dialogPanel.SetActive(true);
            dialogText.text = "Talk to John";
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (ActiveJohn == this) {
                ActiveJohn = null;
            }

            dialogPanel.SetActive(false);
            dialogIndex = 0;
        }
    }

    public void Talk() {
        dialogPanel.SetActive(true);

        dialogText.text = dialogLines[dialogIndex];

        dialogIndex++;

        if (dialogIndex >= dialogLines.Length) {
            QuestManager.Instance.JohnDialogFinished();
            dialogText.text = "John: Go print your CV.";
            dialogIndex = 0;
        }
    }
}