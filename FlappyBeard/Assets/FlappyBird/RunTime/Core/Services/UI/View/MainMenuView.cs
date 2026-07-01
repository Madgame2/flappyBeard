using System;
using FlappyBird.RunTime.Core.Services.UI.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.RunTime.Core.Services.UI.View
{
    public class MainMenuView : UIElement
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        public event Action OnPlayClicked;
        public event Action OnExitClicked;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayPressedHandler);
            _exitButton.onClick.AddListener(OnExitHandler);
        }

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayPressedHandler);
            _exitButton.onClick.RemoveListener(OnExitHandler);
        }

        private void OnPlayPressedHandler()
        {
            OnPlayClicked?.Invoke();
        }

        private void OnExitHandler()
        {
            OnExitClicked?.Invoke();
        }
    }
}