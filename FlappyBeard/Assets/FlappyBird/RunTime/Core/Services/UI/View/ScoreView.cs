using FlappyBird.RunTime.Core.Services.UI.Components;
using TMPro;
using UnityEngine;

namespace FlappyBird.RunTime.Core.Services.UI.View
{
    public class ScoreView : UIElement
    {
        [SerializeField] private TMP_Text _scoreText;

        public void SetScore(int value)
        {
            _scoreText.text = value.ToString();
        }
    }
}