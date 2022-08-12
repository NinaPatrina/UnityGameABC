//using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateShop : GameState
{
    public GameObject shopUI;  
    public HatLogic hatLogic;
    //private bool isInit = false;

    //Shop item
    public GameObject abcPrefab;
    public Transform abcContainer;
    private ABCShop[] abcs;

    //completion circle
    //public Image completionCircle;
    //public TextMeshProUGUI completionText;

    [SerializeField] private AudioClip shopMusic;

    //!!!!!
    protected override void Awake()
    {
        base.Awake();
        abcs = Resources.LoadAll<ABCShop>("ABC");
        PopulateShop();
    }
    public override void Construct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Shop);
        //abcs = Resources.LoadAll<ABCShop>("ABC");
        shopUI.SetActive(true);
        AudioManager.Instance.PlaySFX(shopMusic, 1f);
        //PopulateShop();

    }
    public override void Destruct()
    {
        shopUI.SetActive(false);
    }
    private void PopulateShop()
    {
        for (int i = 0; i < abcs.Length; i++)
        {
            int index = i;
            GameObject go = Instantiate(abcPrefab, abcContainer) as GameObject;
            //Button
            go.GetComponent<Button>().onClick.AddListener(() => OnHatClick(index));
            //Thumbnail
            go.transform.GetChild(0).GetComponent<Image>().sprite = abcs[index].Thumbnail;
            ////ItemName
            //go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = hats[index].ItemName;

            //    //Price
            //    //if (SaveManager.Instance.save.UnlokedHatFlag[i] == 0)
            //        go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = hats[index].ItemPrice.ToString();
            //    else
            //    { go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            //        unlockedHatCount++;
            //    }

        }
    }
    private void OnHatClick(int i)
    {
        //if (SaveManager.Instance.save.UnlokedHatFlag[i] == 1)
        //{
        //    SaveManager.Instance.save.CurrentHatIndex = i;
        //    currentHatName.text = hats[i].ItemName;
            hatLogic.SelectHats(i);
        //    SaveManager.Instance.Save();
        //}
        //// if we dont have it can we buy it?
        //else if (hats[i].ItemPrice<= SaveManager.Instance.save.Fish)
        //{
        //    SaveManager.Instance.save.Fish -= hats[i].ItemPrice;
        //    SaveManager.Instance.save.UnlokedHatFlag[i] = 1;
        //    SaveManager.Instance.save.CurrentHatIndex = i;
        //    currentHatName.text = hats[i].ItemName;
        //    hatLogic.SelectHats(i);
        //    totalFish.text = SaveManager.Instance.save.Fish.ToString("000");
        //    SaveManager.Instance.Save();
        //    hatContainer.GetChild(i).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
        //    unlockedHatCount++;
        //    ResetCompletionCircle();
        //}
        ////dont have it, cant buy it
        //else
        //{

        //}
    }
    
    public void OnHomeClick()
    {
        brain.ChangeState(GetComponent<GameStateInit>());
    }
}
