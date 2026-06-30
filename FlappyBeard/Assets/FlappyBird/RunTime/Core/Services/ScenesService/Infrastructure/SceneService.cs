using Cysharp.Threading.Tasks;
using FlappyBird.RunTime.Core.Services.ScenesService.Interfaces;
using UnityEngine.SceneManagement;

namespace FlappyBird.RunTime.Core.Services.ScenesService.Infrastructure
{
    public class SceneService : ISceneService
    {
        public async UniTask LoadScene(string sceneName)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);

            await operation;
        }
    }
}