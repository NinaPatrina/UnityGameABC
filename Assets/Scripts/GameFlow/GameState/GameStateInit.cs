using UnityEngine;
using TMPro;
public class GameStateInit : GameState
{
    public GameObject menuUI;
    
    [SerializeField] private AudioClip menuLoopMusic; 
    public override void Construct()
    {
        
        GameManager.Instance.ChangeCamera(GameCamera.Init);

        menuUI.SetActive(true);

        AudioManager.Instance.PlayMusicWithXFade(menuLoopMusic, 0.2f);
    }

    public override void Destruct()
    {
        menuUI.SetActive(false);
    }
    public void OnPlayClick()
    {
        brain.ChangeState(GetComponent<GameStateGame>());
    }
    public void OnABCClick()
    {
        brain.ChangeState(GetComponent<GameStateShop>());
    }
}
