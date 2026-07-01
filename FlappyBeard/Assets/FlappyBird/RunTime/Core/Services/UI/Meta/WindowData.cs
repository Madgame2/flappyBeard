using System;
using FlappyBird.RunTime.Core.Services.UI.Components;

namespace FlappyBird.RunTime.Core.Services.UI.Meta
{
    [Serializable]
    public struct WindowData
    {
        public string ID;
        public WindowLayer Layer;
        public UIElement Prefab;
    }
}