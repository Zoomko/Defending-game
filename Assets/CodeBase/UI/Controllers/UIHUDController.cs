using Assets.CodeBase.Factory;
using UnityEngine.UIElements;

namespace Assets.CodeBase.UI
{
    public class UIHUDController
    {
        private UIDocument _document;
        private VisualElement _root;
        private ProgressBar _progressBar;

        public void SetDocument(UIDocument document)
        {
            _document = document;
            _root = _document.rootVisualElement;
            _progressBar = _root.Query<ProgressBar>().First();
        }

        public void OnHealthChanged(int currentValue, int maxValue, int damage)
        {
            _progressBar.lowValue = currentValue;
            _progressBar.highValue = maxValue;
            _progressBar.title = currentValue.ToString() + "/" + maxValue.ToString();
        }
    }
}
