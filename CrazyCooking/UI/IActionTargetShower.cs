using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActionTargetShower
{
    public void SetAction(ActionCommand _actionCommand);

    public void SetCooldown(float time);

    public void ShowComplite();

    public void ShowFail();

    public void Hide();
}
