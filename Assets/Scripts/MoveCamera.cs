using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player;
    [SerializeField] private Vector3 setPos = new Vector3(0, 2, 0);

    void Update() {
        transform.position = player.transform.position + setPos;
    }
}
