using System.Collections;

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

    }
    private IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(2.5f);

        anim?.SetTrigger("Pickup");

    }
    public void OnShowChunk()
    {
        anim?.SetTrigger("Reappearing");
        StartCoroutine(MyCoroutine1());
        Debug.Log("BROADcasting");

    }
    private IEnumerator MyCoroutine1()
    {
        yield return new WaitForSeconds(5f);

        anim?.SetTrigger("Walk");

    }
}
