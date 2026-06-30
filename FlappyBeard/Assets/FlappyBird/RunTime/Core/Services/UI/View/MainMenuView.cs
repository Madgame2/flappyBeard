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

        private void Awake()
        {
            _playButton.onClick.AddListener(() => OnPlayClicked?.Invoke());
            _exitButton.onClick.AddListener(() => OnExitClicked?.Invoke());
        }
    }
}
