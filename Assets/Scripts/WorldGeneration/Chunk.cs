using UnityEngine;

public class Chunk : MonoBehaviour
{
    public float _chunkLenght;
    
    public Chunk ShowChank()
    {
        //transform.gameObject.BroadcastMessage("OnShowChunk", SendMessageOptions.DontRequireReceiver);
        gameObject.SetActive(true);
        return this;
    }
    public Chunk HideChank()
    {
        gameObject.SetActive(false);
        return this;
    }
}
