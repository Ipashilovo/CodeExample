using System.Collections.Generic;

namespace LevelSystem.GroundEffects
{
    public class GroundEffectPool
    {
        private GroundEffect _groundEffect;
        private List<GroundEffect> _effects;
        private List<GroundEffect> _activityEffects;
        
        public GroundEffectPool(GroundEffect groundEffect)
        {
            _groundEffect = groundEffect;
            _activityEffects = new List<GroundEffect>();
            _effects = new List<GroundEffect>();
        }
        
        public void Clear()
        {
            foreach (var groundEffect in _activityEffects)
            {
                groundEffect.Ended -= AddEffect;
            }
        }
        
        public GroundEffect GetGroundEffect()
        {
            GroundEffect groundEffect;
            if (_effects.Count <= 0)
            {
                groundEffect = _groundEffect.Copy();
            }
            else
            {
                groundEffect = _effects[0];
                _effects.Remove(groundEffect);
            }
            _activityEffects.Add(groundEffect);
            groundEffect.Ended += AddEffect;
            return groundEffect;
        
        }
        
        private void AddEffect(GroundEffect groundEffect)
        {
            groundEffect.Ended -= AddEffect;
            _activityEffects.Remove(groundEffect);
            _effects.Add(groundEffect);
        }
    }
}