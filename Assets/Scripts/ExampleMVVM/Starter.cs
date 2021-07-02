using UnityEngine;

    sealed class Starter : MonoBehaviour
    {
        [SerializeField] private HpView _hpView;
        [SerializeField] private ApplyDamageView _applyDamageView;
        private void Start()
        {
            var hpModel = new HpModel(100);
            var hpViewModel = new HpModelView(hpModel);
            _hpView.Initialize(hpViewModel);
            _applyDamageView.Initialize(hpViewModel);
        }
    }
