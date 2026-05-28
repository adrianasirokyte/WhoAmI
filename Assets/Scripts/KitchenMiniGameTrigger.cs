using UnityEngine;

public class KitchenMiniGameTrigger : MonoBehaviour {
    public static KitchenMiniGameTrigger ActiveKitchen;

    public GameObject coffeePanel;

    private void Start() {
        if (coffeePanel != null)
            coffeePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            ActiveKitchen = this;
            Debug.Log("Near kitchen");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            if (ActiveKitchen == this)
                ActiveKitchen = null;

            if (coffeePanel != null)
                coffeePanel.SetActive(false);
        }
    }

    public void OpenCoffeePanel() {
        if (coffeePanel != null)
            coffeePanel.SetActive(true);
    }
}