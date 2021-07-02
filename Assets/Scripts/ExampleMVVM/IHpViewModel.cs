using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IHpViewModel
{
    IHpModel HpModel { get; }
    bool IsDead { get; }
    void ApplyDamage(float damage);
    event Action<float> OnHpChange;
}
