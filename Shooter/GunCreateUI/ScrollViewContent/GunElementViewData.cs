using System;
using UnityEngine;

namespace GunCreateUI.ScrollViewContent
{
  public class GunElementViewData<T>
  {
    private ButtonHandler _buttonHandler;
    public T Type { get; }

    public event Action<T, bool> Selected;

    public GunElementViewData(T type, ButtonHandler buttonHandler)
    {
      _buttonHandler = buttonHandler;
      buttonHandler.Clicked += Notify;
      Type = type;
    }

    public void Clear()
    {
      _buttonHandler.Clicked -= Notify;
    }

    private void Notify(bool isColorTab)
    {
      Selected?.Invoke(Type, isColorTab);
    }
  }
}