using System;
using UnityEngine;
using VContainer.Unity;

public class SceneUiInitializer: IInitializable, IDisposable
{
    private UiRoot _uiRoot;
    private IUIManager _uiManager;

    public SceneUiInitializer(UiRoot uiRoot, IUIManager uiManager)
    {
        _uiRoot = uiRoot;
        _uiManager = uiManager;
    }
    
    public void Initialize()
    {
        _uiManager.SetUIRoot(_uiRoot);
    }

    public void Dispose()
    {
        _uiManager.ClearUIRoot();
    }
}
