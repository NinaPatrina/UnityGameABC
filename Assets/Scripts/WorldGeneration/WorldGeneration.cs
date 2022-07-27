using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{   //Gameplay
    private float _chunkSpawnZ;
    private Queue<Chunk> _activeChunks = new Queue<Chunk>();
    private List<Chunk> _chunkPool = new List<Chunk>();


    //configurable pool
    [SerializeField] private int firstChunkSpawnPosition = 5;
    [SerializeField] private int _chunkOnScreen = 5;
    [SerializeField] private float _despawnDistance = 5.0f;

    [SerializeField] private List<GameObject> chunkPrefab;
    [SerializeField] private Transform cameraTransform;

    private void Awake()
    {
        ResetWorld();
    }
    void Start()
    {   //check if we have an empty chankPrefab list
        if (chunkPrefab.Count==0)
        {
            Debug.LogError("No chank prefab found on the world generator");
            return;
        }

        //try to assign the camera
        //!! the code does not work with assigned MainCamera !!
        if (!cameraTransform)
        {
            cameraTransform = Camera.main.transform;
            Debug.LogError("We've assigned cameraTransform automatially to the main camera");
        }
        ResetWorld();
    
    }
    
    public void ScanPosition()
    {
        float cameraZ = cameraTransform.position.z;

        Chunk lastChank = _activeChunks.Peek();

        if (cameraZ>=(lastChank.transform.position.z+lastChank._chunkLenght+_despawnDistance))
        {
            SpawnNewChunk();
            DeleteLastChunk();
        }
    }
    private void SpawnNewChunk()
    {
        int randomIndex = Random.Range(0, chunkPrefab.Count);

        Chunk chunk =_chunkPool.Find(x=>!x.gameObject.activeSelf && x.name==(chunkPrefab[randomIndex].name+"(Clone)"));

        if (!chunk)
        {
            GameObject go = Instantiate(chunkPrefab[randomIndex], transform);
            chunk = go.GetComponent<Chunk>();
        }
        chunk.transform.position = new Vector3(0, 0, _chunkSpawnZ);
        _chunkSpawnZ += chunk._chunkLenght;

        _activeChunks.Enqueue(chunk);
        chunk.ShowChank();
    }
    private void DeleteLastChunk()
    {
        Chunk chunk = _activeChunks.Dequeue();
        chunk.HideChank();
        _chunkPool.Add(chunk);

    }
    public void ResetWorld()
    {
        _chunkSpawnZ = firstChunkSpawnPosition;
        for (int i = _activeChunks.Count; i != 0; i--)
            DeleteLastChunk();
        for (int i = 0; i < _chunkOnScreen; i++)
            SpawnNewChunk();
    }

}
