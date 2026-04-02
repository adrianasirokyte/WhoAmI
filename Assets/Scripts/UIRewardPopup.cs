using UnityEngine;
using TMPro;
using System.Collections;

public class UIRewardPopup : MonoBehaviour {
    public static UIRewardPopup Instance;

    public GameObject panel;
    public TextMeshProUGUI text;

    void Awake() {
        Instance = this;
    }

    void Start() {
        panel.SetActive(false);
    }

    public void Show(string rewardName) {
        StartCoroutine(ShowRoutine(rewardName));
    }

    IEnumerator ShowRoutine(string rewardName) {
        panel.SetActive(true);
        text.text = "Congratulations " + rewardName;

        yield return new WaitForSeconds(3f);

        panel.SetActive(false);
    }
}