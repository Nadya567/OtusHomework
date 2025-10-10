using UnityEngine;

namespace MVA
{
    public class MVA_Model
    {

    }

    public class MVA_View : MonoBehaviour
    {

    }

    public class MVA_Adapter : MonoBehaviour
    {
        private MVA_Model _model;
        [SerializeField] private MVA_View _view;
    }
}

