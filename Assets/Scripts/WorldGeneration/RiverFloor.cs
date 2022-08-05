
using UnityEngine;

public class RiverFloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    

    private void Update()
    {
        transform.position = Vector3.forward * player.transform.position.z;
        
    }
}
