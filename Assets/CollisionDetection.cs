using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public ArmsController ac;
    public GameObject HitParticle;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && ac.IsAttacking)
        {
            Debug.Log(other.name + " successful hit");

            other.GetComponent<Animator>().SetTrigger("Hit");

            Instantiate(HitParticle, new Vector3(other.transform.position.x,
            transform.position.y, other.transform.position.z),
            other.transform.rotation);
        }
    }
}