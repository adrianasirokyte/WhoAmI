using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FightAttackButton : MonoBehaviour {
    public FightHealth playerHealth;
    public FightHealth printerHealth;

    public int playerDamage = 15;
    public int printerDamage = 10;

    public GameObject winPanel;
    public TMP_Text winText;

    public string returnSceneName = "BuildingInterior";

    private bool busy = false;
    private bool fightEnded = false;

    public void OnAttackClick() {
        if (busy || fightEnded) return;

        StartCoroutine(FightSequence());
    }

    IEnumerator FightSequence() {
        busy = true;

        if (printerHealth != null)
            printerHealth.TakeDamage(playerDamage);

        if (printerHealth != null && printerHealth.currentHealth <= 0) {
            fightEnded = true;

            if (winPanel != null)
                winPanel.SetActive(true);

            if (winText != null)
                winText.text = "Hooray! You won!";

            yield return new WaitForSeconds(2f);

            SceneManager.LoadScene(returnSceneName);
            yield break;
        }

        yield return new WaitForSeconds(0.7f);

        if (playerHealth != null)
            playerHealth.TakeDamage(printerDamage);

        busy = false;
    }
}