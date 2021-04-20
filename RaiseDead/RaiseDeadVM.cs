using TaleWorlds.Core.ViewModelCollection;
using TaleWorlds.Library;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.EncyclopediaItems;
using TaleWorlds.InputSystem;


namespace TOW_Core
{
	class RaiseDeadVM : ViewModel
	{
		private CharacterViewModel _unitCharacter;
		private CharacterViewModel _unitCharacter2;
		private CharacterViewModel _unitCharacter3;
		private CharacterViewModel _unitCharacter4;
		private CharacterViewModel _unitCharacter5;
		private CharacterViewModel _unitCharacter6;

		private CharacterObject _character1;
		private CharacterObject _character2;
		private CharacterObject _character3;
		private CharacterObject _character4;
		private CharacterObject _character5;
		private CharacterObject _character6;

		private MBBindingList<EncyclopediaSkillVM> _skills;
		private MBBindingList<EncyclopediaSkillVM> _skills2;
		private MBBindingList<EncyclopediaSkillVM> _skills3;
		private MBBindingList<EncyclopediaSkillVM> _skills4;
		private MBBindingList<EncyclopediaSkillVM> _skills5;
		private MBBindingList<EncyclopediaSkillVM> _skills6;

		private MBBindingList<CharacterEquipmentItemVM> _armorsList;
		private MBBindingList<CharacterEquipmentItemVM> _armorsList2;
		private MBBindingList<CharacterEquipmentItemVM> _armorsList3;
		private MBBindingList<CharacterEquipmentItemVM> _armorsList4;
		private MBBindingList<CharacterEquipmentItemVM> _armorsList5;
		private MBBindingList<CharacterEquipmentItemVM> _armorsList6;

		private MBBindingList<CharacterEquipmentItemVM> _weaponsList;
		private MBBindingList<CharacterEquipmentItemVM> _weaponsList2;
		private MBBindingList<CharacterEquipmentItemVM> _weaponsList3;
		private MBBindingList<CharacterEquipmentItemVM> _weaponsList4;
		private MBBindingList<CharacterEquipmentItemVM> _weaponsList5;
		private MBBindingList<CharacterEquipmentItemVM> _weaponsList6;

