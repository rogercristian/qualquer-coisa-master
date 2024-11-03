using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField] GameObject quebravel;
    public void Destruindo()
    {

        Instantiate(quebravel, transform.position,transform.rotation);

        Destroy(gameObject);

    }





  
    
    
    
    
   
   
}
