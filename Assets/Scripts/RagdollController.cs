using UnityEngine;

public class RagdollController : MonoBehaviour
{

    [SerializeField] Transform hips;

    [SerializeField] float hipsHeight = 10f;

    [SerializeField] LayerMask whatIsGround;

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

    void Move(float x, float y) {
        if(Physics.Raycast(hips.transform.position, Vector3.down, out RaycastHit hit, hipsHeight + 1, whatIsGround))
            hips.position = hit.point + new Vector3(0, hipsHeight, 0);

        hips.transform.position += new Vector3(0, 0, 1) * Time.fixedDeltaTime;
    }
}
