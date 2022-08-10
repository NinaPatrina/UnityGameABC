using System.Collections.Generic;
using UnityEngine;

public class HatLogic : MonoBehaviour
{
    [SerializeField] private Transform abcContainer;
    private List<GameObject> abcModels = new List<GameObject>();
    private ABCShop[] abcs;

    private void Start()
    {
        abcs = Resources.LoadAll<ABCShop>("ABC");
        SpawnHats();
        //SelectHats(SaveManager.Instance.save.CurrentHatIndex);
    }
    private void SpawnHats()
    {
        for (int i = 0; i < abcs.Length; i++)
        { abcModels.Add(Instantiate(abcs[i].Model, abcContainer) as GameObject); }
        DisableAllHats();

    }
    public void DisableAllHats()
    {
        for (int i = 0; i < abcModels.Count; i++)
        { abcModels[i].SetActive(false); }
    }
    public void SelectHats(int index)
    {
        DisableAllHats();
        abcModels[index].SetActive(true);

    }
}

