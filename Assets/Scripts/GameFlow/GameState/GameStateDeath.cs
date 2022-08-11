using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameStateDeath : GameState
{
    public GameObject deathUI;
    
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
        completionCircle.color = Color.Lerp(Color.green, Color.red, ratio);
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
        
    }
}
