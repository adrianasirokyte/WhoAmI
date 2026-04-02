using UnityEngine;
using UnityEngine.EventSystems;

public class AttackJoystick : MonoBehaviour {
    public PlayerMovement player;

    // this runs when button is clicked
    public void OnAttackClick() {
        Debug.Log("ATTACK CLICKED");
        player.DoAttack();
    }
}