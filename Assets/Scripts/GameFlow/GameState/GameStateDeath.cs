using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameStateDeath : GameState
{
    public GameObject deathUI;
    public Animator anim;


    [SerializeField] private AudioClip gameSleepMusic;

    [SerializeField] private Image completionCircle;

    public float timeToDecision = 5.5f;
    private float deathTime;

    public override void Construct()
    {
        MovePlayerUp();

        GameManager.Instance.motor.PausePlayer();
        deathUI.SetActive(true);
        deathTime = Time.time;
        completionCircle.gameObject.SetActive(true);

        AudioManager.Instance.PlayMusicWithXFade(gameSleepMusic, 0.5f);
    }

      public void MovePlayerUp()
    {
        CharacterController controller = GameManager.Instance.motor.GetComponent<CharacterController>();
        Vector3 m = new Vector3(0,0.22f,0);
        controller.Move(m);
    }

    public override void Destruct()
    {
        deathUI.SetActive(false);
    }
    public override void UpdateState()
    {
        float ratio = (Time.time - deathTime) / timeToDecision;
        Color violet = new Color(129, 51, 189);
        completionCircle.color = Color.Lerp(violet, Color.white, ratio);
        completionCircle.fillAmount = 1 - ratio;

        if (ratio > 1)
        {
            completionCircle.gameObject.SetActive(false);
        }
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
        GameManager.Instance.waterGenerationon.ResetWorld();
        anim?.SetFloat("Speed", 0);


    }
}
