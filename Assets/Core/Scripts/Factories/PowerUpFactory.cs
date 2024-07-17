using System.Diagnostics;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;

namespace CaseWixot.Core.Scripts
{
    public class PowerUpFactory : IPowerUpFactory
    {
        private IMoveHandler _moveHandler;
        private IWeapon _weapon;
        private IProjectileFactory _fastFactory;
        private IProjectileFactory _regularFactory;
        private IWeaponStrategy _regularStrategy;
        private IWeaponStrategy _coneStrategy;
        
        
        public PowerUpFactory(IMoveHandler moveHandler, IWeapon weapon, IProjectileFactory regularFactory, IProjectileFactory fastFactory, IWeaponStrategy regularStrategy, IWeaponStrategy coneStrategy)
        {
            _fastFactory = fastFactory;
            _regularFactory = regularFactory;
            _regularStrategy = regularStrategy;
            _coneStrategy = coneStrategy;

        }
        
        public IPowerUp[] GenerateAll()
        {
            IPowerUp[] powerUps = new IPowerUp[]
            {
                new BulletSpeedBooster(_weapon, _regularFactory, _fastFactory),
                new SpeedBooster(_moveHandler),
                new ConeShotBooster(_weapon, _regularStrategy, _coneStrategy),
                new DoubleShotBooster(_weapon),
                new ShotIntervalBooster(_weapon),
            };

            return powerUps;
        }
    }
}