using UnityEngine;

public class Marshmallow : MonoBehaviour, IKickable {
    public bool isKicked = false;

    public void Kick() {
        if (isKicked) return; // kad neskaiciuotu 2 kartus

        isKicked = true;

        Debug.Log("Marshmallow kicked!");

        transform.localScale *= 1.5f;

        // pranesam sistemai
        GameManager.Instance.RegisterKick();
    }
}