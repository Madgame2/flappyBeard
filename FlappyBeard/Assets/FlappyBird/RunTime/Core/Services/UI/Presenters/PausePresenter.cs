using System;
using FlappyBird.RunTime.Core.Services.ScenesService.Interfaces;
using FlappyBird.RunTime.Core.Services.UI.Interfaces;
using FlappyBird.RunTime.Core.Services.UI.View;
using UnityEngine;
using VContainer.Unity;

namespace FlappyBird.RunTime.Core.Services.UI.Presenters
{
    public class PausePresenter : IInitializable, IDisposable
    {
        private readonly IUIManager _uiManager;
        private readonly InputService _inputService;
        private readonly ISceneService _sceneService;
        private readonly IDialogService _dialogService;

        private PauseMenuView _view;
        private bool _isOpen;

        public PausePresenter(
            IUIManager uiManager,
            InputService inputService,
            ISceneService sceneService,
            IDialogService dialogService)
        {
            _uiManager = uiManager;
            _inputService = inputService;
            _sceneService = sceneService;
            _dialogService = dialogService;
        }

        public void Initialize()
        {
            _inputService.OnCancelRequested += TogglePause;
        }

        public void Dispose()
        {
            _inputService.OnCancelRequested -= TogglePause;

            if (_view != null)
            {
                Unsubscribe();
            }
        }

        private void TogglePause()
        {
            if (_isOpen)
            {
                ClosePause();
            }
            else
            {
                OpenPause();
            }
        }

        private void OpenPause()
        {
            _view = _uiManager.Open<PauseMenuView>("PauseMenu");

            _view.ResumeClicked += OnResume;
            _view.MenuClicked += OnMenu;
            _view.ExitClicked += OnExit;

            Time.timeScale = 0f;
            _isOpen = true;
        }

        private void ClosePause()
        {
            Unsubscribe();

            _uiManager.Close("PauseMenu");

            Time.timeScale = 1f;
            _isOpen = false;
            _view = null;
        }

        private void Unsubscribe()
        {
            _view.ResumeClicked -= OnResume;
            _view.MenuClicked -= OnMenu;
            _view.ExitClicked -= OnExit;
        }

        private void OnResume()
        {
            ClosePause();
        }

        private async void OnMenu()
        {
            bool result = await _dialogService.ShowWarning("Return to main menu?");

            if (!result)
                return;

            Time.timeScale = 1f;
            await _sceneService.LoadScene("MenuScene");
        }

        private async void OnExit()
        {
            bool result = await _dialogService.ShowWarning("Exit game?");

            if (!result)
                return;

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
