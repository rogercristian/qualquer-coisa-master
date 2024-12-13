using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage = 10;
    [SerializeField] private float range = 100;
    [SerializeField] private float timeBetweenAttack = 1f;
    private float currentTimeAttack;
    [SerializeField] Transform attackPoint;
  
   // bool interact = false;

    private void Awake()
    {
      
        
    }

   

    // Start is called before the first frame update
    void Start()
    {





    }

    // Update is called once per frame
    void Update()
    {
       // if (!interact) return;
        Attack();

        Debug.DrawRay(attackPoint.position, Vector3.forward,Color.red,range);

    }


    private void Attack()
    {
       

       
        RaycastHit hit;
        if (Physics.Raycast(attackPoint.position, attackPoint.forward, out hit, range))
        {

            FpsMove player = hit.transform.GetComponent<FpsMove>(); 
            if (player != null)
            {
                Debug.Log("colisão com o player" + hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {
                    Debug.Log("colisão com o player" + hit.transform.name);

           
                    
                    target.TakeDamege(damage);


                    //target.TakeDamege(damage);//

                }


            }

        

            if (hit.rigidbody != null)
            {
                //hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

           //GameObject impacthit = Instantiate(hitVfx, hit.point, Quaternion.LookRotation(hit.normal));

            //Destroy(impacthit, 1);//
        }

    }
}

