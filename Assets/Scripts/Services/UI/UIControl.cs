using Grace.DependencyInjection;
using ParagorGames.TestProject.UI;
using UnityEngine;

namespace ParagorGames.TestProject.Services.UI
{
    public class UIControl
    {
        private readonly IExportLocatorScope _exportLocatorScope;
        private View _view;
        public UIControl(string viewName, GameObject parent, IExportLocatorScope exportLocatorScope)
        {
            _exportLocatorScope = exportLocatorScope;
            _view = Object.Instantiate(Resources.Load<View>($"UI/{viewName}"), parent.transform);
            _view.name = viewName;
            _exportLocatorScope.Inject(_view);
        }

        public void Close()
        {
            Object.Destroy(_view.gameObject);
        }
    }
}