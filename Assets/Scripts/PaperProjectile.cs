using UnityEngine;

public class PaperProjectile : MonoBehaviour {
    public float force = 12f;
    public float upwardForce = 3f;
    public int damage = 10;
    public float lifeTime = 5f;

    public Vector3 shootDirection = Vector3.left;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();

        if (rb != null) {
            rb.useGravity = true;
            rb.isKinematic = false;

            Vector3 finalForce = shootDirection.normalized * force + Vector3.up * upwardForce;
            rb.AddForce(finalForce, ForceMode.Impulse);
        }

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            FightHealth playerHealth = other.GetComponent<FightHealth>();

            if (playerHealth != null) {
                playerHealth.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}