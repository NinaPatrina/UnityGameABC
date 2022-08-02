
using UnityEngine;

public class RiverFloor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Material material;
    public float offsetSpeed = 0.25f;

    private void Update()
    {
        transform.position = Vector3.forward * player.transform.position.z;
        material.SetVector("riverOffset", new Vector2(0, -transform.position.z * offsetSpeed));
    }
}
