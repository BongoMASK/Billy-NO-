using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;

    private void LateUpdate() {
        transform.LookAt(player.position);
        transform.position = player.position + offset;
    }
}
