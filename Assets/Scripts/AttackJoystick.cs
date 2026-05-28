using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackJoystick : MonoBehaviour {
    public PlayerMovement player;

    public void OnAttackClick() {
        // MAIN
        if (OutdoorTrigger.CanExitBuilding && !string.IsNullOrEmpty(OutdoorTrigger.SceneToExit)) {
            string sceneName = OutdoorTrigger.SceneToExit;

            OutdoorTrigger.CanExitBuilding = false;
            OutdoorTrigger.SceneToExit = "";
            DoorTrigger.CanEnterDoor = false;
            DoorTrigger.SceneToEnter = "";

            SceneManager.LoadScene(sceneName);
            return;
        }

        // BUILDING
        if (DoorTrigger.CanEnterDoor && !string.IsNullOrEmpty(DoorTrigger.SceneToEnter)) {
            string sceneName = DoorTrigger.SceneToEnter;

            DoorTrigger.CanEnterDoor = false;
            DoorTrigger.SceneToEnter = "";
            OutdoorTrigger.CanExitBuilding = false;
            OutdoorTrigger.SceneToExit = "";

            SceneManager.LoadScene(sceneName);
            return;
        }

        // OFFICE
        if (OfficeTrigger.CanEnterOffice && !string.IsNullOrEmpty(OfficeTrigger.SceneToEnterOffice)) {
            string sceneName = OfficeTrigger.SceneToEnterOffice;
            OfficeTrigger.CanEnterOffice = false;
            OfficeTrigger.SceneToEnterOffice = "";
            DoorTrigger.CanEnterDoor = false;
            DoorTrigger.SceneToEnter = "";
            OutdoorTrigger.CanExitBuilding = false;
            OutdoorTrigger.SceneToExit = "";

            SceneManager.LoadScene(sceneName);
            return;
        }

        // JOHN
        if (JohnTrigger.ActiveJohn != null) {
            JohnTrigger.ActiveJohn.Talk();
            return;
        }

        // PRINTER
        if (PrinterTrigger.ActivePrinter != null) {
            PrinterTrigger.ActivePrinter.UsePrinter();
            return;
        }

        if (player != null) {
            Debug.Log("ATTACK CLICKED");
            player.DoAttack();
        } else {
            Debug.LogWarning("PlayerMovement is not assigned in AttackJoystick!");
        }
    }
}