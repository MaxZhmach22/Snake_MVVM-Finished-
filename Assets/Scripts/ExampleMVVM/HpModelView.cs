using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

sealed class HpModelView : IHpViewModel
{
    private bool _isDead;
    public event Action<float> OnHpChange;
    public IHpModel HpModel { get; }
    public bool IsDead => _isDead;
    public HpModelView(IHpModel hpModel)
    {
        HpModel = hpModel;
    }
    public void ApplyDamage(float damage)
    {
        HpModel.CurrentHp -= damage;
        if (HpModel.CurrentHp <= 0)
        {
            _isDead = true;
        }
        OnHpChange?.Invoke(HpModel.CurrentHp);
    }
}
