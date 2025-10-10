using System;
using UnityEngine;

namespace MVVM
{
    public class MVVM_Model
    {
        public event Action<int> Event1;

        //Event1?.Invoke();
    }

    public class MVVM_ViewModel
    {
        private MVVM_Model _model;
        public event Action<int> Event2;

        public MVVM_ViewModel()
        {
            _model.Event1 += Method1;
        }

        public void Method1(int a)
        {
            Event2?.Invoke(a);
        }
    }

    public class MVVM_View : MonoBehaviour
    {
        private MVVM_ViewModel _viewModel;

        private void Start()
        {
            _viewModel.Event2 += UpdateUI;
        }

        public void UpdateUI(int a) { }
    } 
}