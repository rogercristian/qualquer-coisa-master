using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class GUn : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    [SerializeField] private float range = 100;
    [SerializeField] private Camera fpsCamera;
    //[SerializeField] private GameObject hitVfx;
    //[SerializeField] private ParticleSystem shootVfx;
    [SerializeField] private float impactForce = 50f;
    [SerializeField] private int maxBullet = 10;
    private int currentBullet;
    [SerializeField] private float reloadTime = 1f;
    private bool isReloanding = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //shootVfx.Stop();
        currentBullet = maxBullet;
        fpsCamera = Camera.main;
    }

    private void OnEnable()
    {


        //shootVfx.Stop();

        isReloanding = false;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.eulerAngles = new Vector3(fpsCamera.transform.eulerAngles.x,transform.eulerAngles.y, transform.eulerAngles.z);
        
        if (isReloanding) return;
        if (currentBullet <= 0)
        {
            if (Input.GetMouseButton(1)) {

                StartCoroutine(Reload());
            }

            return; 
        }

        if (InputManager.GetInstance().GetInteractPressed())
        {

            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloanding = true;

        yield return new WaitForSeconds(reloadTime);
       
        currentBullet = maxBullet;

        isReloanding = false;
    }
    private void Shoot()
    {
        //shootVfx.Play();

        currentBullet--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit,range) ) {

            Target target=hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamege(damage);

            } 

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

           // GameObject impacthit = Instantiate(hitVfx, hit.point, Quaternion.LookRotation(hit.normal));

            //Destroy(impacthit, 1);
        }

       
    } 

}
