using DefaultNamespace.UI.GunUI;

namespace ActivityLevel.ShootHandlers
{
    public class LaserViewMediator
    {
        private IValueCanger _laserShootHandler;
        private LaserSlider _laserSlider;

        public LaserViewMediator(IValueCanger laserShootHandler, LaserSlider laserSlider)
        {
            _laserShootHandler = laserShootHandler;
            _laserSlider = laserSlider;
            _laserSlider.SetMaxValue(_laserShootHandler.GetMaxValue());
            _laserSlider.Destroying += Clear;
            _laserShootHandler.ValueChanged += SetNewValue;
            _laserSlider.gameObject.SetActive(true);
        }

        private void SetNewValue(float value)
        {
            _laserSlider.SetValue(value);
        }

        private void Clear()
        {
            _laserShootHandler.ValueChanged -= SetNewValue;
            _laserSlider.Destroying -= Clear;
        }
    }
}