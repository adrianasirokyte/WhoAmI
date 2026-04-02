using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    public int marshmallowsKilled = 0;
    public int needed = 4;

    public GameObject rewardPanel;      // PANEL
    public TextMeshProUGUI rewardText; // UI TEXT

    void Awake() {
        Instance = this;
    }

    void Start() {
        rewardPanel.SetActive(false); // pradzioje paslepta
    }

    public void RegisterKick() {
        if (marshmallowsKilled >= needed)
            return;

        marshmallowsKilled++;

        Debug.Log("Kicked: " + marshmallowsKilled + "/" + needed);

        if (marshmallowsKilled >= needed) {
            RewardManager.Instance.UnlockReward("marshmallow_4");
        }
    }
}