using UnityEngine;using VContainer.Unity;

public class GameSessionEntryPoint: IStartable
{
    private IUIManager _uiManager;

    public GameSessionEntryPoint(IUIManager uiManager)
    {
        _uiManager = uiManager;
    }
    
    public void Start()
    {
        _uiManager.Open("ScoreUI");
    }
}
