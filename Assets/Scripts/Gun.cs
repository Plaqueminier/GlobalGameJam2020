using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 100f;

    public Camera fpsCam;
    public GameObject impactEffect;
    public float damageRate = 10f;

    public LineRenderer lineRenderer;
    bool release = true;

    private float nextTimeToFire = 0f;
    void Start()
    {
        lineRenderer.enabled = false;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            lineRenderer.SetPosition(1, hit.point + hit.normal);
        }
        if (Input.GetButton("Fire1") && !release)
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire1") && release)
        {
            Shoot();
            release = false;
            //  sounds //
            FindObjectOfType<AudioManager>().Play("test");

        }
        if (Input.GetButtonUp("Fire1"))
        {
            release = true;
            lineRenderer.enabled = false;
        }

    }

    void Shoot()
    {
        RaycastHit hit;
        Target target;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            target = hit.transform.GetComponent<Target>();
            if (target != null && Time.time >= nextTimeToFire)
            {
                target.TakeDamage(damage);
                nextTimeToFire = nextTimeToFire = Time.time + 2f / damageRate;
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

            // lineRenderer.SetPosition(0, transform.position);


            lineRenderer.enabled = true;


        }


    }
}
