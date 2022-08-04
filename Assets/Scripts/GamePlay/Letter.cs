using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private Animator anim;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Player")
        {
            
            PickupLetter();

        }

    }
    private void PickupLetter()
    {
        anim?.SetTrigger("Pickup");
        
        //GameStat.Instance.CollectFish();

        //play sound
        //trigger an animation

    }
    public void OnShowChunk()
    {
        anim?.SetTrigger("Walk");
        
    }
}
