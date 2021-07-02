using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal sealed class HpModel : IHpModel
{
    // Модель данных
    public float MaxHp { get; }
    public float CurrentHp { get; set; }
    public HpModel(float maxHp)
    {
        MaxHp = maxHp;
        CurrentHp = MaxHp;
    }
}

