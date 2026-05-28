using UnityEngine;

public class OutdoorTrigger : MonoBehaviour {
    public static bool CanExitBuilding = false;
    public static string SceneToExit = "";

    public string sceneToLoad = "MainScene";

    private void Awake() {
        CanExitBuilding = false;
        SceneToExit = "";
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CanExitBuilding = true;
            SceneToExit = sceneToLoad;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            CanExitBuilding = false;
            SceneToExit = "";
        }
    }

    private void OnDisable() {
        CanExitBuilding = false;
        SceneToExit = "";
    }
}