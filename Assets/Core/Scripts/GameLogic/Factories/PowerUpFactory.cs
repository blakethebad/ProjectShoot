using System.Diagnostics;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using UnityEngine.Profiling;

namespace CaseWixot.Core.Scripts
{
    public class PowerUpFactory : IPowerUpFactory
    {
        private IWeapon _weapon;
        private IProjectileFactory _regularFactory;
        private IProjectileFactory _fastFactory;
        private IModifiableStat<int> _speed;
        private IModifiableStat<float> _interval;
        public PowerUpFactory(
            IWeapon weapon,
            IModifiableStat<int> speed,
            IModifiableStat<float> interval,
            IProjectileFactory regularFactory,
            IProjectileFactory fastFactory)
        {
            _weapon = weapon;
            _speed = speed;
            _interval = interval;
            _regularFactory = regularFactory;
            _fastFactory = fastFactory;
        }

        public IPowerUp[] GenerateAll()
        {
            IPowerUp[] powerUps = new IPowerUp[]
            {
                new SpeedPowerUp(_speed, 0),
                new FireIntervalPowerUp(_interval, 1),
                new BulletSpeedPowerUp(_weapon, 2, _regularFactory, _fastFactory),
                new ConeFirePowerUp(_weapon, 3),
                new DoubleFirePowerUp(_weapon, 4)

            };
            return powerUps;
        }
    }
}