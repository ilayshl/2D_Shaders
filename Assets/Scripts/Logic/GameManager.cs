using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public GameState state {get; private set;}
    [SerializeField] private UIManager uiManager;
    [SerializeField] private SpawnerManager spawnerManager;
    [SerializeField] private InventoryPanel panel;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            var isActive = panel.gameObject.activeInHierarchy;
            panel.gameObject.SetActive(!isActive);
            spawnerManager.HandleStateChange(panel.gameObject.activeInHierarchy);
        }
    }

    private void UpdateGameState(GameState newState)
    {
        switch(newState)
        {
            case GameState.Active:

            break;
            case GameState.Inventory:

            break;
            case GameState.Pause:

            break;
        }
    }
}


public enum GameState
{
    Active,
    Inventory,
    Pause
}
