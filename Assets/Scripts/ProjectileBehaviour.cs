using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] ItemInfo itemInfo;
    [SerializeField] float destroyTime = 5f;
    [SerializeField] GameObject damageNumber;

    Transform mainCameraTransform;

    Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, destroyTime);
        mainCameraTransform = Camera.main.transform;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
            GameObject d = Instantiate(damageNumber, transform.position, Quaternion.identity);
            d.GetComponentInChildren<TMP_Text>().text = ((GunInfo)itemInfo).damage.ToString();
            d.transform.LookAt(transform.position + mainCameraTransform.rotation * Vector3.forward, mainCameraTransform.rotation * Vector3.up);
            Destroy(d, 1f);
            Destroy(gameObject);
        }
        else {
            rb.isKinematic = true;
        }
    }
}
