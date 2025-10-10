using UnityEngine;

namespace MVP
{
    public class MVP_Model
    {

    }

    public class MVP_View : MonoBehaviour
    {

    }

    public class MVP_Presenter
    {
        private MVP_Model _model;
        private MVP_View _view;

        public MVP_Presenter(MVP_Model model, MVP_View view)
        {
            _model = model;
            _view = view;
        }
    }
}