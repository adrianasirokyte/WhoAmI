using UnityEngine;
using System.Collections.Generic;

public class RewardManager : MonoBehaviour {
    public static RewardManager Instance;

    public List<Reward> rewards = new List<Reward>();

    void Awake() {
        Instance = this;
    }

    public void UnlockReward(string id) {
        foreach (Reward r in rewards) {
            if (r.id == id && !r.unlocked) {
                r.unlocked = true;

                Debug.Log("REWARD UNLOCKED: " + r.title);

                UIRewardPopup.Instance.Show(r.title);

                return;
            }
        }
    }

    public bool IsUnlocked(string id) {
        foreach (Reward r in rewards) {
            if (r.id == id)
                return r.unlocked;
        }

        return false;
    }
}