using System;

using TaleWorlds.Library;

namespace TOW_Core.Screen.InitialScreen
{
    public class TOWInitialScreenVM : ViewModel
    {
        private Action action;
        private string text;

        public TOWInitialScreenVM(string text, Action action)
        {
            this.text = text;
            this.action = action;
        }

        [DataSourceProperty]
        public string NameText
        {
            get
            {
                return this.text;
            }
        }

        public void ExecuteAction()
        {
            this.action();
        }
    }
}
