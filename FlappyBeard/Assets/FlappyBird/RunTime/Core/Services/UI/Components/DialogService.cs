using Cysharp.Threading.Tasks;
using FlappyBird.RunTime.Core.Services.UI.Interfaces;
using FlappyBird.RunTime.Core.Services.UI.View;

namespace FlappyBird.RunTime.Core.Services.UI.Components
{
    public class DialogService : IDialogService
    {
        private readonly IUIManager _uiManager;

        public DialogService(IUIManager uiManager)
        {
            _uiManager = uiManager;
        }
    
        public async UniTask<bool> ShowWarning(string message)
        {
            var dialog = _uiManager.Open<WarningQuestionView>("WarningQuestion");

            dialog.SetMessage(message);

            var tcs = new UniTaskCompletionSource<bool>();

            void OnAccepted()
            {
                dialog.Accepted -= OnAccepted;
                dialog.Rejected -= OnRejected;

                _uiManager.Close("WarningQuestion");

                tcs.TrySetResult(true);
            }

            void OnRejected()
            {
                dialog.Accepted -= OnAccepted;
                dialog.Rejected -= OnRejected;

                _uiManager.Close("WarningQuestion");

                tcs.TrySetResult(false);
            }

            dialog.Accepted += OnAccepted;
            dialog.Rejected += OnRejected;

            return await tcs.Task;
        }
    }
}
