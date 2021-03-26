using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class ProjectileGun : Gun
{
    [SerializeField] GameObject bullet, shootingPoint, camera;
    [SerializeField] float speedx;
    [SerializeField] float speedy;
    [SerializeField] int ammo;
    [SerializeField] const int maxAmmo = 3;

    public override void Use() {
        Shoot();
    }

    void Shoot() {
        GameObject b = Instantiate(bullet, shootingPoint.transform.position, Quaternion.identity);
        Rigidbody rb = b.GetComponentInChildren<Rigidbody>();
        rb.AddForce(Vector2.up * speedy);
        rb.AddForce(camera.transform.forward * speedx); 

    }
}
