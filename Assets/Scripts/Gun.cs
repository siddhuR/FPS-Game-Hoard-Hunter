using UnityEngine.InputSystem;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;
    public int fireRate = 10;
    private float nextTimeToFire = 0;
    public ParticleSystem muzzleFlush;
    public GameObject impactEffect;
    public TextMeshProUGUI ammInfoText;
    public int damageAmount = 20;

    public int currentAmmo;
    public int maxAmmo = 40;
    public int magazineSize = 300;

    public float reloadTime = 2f;
    private bool isReloading;
    InputAction shoot;
    // Start is called before the first frame update
    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");
        shoot.AddBinding("<Gamepad>/x");

        shoot.Enable();
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        Gun currentGun = FindObjectOfType<Gun>();
        ammInfoText.text = currentGun.currentAmmo + " / " + currentGun.magazineSize;
        bool isShooting = shoot.ReadValue<float>() == 1;

        if(isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f /fireRate;
            Fire();
        }
        if(currentAmmo == 0 && !isReloading)
        {

        }
    }
    private void Fire()
    {
        RaycastHit hit;
        muzzleFlush.Play();
        currentAmmo--;
        if(Physics.Raycast(fpsCam.position,fpsCam.forward,out hit,range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            Dragon e = hit.transform.GetComponent<Dragon>();
            if(e != null)
            {
                e.TakeDamage(damageAmount);
                return;
            }
            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);

            GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
            impact.transform.parent = hit.transform;
            Destroy(impact, 5);
            

        }
        
    }

   
}
