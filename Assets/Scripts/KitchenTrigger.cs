using UnityEngine;

public class KitchenTrigger : MonoBehaviour {
    public static bool CanEnterKitchen = false;
    public static string SceneToEnterKitchen = "";

    public string sceneToLoad = "KitchenScene";

    private void Awake() {
        CanEnterKitchen = false;
        SceneToEnterKitchen = "";
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            CanEnterKitchen = true;
            SceneToEnterKitchen = sceneToLoad;

            Debug.Log("Player near kitchen.");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            CanEnterKitchen = false;
            SceneToEnterKitchen = "";

            Debug.Log("Player left kitchen.");
        }
    }

    private void OnDisable() {
        CanEnterKitchen = false;
        SceneToEnterKitchen = "";
    }
}