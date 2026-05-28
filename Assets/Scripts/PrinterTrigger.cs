using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PrinterTrigger : MonoBehaviour {
    public static PrinterTrigger ActivePrinter;

    public GameObject dialogPanel;
    public TMP_Text dialogText;

    public string fightSceneName = "PrinterFight";

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            if (QuestManager.Instance != null && QuestManager.Instance.printerDefeated) {
                ActivePrinter = null;
                return;
            }

            ActivePrinter = this;

            if (dialogPanel != null)
                dialogPanel.SetActive(true);

            if (dialogText != null) {
                if (QuestManager.Instance != null && QuestManager.Instance.CanUsePrinter())
                    dialogText.text = "Use printer";
                else
                    dialogText.text = "Talk to John first.";
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (ActivePrinter == this)
                ActivePrinter = null;

            if (dialogPanel != null)
                dialogPanel.SetActive(false);
        }
    }

    public void UsePrinter() {
        if (QuestManager.Instance == null)
            return;

        if (QuestManager.Instance.printerDefeated) {
            ActivePrinter = null;
            return;
        }

        if (!QuestManager.Instance.CanUsePrinter()) {
            if (dialogPanel != null)
                dialogPanel.SetActive(true);

            if (dialogText != null)
                dialogText.text = "Talk to John first.";

            return;
        }

        if (dialogPanel != null)
            dialogPanel.SetActive(true);

        if (dialogText != null)
            dialogText.text = "Printer: I don't want to work. You can't force me.";

        StartCoroutine(StartFightAfterDelay());
    }

    IEnumerator StartFightAfterDelay() {
        yield return new WaitForSeconds(2f);

        ActivePrinter = null;
        SceneManager.LoadScene(fightSceneName);
    }
}