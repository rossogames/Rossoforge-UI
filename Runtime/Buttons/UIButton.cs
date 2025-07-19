using UnityEngine;

namespace Rossoforge.UI.Buttons
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public abstract class UIButton<T> : MonoBehaviour
    {
        private UnityEngine.UI.Button _button;

        private IButtonClickListener<T> _clickListener;

        private void Awake()
        {
            _button = GetComponent<UnityEngine.UI.Button>();
            _clickListener = GetComponentInParent<IButtonClickListener<T>>(true);
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _clickListener.OnButtonClickInvoked(default);
        }
    }
}
