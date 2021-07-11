using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionCommand
{
    public CookingAction Action { get; private set; }
    public CookingItemType CookingItem { get; private set; }

    public ActionCommand(CookingAction action, CookingItemType type)
    {
        Action = action;
        CookingItem = type;
    }

    public ActionCommand(CookingAction action)
    {
        Action = action;
        CookingItem = CookingItemType.Base;
    }

    public static bool operator ==(ActionCommand command1, ActionCommand command2)
    {
        return (command1.Action == command2.Action && command1.CookingItem == command2.CookingItem);
    }

    public static bool operator !=(ActionCommand command1, ActionCommand command2)
    {
        return (command1.Action != command2.Action || command1.CookingItem != command2.CookingItem);
    }
}
