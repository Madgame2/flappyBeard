using System;
using FlappyBird.RunTime.Core.Services.UI.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FlappyBird.RunTime.Core.Services.UI.View
{
    public class WarningQuestionView : UIElement
    {
        [SerializeField] private TMP_Text _message;
        [SerializeField] private Button _yesButton;
        [SerializeField] private Button _noButton;

        public event Action Accepted;
        public event Action Rejected;

        private void Awake()
        {
            _yesButton.onClick.AddListener(() => Accepted?.Invoke());
            _noButton.onClick.AddListener(() => Rejected?.Invoke());
        }

        public void SetMessage(string message)
        {
            _message.text = message;
        }
    }
}
