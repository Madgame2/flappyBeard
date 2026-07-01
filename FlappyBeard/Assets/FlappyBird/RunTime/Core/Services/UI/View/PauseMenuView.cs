using System;
using FlappyBird.RunTime.Core.Services.UI.Components;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.RunTime.Core.Services.UI.View
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class PauseMenuView : UIElement
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _exitButton;

        public event Action OnResumeClicked;
        public event Action OnMenuClicked;
        public event Action OnExitClicked;

        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(OnResumeHandle);
            _menuButton.onClick.AddListener(OnMenuHandle);
            _exitButton.onClick.AddListener(OnExitHandle);
        }

        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(OnResumeHandle);
            _menuButton.onClick.RemoveListener(OnMenuHandle);
            _exitButton.onClick.RemoveListener(OnExitHandle);
        }

        private void OnResumeHandle()
        {
            OnResumeClicked?.Invoke();
        }

        private void OnMenuHandle()
        {
            OnMenuClicked?.Invoke();
        }

        private void OnExitHandle()
        {
            OnExitClicked?.Invoke();
        }
    }
}