using System;
using FlappyBird.RunTime.Core.Services.ScenesService.Interfaces;
using FlappyBird.RunTime.Core.Services.UI.Interfaces;
using FlappyBird.RunTime.Core.Services.UI.View;
using VContainer.Unity;

namespace FlappyBird.RunTime.Core.Services.UI.Presenters
{
    public class MainMenuPresenter :IStartable, IDisposable
    {
        private readonly IUIManager _uiManager;
        private  MainMenuView _view;
        private readonly IDialogService _dialogService;
        private readonly ISceneService _sceneService;
    
        public MainMenuPresenter(IUIManager uiManager, IDialogService dialogService, ISceneService sceneService)
        {
            _uiManager = uiManager;
            _dialogService = dialogService;
            _sceneService = sceneService;
        }

        public void Start()
        {
            _view = _uiManager.Open<MainMenuView>("MainMenu");

            _view.OnPlayClicked += HandlePlay;
            _view.OnExitClicked += HandleExit;
        }

        private async void HandlePlay()
        {
            await _sceneService.LoadScene("GameScene");
        }

        private async void HandleExit()
        {
            if (!await _dialogService.ShowWarning("Are you sure you want to exit the game?"))
                return;

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }

        public void Dispose()
        {
            _view.OnPlayClicked -= HandlePlay;
            _view.OnExitClicked -= HandleExit;
        }
    }
}