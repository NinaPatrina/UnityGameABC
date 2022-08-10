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
        if (other.tag == "Player")
        {
            PickupLetter();
        }
    }
    private void PickupLetter()
    {
        StartCoroutine(MyCoroutine());
        

        //GameStat.Instance.CollectFish();

        //play sound  
    }
    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(1.2f);
        
        anim?.SetTrigger("Pickup");
        
}
    public void OnShowChunk()
    {
        anim?.SetTrigger("Walk");  
    }
}
