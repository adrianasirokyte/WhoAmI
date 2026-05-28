using UnityEngine;

public class OfficeTrigger : MonoBehaviour {
    public static bool CanEnterOffice = false;
    public static string SceneToEnterOffice = "";

    public string sceneToLoad = "OfficeScene";

    private void Awake() {
        CanEnterOffice = false;
        SceneToEnterOffice = "";
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CanEnterOffice = true;
            SceneToEnterOffice = sceneToLoad;

            Debug.Log("Player near office.");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            CanEnterOffice = false;
            SceneToEnterOffice = "";

            Debug.Log("Player left office.");
        }
    }

    private void OnDisable() {
        CanEnterOffice = false;
        SceneToEnterOffice = "";
    }
}