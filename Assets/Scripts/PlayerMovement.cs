using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    [SerializeField] float playerSpeed = 5f;

    [SerializeField] Animator playerAnims;

    float x, y;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() {
        Move(x, y);
    }

    void Move() {
        rb.velocity = transform.forward * playerSpeed;
    }

    /// <summary>
    /// WASD movement
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    void Move(float x, float y) {
        playerAnims.SetFloat("vertical", y);
        playerAnims.SetFloat("horizontal", x);  
    }

    void ChangeMultipliers(float y, ref float speedMultiplier, float mul) {
        speedMultiplier += Time.fixedDeltaTime * y * mul;
        if (y == 0)
            Mathf.Lerp(speedMultiplier, 0, 1);

        speedMultiplier = Mathf.Clamp(speedMultiplier, -1, 1);
    }

    void Rotate(float angle) {

    }
}
