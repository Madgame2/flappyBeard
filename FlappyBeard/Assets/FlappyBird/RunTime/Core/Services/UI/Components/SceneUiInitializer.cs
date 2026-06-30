using System;
using FlappyBird.RunTime.Core.Services.UI.Interfaces;
using VContainer;
using VContainer.Unity;

namespace FlappyBird.RunTime.Core.Services.UI.Components
{
    public class SceneUiInitializer: IInitializable, IDisposable
    {
        private UiRoot _uiRoot;
        private IUIManager _uiManager;
        private IObjectResolver _objectResolver;

        public SceneUiInitializer(UiRoot uiRoot, IUIManager uiManager, IObjectResolver objectResolver)
        {
            _uiRoot = uiRoot;
            _uiManager = uiManager;
            _objectResolver = objectResolver;
        }
    
        public void Initialize()
        {
            _uiManager.SetUIRoot(_uiRoot);
            _uiManager.SetSceneResolver(_objectResolver);
        }

        public void Dispose()
        {
            _uiManager.ClearUIRoot();
        }
    }
}
