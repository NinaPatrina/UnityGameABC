using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameStateDeath : GameState
{
    //public GameObject deathUI;
    //[SerializeField] private TextMeshProUGUI highscore;
    //[SerializeField] private TextMeshProUGUI currentScore;
    //[SerializeField] private TextMeshProUGUI fishTotal;

    //[SerializeField] private TextMeshProUGUI currentFish;
    //[SerializeField] private Image completionCircle;
    public float timeToDecision = 2.5f;
    private float deathTime;


    public override void Construct()
    {
        GameManager.Instance.motor.PausePlayer();
        //deathUI.SetActive(true);
        deathTime = Time.time;
        //completionCircle.gameObject.SetActive(true);

        //Prior to saving set the highscore if needed
        //if (SaveManager.Instance.save.HighScore < (int)GameStat.Instance.score)
        //{
        //    SaveManager.Instance.save.HighScore = (int)GameStat.Instance.score;
        //    currentScore.color = Color.green;
        //}
        //else currentScore.color = Color.white;


        //SaveManager.Instance.save.Fish += GameStat.Instance.fishCollectedThisSession;
        //SaveManager.Instance.Save();

        //highscore.text = "Highscore: "+ SaveManager.Instance.save.HighScore;
        //currentScore.text = GameStat.Instance.ScoreToText();
        //fishTotal.text ="Total fish: " + SaveManager.Instance.save.Fish;
        //currentFish.text = GameStat.Instance.FishToText();
    }
    public override void Destruct()
    {
        //deathUI.SetActive(false);
    }
    public override void UpdateState()
    {
        //float ratio = (Time.time - deathTime) / timeToDecision;
        //completionCircle.color = Color.Lerp(Color.green, Color.red, ratio);
        //completionCircle.fillAmount = 1 - ratio;

        //if (ratio>1)
        //{
        //    completionCircle.gameObject.SetActive(false);
        //}
    }
    public void ResumeGame()
    {
        brain.ChangeState(GetComponent<GameStateGame>());
        GameManager.Instance.motor.RespawnPlayer();
    }
    public void ToMenu()
    {
        
        brain.ChangeState(GetComponent<GameStateInit>());
        GameManager.Instance.motor.ResetPlayer();
        GameManager.Instance.worldGeneration.ResetWorld();
        GameManager.Instance.sceneChunkGeneration.ResetWorld();


    }
}
