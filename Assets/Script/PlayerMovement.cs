using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    private Rigidbody rb;
    private float horizontal;
    private float vertical;

    // Menandai jika input datang dari tombol UI mobile
    private bool isMobileInput = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Jika tidak ada input UI mobile, gunakan keyboard (W,A,S,D / Panah)
        if (!isMobileInput)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 nextPosition = rb.position + direction * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(nextPosition);
    }

    // =======================================================
    // FUNGSI BARU YANG DIBUAT UNTUK MENERIMA 2 ARGUMEN INPUT
    // =======================================================
    public void SetMobileInput(float xInput, float yInput)
    {
        isMobileInput = true;
        horizontal = xInput;
        vertical = yInput;
    }
}
