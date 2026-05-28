using UnityEngine;

public class PrinterPaperShooter : MonoBehaviour {
    public GameObject paperPrefab;
    public Transform shootPoint;

    public float shootInterval = 1.5f;

    public Vector3 shootDirection = Vector3.left;

    private float timer;

    private void Update() {
        timer += Time.deltaTime;

        if (timer >= shootInterval) {
            ShootPaper();
            timer = 0f;
        }
    }

    private void ShootPaper() {
        if (paperPrefab == null || shootPoint == null) {
            Debug.LogWarning("Paper prefab or shoot point is missing.");
            return;
        }

        GameObject paper = Instantiate(
            paperPrefab,
            shootPoint.position,
            Quaternion.identity
        );

        PaperProjectile projectile = paper.GetComponent<PaperProjectile>();

        if (projectile != null) {
            projectile.shootDirection = shootDirection;
        }
    }
}