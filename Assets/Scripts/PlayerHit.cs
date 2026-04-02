using UnityEngine;

public class PlayerHit : MonoBehaviour {
    public PlayerMovement player;
    public float hitRadius = 1.5f;

    void Update() {
        if (!player.canKick)
            return;

        // test click
        if (Input.GetMouseButtonDown(0)) {
            TryHit();
        }
    }

    void TryHit() {
        Collider[] hits = Physics.OverlapSphere(transform.position, hitRadius);

        foreach (Collider col in hits) {
            if (col.CompareTag("Marshmallow")) {
                Debug.Log("HIT MARSHMALLOW: " + col.name);

                GameManager.Instance.RegisterKick();

                col.transform.localScale *= 1.5f;
                return; // svarbu: tik 1 hit per attack
            }
        }
    }
}