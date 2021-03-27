using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ProjectileGun : Gun
{
    [SerializeField] GameObject bullet, shootingPoint, camera;
    [SerializeField] float speedx, speedy;
    [SerializeField] const int maxAmmo = 3;
    [SerializeField] const float reloadTime = 2, fireRate = 1;
    [SerializeField] float fireCountdown = 0, reloadCountdown = reloadTime;
    [SerializeField] int currentAmmo = maxAmmo;

    public override void Use() {
        Shoot();
    }

    private void Update() {
        if(currentAmmo < maxAmmo) {
            if(reloadCountdown <= 0f) {
                currentAmmo++;
                reloadCountdown = reloadTime;
            }
            reloadCountdown -= Time.deltaTime;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot() {
        if (fireCountdown <= 0f && currentAmmo > 0) {
            GameObject b = Instantiate(bullet, shootingPoint.transform.position, Quaternion.identity);
            Rigidbody rb = b.GetComponentInChildren<Rigidbody>();
            rb.AddForce(Vector2.up * speedy);
            rb.AddForce(camera.transform.forward * speedx);
            fireCountdown = fireRate;
            reloadCountdown = reloadTime;
            currentAmmo--;
        }
    }
}
