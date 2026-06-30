using UnityEngine;

public interface IUIManager
{
    void SetUIRoot(UiRoot uiRoot);
    void ClearUIRoot();
    void Open(string windowId);
    void CloseTop();
    void CloseAll();
}
