using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using System.IO;
using TMPro;

public class ProjectileGun : Gun
{
    [SerializeField] GameObject bullet, shootingPoint, camera;
    [SerializeField] float speedx, speedy;
    [SerializeField] int maxAmmo = 3;
    [SerializeField] float reloadTime = 2, fireRate = 1;
    [SerializeField] string bulletName;
    int currentAmmo;
    float fireCountdown = 0, reloadCountdown;

    [SerializeField] TMP_Text ammoText; 
    [SerializeField] TMP_Text weaponText;

    PhotonView PV;

    public override void Use() {
        Shoot();
    }

    private void Awake() {
        currentAmmo = maxAmmo;
        reloadCountdown = reloadTime;
        PV = GetComponent<PhotonView>();
    }

    private void Update() {
        if(currentAmmo < maxAmmo && itemGameObject.activeSelf) {
            if(reloadCountdown <= 0f) {
                currentAmmo++;
                reloadCountdown = reloadTime;
            }
            reloadCountdown -= Time.deltaTime;
        }
        fireCountdown -= Time.deltaTime;

        if (itemGameObject.activeSelf) {
            ammoText.text = currentAmmo.ToString();
            weaponText.text = itemInfo.itemName;
        }
    }

    void Shoot() {
        if (fireCountdown <= 0f && currentAmmo > 0) {
            //GameObject b = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", bulletName), shootingPoint.transform.position, Quaternion.identity);
            Vector3 direction = camera.transform.forward;
            PV.RPC("RPC_SpawnProjectile", RpcTarget.Others, shootingPoint.transform.position, direction);

            GameObject b = Instantiate(bullet, shootingPoint.transform.position, Quaternion.identity);
            Rigidbody rb = b.GetComponentInChildren<Rigidbody>();
            rb.AddForce(direction * speedx);
            rb.AddForce(Vector2.up * speedy);

            fireCountdown = fireRate;
            reloadCountdown = reloadTime;
            currentAmmo--;
        }
    }

    [PunRPC]
    void RPC_SpawnProjectile(Vector3 shootingPoint, Vector3 cameraPoint) {
        GameObject b = Instantiate(bullet, shootingPoint, Quaternion.identity);
        Collider c = b.GetComponentInChildren<Collider>();
        Destroy(c);
        Rigidbody rb = b.GetComponentInChildren<Rigidbody>();
        rb.AddForce(cameraPoint * speedx);
        rb.AddForce(Vector2.up * speedy);
    }
}
