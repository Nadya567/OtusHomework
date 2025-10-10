using UnityEngine;

namespace MVC
{
    public class MVC_Model
    {
        
    }

    public class MVC_View : MonoBehaviour
    {

    }

    public class MVC_Controller : MonoBehaviour
    {
        [SerializeField] private MVC_View _view;
        private MVC_Model _model;
    }
}