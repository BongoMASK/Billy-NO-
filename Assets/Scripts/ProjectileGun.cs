using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ProjectileGun : Gun
{
    [SerializeField] GameObject bullet, shootingPoint, camera;
    [SerializeField] float speedx, speedy;
    public int maxAmmo = 3;
    public float reloadTime = 2, fireRate = 1;
    public float fireCountdown = 0, reloadCountdown;
    public int currentAmmo;

    public override void Use() {
        Shoot();
    }

    void Shoot() {
        if (fireCountdown <= 0f && currentAmmo > 0) {
            GameObject b = Instantiate(bullet, shootingPoint.transform.position, Quaternion.identity);
            Rigidbody rb = b.GetComponentInChildren<Rigidbody>();
            rb.AddForce(Vector2.up * speedy);
            rb.AddForce(camera.transform.forward * speedx);
            fireCountdown = fireRate;
            currentAmmo--;
        }
    }
}
