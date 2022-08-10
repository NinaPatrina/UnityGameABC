using System.Collections.Generic;
using UnityEngine;

public class HatLogic : MonoBehaviour
{
    [SerializeField] private Transform hatContainer;
    private List<GameObject> hatModels = new List<GameObject>();
    private ABCShop[] abcs;

    private void Start()
    {
        abcs = Resources.LoadAll<ABCShop>("Abc");
        SpawnHats();
        //SelectHats(SaveManager.Instance.save.CurrentHatIndex);
    }
    private void SpawnHats()
    {
        //for (int i = 0; i < hats.Length; i++)
        //{ hatModels.Add(Instantiate(hats[i].Model, hatContainer) as GameObject); }

    }
    public void DisableAllHats()
    {
        for (int i = 0; i < hatModels.Count; i++)
        { hatModels[i].SetActive(false); }
    } 
    public void SelectHats(int index)
    {
        DisableAllHats();
        hatModels[index].SetActive(true); 

    }
}

