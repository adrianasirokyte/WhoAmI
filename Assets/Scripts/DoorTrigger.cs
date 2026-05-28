using UnityEngine;

public class DoorTrigger : MonoBehaviour {
    public static bool CanEnterDoor = false;
    public static string SceneToEnter = "";

    public string sceneToLoad = "BuildingInterior";

    private void Awake() {
        CanEnterDoor = false;
        SceneToEnter = "";
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CanEnterDoor = true;
            SceneToEnter = sceneToLoad;
            Debug.Log("Player near door. Scene: " + sceneToLoad);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            CanEnterDoor = false;
            SceneToEnter = "";
            Debug.Log("Player left door.");
        }
    }

    private void OnDisable() {
        CanEnterDoor = false;
        SceneToEnter = "";
    }
}