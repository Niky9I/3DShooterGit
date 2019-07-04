using System;
using Geekbrains.Interface;

namespace Geekbrains
{
    public class BodyBot : BaseObjectScene, ISetDamage
    {
        public event Action<InfoCollision> OnApplyDamageChange;
        public void SetDamage(InfoCollision info)
        {
            OnApplyDamageChange?.Invoke(info);
        }
    }
}