using System;
using System.Collections.Generic;
using Gun;
using UnityEngine;

namespace ActivityLevel.Reward
{
    public abstract class RewardCell
    {
        public event Action<RewardCell> Selected;

        public abstract Sprite GetSprite();
        public abstract string GetText();
        public abstract void Select();
    }
}