using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private Animator anim;
    public AudioClip letterSound;

    
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickupLetter();
            AudioManager.Instance.PlaySFX(letterSound, 0.7f);
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
