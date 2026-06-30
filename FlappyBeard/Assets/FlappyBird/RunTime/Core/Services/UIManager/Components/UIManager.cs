using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class UIManager: IUIManager
{
    private UiRoot _uiRoot;
    private readonly UIConfig _uiConfig;
    private readonly IObjectResolver _resolver;
    
    private readonly Dictionary<string, UIElement> _cachedWindows = new ();
    private readonly Stack<UIElement> _uiStack = new();

    public UIManager(UIConfig uiConfig, IObjectResolver resolver)
    {
        _uiConfig = uiConfig;
        _resolver = resolver;
    }
    
    public void SetUIRoot(UiRoot uiRoot)
    {
        _uiRoot = uiRoot;
        ValidateCache();
    }

    public void ClearUIRoot()
    {
        _uiRoot = null;
        _cachedWindows.Clear();
        _uiStack.Clear();
    }
    
    public void Open(string windowId)
    {
        var windowData = _uiConfig.GetWindowData(windowId);
        var uiElement = GetOrCreate(windowData);

        Setup(uiElement, windowData);
    }

    public void CloseTop()
    {
        if (_uiStack.Count > 0)
        {
            _uiStack.Pop().gameObject.SetActive(false);
        }
        if (_uiStack.Count > 0)
        {
            _uiStack.Peek().gameObject.SetActive(true);
        }
    }

    public void CloseAll()
    {
        while (_uiStack.Count > 0)
        {
            _uiStack.Pop().gameObject.SetActive(false);
        }

        foreach (var cachedWindow in _cachedWindows)
        {
            cachedWindow.Value.gameObject.SetActive(false);
        }
    }

    private UIElement GetOrCreate(WindowData windowData)
    {
        if (_cachedWindows.TryGetValue(windowData.ID, out var window))
        {
            return window;
        }

        var windowInstance = InstantiateWindow(windowData);
        _cachedWindows[windowData.ID] = windowInstance;
    
        return windowInstance;
    }

    private UIElement InstantiateWindow(WindowData windowData)
    {
        var windowInstance = _resolver.Instantiate(windowData.Prefab, _uiRoot.transform);
    
        NormalizeRectTransform(windowInstance.GetComponent<RectTransform>(), windowData.Prefab.GetComponent<RectTransform>());
    
        return windowInstance;
    }

    private void Setup(UIElement windowInstance, WindowData metadata)
    {
        if (metadata.Layer == WindowLayer.Popup)
        {
            if (_uiStack.Count > 0)
            {
                _uiStack.Peek().gameObject.SetActive(false);
            }
            _uiStack.Push(windowInstance);
        }

        windowInstance.gameObject.SetActive(true);
    }
    
    private void NormalizeRectTransform(RectTransform instance, RectTransform prefab)
    {
        instance.localScale = Vector3.one;
        instance.anchoredPosition = prefab.anchoredPosition;
        instance.offsetMin = prefab.offsetMin;
        instance.offsetMax = prefab.offsetMax;
    }
    
    private void ValidateCache()
    {
        var destroyedKeys = _cachedWindows
            .Where(pair => pair.Value == null) 
            .Select(pair => pair.Key)
            .ToList();

        foreach (var key in destroyedKeys)
        {
            _cachedWindows.Remove(key);
        }
        
        while (_uiStack.Count > 0 && _uiStack.Peek() == null)
        {
            _uiStack.Pop();
        }
    }
}
