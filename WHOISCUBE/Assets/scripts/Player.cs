using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Animator animator;
    private Renderer playerRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerRenderer = GetComponent<Renderer>();

        TryApplySkin();

        if (SkinManager.Instance == null)
        {
            InvokeRepeating(nameof(TryApplySkin), 0.1f, 0.1f);
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(-horizontalInput, 0, -verticalInput).normalized;

        if (rb != null)
        {
            rb.velocity = direction * moveSpeed;
        }

        UpdateAnimations(horizontalInput, verticalInput);
    }

    void UpdateAnimations(float horizontalInput, float verticalInput)
    {
        bool isMoving = (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f);

        if (!isMoving)
        {
            animator.Play("Idle");
        }
        else
        {
            if (Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput))
            {
                animator.Play("RunFor");
            }
            else
            {
                animator.Play("RunLeft");
            }
        }
    }

    public void TryApplySkin()
    {
        if (SkinManager.Instance != null && playerRenderer != null)
        {
            playerRenderer.material = SkinManager.Instance.GetSelectedSkin();
            CancelInvoke(nameof(TryApplySkin));
            Debug.Log("Skin applied: " + SkinManager.Instance.GetSelectedSkin().name);
        }
    }
}