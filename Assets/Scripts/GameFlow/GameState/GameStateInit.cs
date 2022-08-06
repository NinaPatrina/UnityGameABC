using UnityEngine;
using TMPro;
public class GameStateInit : GameState
{

    //!!!!! temporary
    public override void UpdateState()
    {
        if (InputManager.Instance.Tap)
            brain.ChangeState(GetComponent<GameStateGame>());
    }
    //!!!!!!!!









    //public GameObject menuUI;
    //[SerializeField] private TextMeshProUGUI hiscoreText;
    //[SerializeField] private TextMeshProUGUI fishcountText;
    //[SerializeField] private AudioClip menuLoopMusic; 
    public override void Construct()
    {
        
        GameManager.Instance.ChangeCamera(GameCamera.Init);
        //hiscoreText.text ="Highscoer: " + SaveManager.Instance.save.HighScore.ToString();
        //fishcountText.text = "Fish: " + SaveManager.Instance.save.Fish.ToString();

        //menuUI.SetActive(true);

        //AudioManager.Instance.PlayMusicWithXFade(menuLoopMusic, 0.5f);
    }

    public override void Destruct()
    {
        //menuUI.SetActive(false);
    }
    public void OnPlayClick()
    {
       // brain.ChangeState(GetComponent<GameStateGame>());
        //GameStat.Instance.ResetSession();
    }
    public void OnShopClick()
    {
        //brain.ChangeState(GetComponent<GameStateShop>());
    }
}
