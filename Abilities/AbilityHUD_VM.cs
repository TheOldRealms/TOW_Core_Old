using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.TwoDimension;
using TOW_Core.Battle.Extensions;

namespace TOW_Core.Abilities
{
    public class AbilityHUD_VM : ViewModel
    {
        public AbilityHUD_VM() : base() { }

        public void UpdateProperties()
        {
            if (Agent.Main == null) return;
            this._ability = Agent.Main.GetCurrentAbility();
            this.HasAnyAbility = this._ability != null;
            if (this._hasAnyAbility)
            {
                this.SpriteName = this._ability.SpriteName;
                this.Name = this._ability.Name;
                this.CoolDownLeft = this._ability.GetCoolDownLeft().ToString();
                this.IsOnCoolDown = this._ability.GetOnCoolDownStatus();
            }
        }

        private BaseAbility _ability = null;
        private string _name = "";
        private string _spriteName = "";
        private string _coolDownLeft = "";
        private bool _hasAnyAbility;
        private bool _onCoolDown;

        [DataSourceProperty]
        public bool HasAnyAbility
        {
            get
            {
                return this._hasAnyAbility;
            }
            set
            {
                if (value != this._hasAnyAbility)
                {
                    this._hasAnyAbility = value;
                    base.OnPropertyChangedWithValue(value, "HasAnyAbility");
                }
            }
        }

        [DataSourceProperty]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value != this._name)
                {
                    this._name = value;
                    base.OnPropertyChangedWithValue(value, "Name");
                }
            }
        }

        [DataSourceProperty]
        public string SpriteName
        {
            get
            {
                return this._spriteName;
            }
            set
            {
                if (value != this._spriteName)
                {
                    this._spriteName = value;
                    base.OnPropertyChangedWithValue(value, "SpriteName");
                }
            }
        }

        [DataSourceProperty]
        public string CoolDownLeft
        {
            get
            {
                return this._coolDownLeft;
            }
            set
            {
                if (value != this._coolDownLeft)
                {
                    this._coolDownLeft = value;
                    base.OnPropertyChangedWithValue(value, "CoolDownLeft");
                }
            }
        }

        [DataSourceProperty]
        public bool IsOnCoolDown
        {
            get
            {
                return this._onCoolDown;
            }
            set
            {
                if (value != this._onCoolDown)
                {
                    this._onCoolDown = value;
                    base.OnPropertyChangedWithValue(value, "IsOnCoolDown");
                }
            }
        }
    }
}
