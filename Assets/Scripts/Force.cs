using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    [SerializeField] float vauleForce; 
    private Vector3 dirForce;
    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        dirForce = Controller.dir;
        dirForce = new Vector3(-dirForce.x, 0, -dirForce.y);
       

        other.GetComponent<Rigidbody>().AddForce(dirForce * vauleForce);

        if (other.GetComponent<Enamy>() != null)
        {
            other.GetComponent<Enamy>().Death();
        }

    }
}
