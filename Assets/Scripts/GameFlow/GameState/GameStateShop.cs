using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStateShop : GameState
{
    public GameObject shopUI;
    
    
    public HatLogic hatLogic;
    private bool isInit = false;

    //Shop item
    public GameObject hatPrefab;
    public Transform hatContainer;
    private ABCShop[] abcs;

    //completion circle
    public Image completionCircle;
    public TextMeshProUGUI completionText;

    
    public override void Construct()
    {
        GameManager.Instance.ChangeCamera(GameCamera.Shop);
        abcs = Resources.LoadAll<ABCShop>("ABCShop");
        shopUI.SetActive(true);

        if (!isInit)
        {
       
        PopulateShop();
        isInit = true;
        }
      
    }
    public override void Destruct()
    {
        shopUI.SetActive(false);
    }
    private void PopulateShop()
    {
        //for (int i = 0; i < hats.Length; i++)
        //{
        //    int index = i;
        //    GameObject go = Instantiate(hatPrefab, hatContainer) as GameObject;
        //    //Button
        //    go.GetComponent<Button>().onClick.AddListener(()=>OnHatClick(index));
        //    //Thumbnail
        //    go.transform.GetChild(0).GetComponent<Image>().sprite = hats[index].Thumbnail;
        //    //ItemName
        //    go.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = hats[index].ItemName;

        //    //Price
        //    //if (SaveManager.Instance.save.UnlokedHatFlag[i] == 0)
        //        go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = hats[index].ItemPrice.ToString();
        //    else
        //    { go.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
        //        unlockedHatCount++;
        //    }

        //}
    }
    private void OnHatClick(int i)
    {
        //if (SaveManager.Instance.save.UnlokedHatFlag[i] == 1)
        //{
        //    SaveManager.Instance.save.CurrentHatIndex = i;
        //    currentHatName.text = hats[i].ItemName;
        //    hatLogic.SelectHats(i);
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
