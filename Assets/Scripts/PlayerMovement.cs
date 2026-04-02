using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5f;
    public SimpleJoystick joystick;
    public AttackJoystick attackJoystick;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool canKick = false;

    void Start() {
        // get components from player or child
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update() {

        if (joystick == null || attackJoystick == null || animator == null)
            return;

        // INPUT FROM JOYSTICK
        float moveX = joystick.Horizontal; // AD
        float moveZ = joystick.Vertical;   // WS

        // Movement vector - in XZ plane
        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ);
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        float moveSpeed = moveDirection.magnitude;
        animator.SetFloat("MoveSpeed", moveSpeed);

        // Flip character left or right only (when 90 or 270 degrees -> player is flat)
        if (moveX > 0.1f) {
            spriteRenderer.flipX = false;
        } else if (moveX < -0.1f) {
            spriteRenderer.flipX = true;
        }
    }

 

    public void DoAttack() {
        Debug.Log("ATTACK CLICKED");

        animator.SetTrigger("Attack");

        StartCoroutine(AttackWindow());
    }

    // 
    System.Collections.IEnumerator AttackWindow() {
        canKick = true;

        // moment “uderzenia” (dopasuj do animacji)
        yield return new WaitForSeconds(0.15f);

        TryHit();

        yield return new WaitForSeconds(0.15f);

        canKick = false;
    }

    // 
    void TryHit() {
        Collider[] hits = Physics.OverlapSphere(transform.position, 1.5f);

        foreach (Collider col in hits) {
            IKickable kickable = col.GetComponent<IKickable>();

            if (kickable != null) {
                Debug.Log("HIT: " + col.name);
                kickable.Kick();
                return;
            }
        }

        Debug.Log("NO TARGET HIT");
    }
}