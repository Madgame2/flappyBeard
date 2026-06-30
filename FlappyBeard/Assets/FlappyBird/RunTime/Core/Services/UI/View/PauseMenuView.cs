using System;
using FlappyBird.RunTime.Core.Services.UI.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.RunTime.Core.Services.UI.View
{
    public class PauseMenuView : UIElement
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _exitButton;

        public event Action ResumeClicked;
        public event Action MenuClicked;
        public event Action ExitClicked;

        private void Awake()
        {
            _resumeButton.onClick.AddListener(() => ResumeClicked?.Invoke());
            _menuButton.onClick.AddListener(() => MenuClicked?.Invoke());
            _exitButton.onClick.AddListener(() => ExitClicked?.Invoke());
        }
    }
}