		public RaiseDeadVM()
		{
			_character1 = Game.Current.ObjectManager.GetObject<CharacterObject>("tow_skeleton_recruit");
			this.UnitCharacter = new CharacterViewModel(CharacterViewModel.StanceTypes.OnMount);
			this.UnitCharacter.FillFrom(_character1, -1);
			this.Skills = new MBBindingList<EncyclopediaSkillVM>();
			foreach (SkillObject skill in SkillObject.All)
			{
				if (isCombatSkill(skill))
				{
					this.Skills.Add(new EncyclopediaSkillVM(skill, _character1.GetSkillValue(skill)));
				}
			}

			this.ArmorsList = new MBBindingList<CharacterEquipmentItemVM>();
			this.WeaponsList = new MBBindingList<CharacterEquipmentItemVM>();

			this.ArmorsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.NumAllWeaponSlots].Item));
			this.ArmorsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.Cape].Item));
			this.ArmorsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.Body].Item));
			this.ArmorsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.Gloves].Item));
			this.ArmorsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.Leg].Item));

			this.WeaponsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.WeaponItemBeginSlot].Item));
			this.WeaponsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.Weapon1].Item));
			this.WeaponsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.Weapon2].Item));
			this.WeaponsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.Weapon3].Item));
			this.WeaponsList.Add(new CharacterEquipmentItemVM(this._character1.Equipment[EquipmentIndex.Weapon4].Item));

			_character2 = Game.Current.ObjectManager.GetObject<CharacterObject>("tow_skeleton_warrior");
			this.UnitCharacter2 = new CharacterViewModel(CharacterViewModel.StanceTypes.OnMount);
			this.UnitCharacter2.FillFrom(_character2, -1);
			this.Skills2 = new MBBindingList<EncyclopediaSkillVM>();
			foreach (SkillObject skill in SkillObject.All)
			{
				if (isCombatSkill(skill))
				{
					this.Skills2.Add(new EncyclopediaSkillVM(skill, _character2.GetSkillValue(skill)));
				}
			}

			this.ArmorsList2 = new MBBindingList<CharacterEquipmentItemVM>();
			this.WeaponsList2 = new MBBindingList<CharacterEquipmentItemVM>();

			this.ArmorsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.NumAllWeaponSlots].Item));
			this.ArmorsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.Cape].Item));
			this.ArmorsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.Body].Item));
			this.ArmorsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.Gloves].Item));
			this.ArmorsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.Leg].Item));

			this.WeaponsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.WeaponItemBeginSlot].Item));
			this.WeaponsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.Weapon1].Item));
			this.WeaponsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.Weapon2].Item));
			this.WeaponsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.Weapon3].Item));
			this.WeaponsList2.Add(new CharacterEquipmentItemVM(this._character2.Equipment[EquipmentIndex.Weapon4].Item));

			_character3 = Game.Current.ObjectManager.GetObject<CharacterObject>("tow_skeleton_spearman");
			this.UnitCharacter3 = new CharacterViewModel(CharacterViewModel.StanceTypes.OnMount);
			this.UnitCharacter3.FillFrom(_character3, -1);
			this.Skills3 = new MBBindingList<EncyclopediaSkillVM>();
			foreach (SkillObject skill in SkillObject.All)
			{
				if (isCombatSkill(skill))
				{
					this.Skills3.Add(new EncyclopediaSkillVM(skill, _character3.GetSkillValue(skill)));
				}
			}

			this.ArmorsList3 = new MBBindingList<CharacterEquipmentItemVM>();
			this.WeaponsList3 = new MBBindingList<CharacterEquipmentItemVM>();

			this.ArmorsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.NumAllWeaponSlots].Item));
			this.ArmorsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.Cape].Item));
			this.ArmorsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.Body].Item));
			this.ArmorsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.Gloves].Item));
			this.ArmorsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.Leg].Item));

			this.WeaponsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.WeaponItemBeginSlot].Item));
			this.WeaponsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.Weapon1].Item));
			this.WeaponsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.Weapon2].Item));
			this.WeaponsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.Weapon3].Item));
			this.WeaponsList3.Add(new CharacterEquipmentItemVM(this._character3.Equipment[EquipmentIndex.Weapon4].Item));

			_character4 = Game.Current.ObjectManager.GetObject<CharacterObject>("tow_grave_guard");
			this.UnitCharacter4 = new CharacterViewModel(CharacterViewModel.StanceTypes.OnMount);
			this.UnitCharacter4.FillFrom(_character4, -1);
			this.Skills4 = new MBBindingList<EncyclopediaSkillVM>();
			foreach (SkillObject skill in SkillObject.All)
			{
				if (isCombatSkill(skill))
				{
					this.Skills4.Add(new EncyclopediaSkillVM(skill, _character4.GetSkillValue(skill)));
				}
			}

			this.ArmorsList4 = new MBBindingList<CharacterEquipmentItemVM>();
			this.WeaponsList4 = new MBBindingList<CharacterEquipmentItemVM>();

			this.ArmorsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.NumAllWeaponSlots].Item));
			this.ArmorsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.Cape].Item));
			this.ArmorsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.Body].Item));
			this.ArmorsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.Gloves].Item));
			this.ArmorsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.Leg].Item));

			this.WeaponsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.WeaponItemBeginSlot].Item));
			this.WeaponsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.Weapon1].Item));
			this.WeaponsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.Weapon2].Item));
			this.WeaponsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.Weapon3].Item));
			this.WeaponsList4.Add(new CharacterEquipmentItemVM(this._character4.Equipment[EquipmentIndex.Weapon4].Item));

			_character5 = Game.Current.ObjectManager.GetObject<CharacterObject>("tow_grave_guard_greatsword");
			this.UnitCharacter5 = new CharacterViewModel(CharacterViewModel.StanceTypes.OnMount);
			this.UnitCharacter5.FillFrom(_character5, -1);
			this.Skills5 = new MBBindingList<EncyclopediaSkillVM>();
			foreach (SkillObject skill in SkillObject.All)
			{
				if (isCombatSkill(skill))
				{
					this.Skills5.Add(new EncyclopediaSkillVM(skill, _character5.GetSkillValue(skill)));
				}
			}

			this.ArmorsList5 = new MBBindingList<CharacterEquipmentItemVM>();
			this.WeaponsList5 = new MBBindingList<CharacterEquipmentItemVM>();

			this.ArmorsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.NumAllWeaponSlots].Item));
			this.ArmorsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.Cape].Item));
			this.ArmorsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.Body].Item));
			this.ArmorsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.Gloves].Item));
			this.ArmorsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.Leg].Item));

			this.WeaponsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.WeaponItemBeginSlot].Item));
			this.WeaponsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.Weapon1].Item));
			this.WeaponsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.Weapon2].Item));
			this.WeaponsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.Weapon3].Item));
			this.WeaponsList5.Add(new CharacterEquipmentItemVM(this._character5.Equipment[EquipmentIndex.Weapon4].Item));

			_character6 = Game.Current.ObjectManager.GetObject<CharacterObject>("tow_cairn_wraith");
			this.UnitCharacter6 = new CharacterViewModel(CharacterViewModel.StanceTypes.OnMount);
			this.UnitCharacter6.FillFrom(_character6, -1);
			this.Skills6 = new MBBindingList<EncyclopediaSkillVM>();
			foreach (SkillObject skill in SkillObject.All)
			{
				if (isCombatSkill(skill))
				{
					this.Skills6.Add(new EncyclopediaSkillVM(skill, _character6.GetSkillValue(skill)));
				}
			}

			this.ArmorsList6 = new MBBindingList<CharacterEquipmentItemVM>();
			this.WeaponsList6 = new MBBindingList<CharacterEquipmentItemVM>();

			this.ArmorsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.NumAllWeaponSlots].Item));
			this.ArmorsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.Cape].Item));
			this.ArmorsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.Body].Item));
			this.ArmorsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.Gloves].Item));
			this.ArmorsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.Leg].Item));

			this.WeaponsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.WeaponItemBeginSlot].Item));
			this.WeaponsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.Weapon1].Item));
			this.WeaponsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.Weapon2].Item));
			this.WeaponsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.Weapon3].Item));
			this.WeaponsList6.Add(new CharacterEquipmentItemVM(this._character6.Equipment[EquipmentIndex.Weapon4].Item));
		}

		private bool isCombatSkill(SkillObject skill)
		{
			if (skill == DefaultSkills.OneHanded || skill == DefaultSkills.TwoHanded || skill == DefaultSkills.Polearm || skill == DefaultSkills.Bow || skill == DefaultSkills.Crossbow || skill == DefaultSkills.Throwing || skill == DefaultSkills.Riding || skill == DefaultSkills.Athletics)
			{
				return true;
			}
			return false;
		}

		public void UpdateValues()
		{

		}

		public void Close() => RaiseDeadBehavior.DeleteVMLayer();

		public void RecuritUnit1() {
            if (Input.IsKeyDown(InputKey.LeftShift))
            {
				InformationManager.DisplayMessage(new InformationMessage("5 " + _character1.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character1, 5);
			}
            else
            {
				InformationManager.DisplayMessage(new InformationMessage("1 " + _character1.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character1, 1);
            }	
		}

		public void RecuritUnit2()
		{
			if (Input.IsKeyDown(InputKey.LeftShift))
			{
				InformationManager.DisplayMessage(new InformationMessage("5 " + _character2.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character2, 5);
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage("1 " + _character2.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character2, 1);
			}
		}

		public void RecuritUnit3()
		{
			if (Input.IsKeyDown(InputKey.LeftShift))
			{
				InformationManager.DisplayMessage(new InformationMessage("5 " + _character3.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character3, 5);
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage("1 " + _character3.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character3, 1);
			}
		}

		public void RecuritUnit4()
		{
			if (Input.IsKeyDown(InputKey.LeftShift))
			{
				InformationManager.DisplayMessage(new InformationMessage("5 " + _character4.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character4, 5);
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage("1 " + _character4.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character4, 1);
			}
		}

		public void RecuritUnit5()
		{
			if (Input.IsKeyDown(InputKey.LeftShift))
			{
				InformationManager.DisplayMessage(new InformationMessage("5 " + _character5.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character5, 5);
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage("1 " + _character5.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character5, 1);
			}
		}

		public void RecuritUnit6()
		{
			if (Input.IsKeyDown(InputKey.LeftShift))
			{
				InformationManager.DisplayMessage(new InformationMessage("5 " + _character6.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character6, 5);
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage("1 " + _character6.Name.ToString() + " raised"));
				MobileParty.MainParty.MemberRoster.AddToCounts(_character6, 1);
			}
		}

		[DataSourceProperty]
		public CharacterViewModel UnitCharacter
		{
			get
			{
				return this._unitCharacter;
			}
			set
			{
				if (value != this._unitCharacter)
				{
					this._unitCharacter = value;
					base.OnPropertyChangedWithValue(value, "UnitCharacter");
				}
			}
		}

		[DataSourceProperty]
		public CharacterViewModel UnitCharacter2
		{
			get
			{
				return this._unitCharacter2;
			}
			set
			{
				if (value != this._unitCharacter2)
				{
					this._unitCharacter2 = value;
					base.OnPropertyChangedWithValue(value, "UnitCharacter2");
				}
			}
		}

		[DataSourceProperty]
		public CharacterViewModel UnitCharacter3
		{
			get
			{
				return this._unitCharacter3;
			}
			set
			{
				if (value != this._unitCharacter3)
				{
					this._unitCharacter3 = value;
					base.OnPropertyChangedWithValue(value, "UnitCharacter3");
				}
			}
		}

		[DataSourceProperty]
		public CharacterViewModel UnitCharacter4
		{
			get
			{
				return this._unitCharacter4;
			}
			set
			{
				if (value != this._unitCharacter4)
				{
					this._unitCharacter4 = value;
					base.OnPropertyChangedWithValue(value, "UnitCharacter4");
				}
			}
		}

		[DataSourceProperty]
		public CharacterViewModel UnitCharacter5
		{
			get
			{
				return this._unitCharacter5;
			}
			set
			{
				if (value != this._unitCharacter5)
				{
					this._unitCharacter5 = value;
					base.OnPropertyChangedWithValue(value, "UnitCharacter5");
				}
			}
		}

		[DataSourceProperty]
		public CharacterViewModel UnitCharacter6
		{
			get
			{
				return this._unitCharacter6;
			}
			set
			{
				if (value != this._unitCharacter6)
				{
					this._unitCharacter6 = value;
					base.OnPropertyChangedWithValue(value, "UnitCharacter6");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<EncyclopediaSkillVM> Skills
		{
			get
			{
				return this._skills;
			}
			set
			{
				if (value != this._skills)
				{
					this._skills = value;
					base.OnPropertyChangedWithValue(value, "Skills");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<EncyclopediaSkillVM> Skills2
		{
			get
			{
				return this._skills2;
			}
			set
			{
				if (value != this._skills2)
				{
					this._skills2 = value;
					base.OnPropertyChangedWithValue(value, "Skills2");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<EncyclopediaSkillVM> Skills3
		{
			get
			{
				return this._skills3;
			}
			set
			{
				if (value != this._skills3)
				{
					this._skills3 = value;
					base.OnPropertyChangedWithValue(value, "Skills3");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<EncyclopediaSkillVM> Skills4
		{
			get
			{
				return this._skills4;
			}
			set
			{
				if (value != this._skills4)
				{
					this._skills4 = value;
					base.OnPropertyChangedWithValue(value, "Skills4");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<EncyclopediaSkillVM> Skills5
		{
			get
			{
				return this._skills5;
			}
			set
			{
				if (value != this._skills5)
				{
					this._skills5 = value;
					base.OnPropertyChangedWithValue(value, "Skills5");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<EncyclopediaSkillVM> Skills6
		{
			get
			{
				return this._skills6;
			}
			set
			{
				if (value != this._skills6)
				{
					this._skills6 = value;
					base.OnPropertyChangedWithValue(value, "Skills6");
				}
			}
		}


		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> ArmorsList
		{
			get
			{
				return this._armorsList;
			}
			set
			{
				if (value != this._armorsList)
				{
					this._armorsList = value;
					base.OnPropertyChangedWithValue(value, "ArmorsList");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> ArmorsList2
		{
			get
			{
				return this._armorsList2;
			}
			set
			{
				if (value != this._armorsList2)
				{
					this._armorsList2 = value;
					base.OnPropertyChangedWithValue(value, "ArmorsList2");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> ArmorsList3
		{
			get
			{
				return this._armorsList3;
			}
			set
			{
				if (value != this._armorsList3)
				{
					this._armorsList3 = value;
					base.OnPropertyChangedWithValue(value, "ArmorsList3");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> ArmorsList4
		{
			get
			{
				return this._armorsList4;
			}
			set
			{
				if (value != this._armorsList4)
				{
					this._armorsList4 = value;
					base.OnPropertyChangedWithValue(value, "ArmorsList4");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> ArmorsList5
		{
			get
			{
				return this._armorsList5;
			}
			set
			{
				if (value != this._armorsList5)
				{
					this._armorsList5 = value;
					base.OnPropertyChangedWithValue(value, "ArmorsList5");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> ArmorsList6
		{
			get
			{
				return this._armorsList6;
			}
			set
			{
				if (value != this._armorsList6)
				{
					this._armorsList6 = value;
					base.OnPropertyChangedWithValue(value, "ArmorsList6");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> WeaponsList
		{
			get
			{
				return this._weaponsList;
			}
			set
			{
				if (value != this._weaponsList)
				{
					this._weaponsList = value;
					base.OnPropertyChangedWithValue(value, "WeaponsList");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> WeaponsList2
		{
			get
			{
				return this._weaponsList2;
			}
			set
			{
				if (value != this._weaponsList2)
				{
					this._weaponsList2 = value;
					base.OnPropertyChangedWithValue(value, "WeaponsList2");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> WeaponsList3
		{
			get
			{
				return this._weaponsList3;
			}
			set
			{
				if (value != this._weaponsList3)
				{
					this._weaponsList3 = value;
					base.OnPropertyChangedWithValue(value, "WeaponsList3");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> WeaponsList4
		{
			get
			{
				return this._weaponsList4;
			}
			set
			{
				if (value != this._weaponsList4)
				{
					this._weaponsList4 = value;
					base.OnPropertyChangedWithValue(value, "WeaponsList4");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> WeaponsList5
		{
			get
			{
				return this._weaponsList5;
			}
			set
			{
				if (value != this._weaponsList5)
				{
					this._weaponsList5 = value;
					base.OnPropertyChangedWithValue(value, "WeaponsList5");
				}
			}
		}

		[DataSourceProperty]
		public MBBindingList<CharacterEquipmentItemVM> WeaponsList6
		{
			get
			{
				return this._weaponsList6;
			}
			set
			{
				if (value != this._weaponsList6)
				{
					this._weaponsList6 = value;
					base.OnPropertyChangedWithValue(value, "WeaponsList6");
				}
			}
		}
	}
}
