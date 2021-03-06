﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TollTicketManagement.Model
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HPE")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertLS_Route(LS_Route instance);
    partial void UpdateLS_Route(LS_Route instance);
    partial void DeleteLS_Route(LS_Route instance);
    partial void InsertLS_Lane(LS_Lane instance);
    partial void UpdateLS_Lane(LS_Lane instance);
    partial void DeleteLS_Lane(LS_Lane instance);
    partial void InsertOUT_CheckSmartCard(OUT_CheckSmartCard instance);
    partial void UpdateOUT_CheckSmartCard(OUT_CheckSmartCard instance);
    partial void DeleteOUT_CheckSmartCard(OUT_CheckSmartCard instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::TollTicketManagement.Properties.Settings.Default.HPEConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<LS_Route> LS_Routes
		{
			get
			{
				return this.GetTable<LS_Route>();
			}
		}
		
		public System.Data.Linq.Table<LS_Lane> LS_Lanes
		{
			get
			{
				return this.GetTable<LS_Lane>();
			}
		}
		
		public System.Data.Linq.Table<OUT_CheckSmartCard> OUT_CheckSmartCards
		{
			get
			{
				return this.GetTable<OUT_CheckSmartCard>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LS_Route")]
	public partial class LS_Route : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RouteID;
		
		private string _RouteCode;
		
		private string _Name;
		
		private int _FromStationID;
		
		private int _ToStationID;
		
		private System.Nullable<int> _Length;
		
		private string _Note;
		
		private System.Nullable<bool> _IsMaxLength;
		
		private bool _IsUsed;
		
		private EntitySet<OUT_CheckSmartCard> _OUT_CheckSmartCards;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRouteIDChanging(int value);
    partial void OnRouteIDChanged();
    partial void OnRouteCodeChanging(string value);
    partial void OnRouteCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnFromStationIDChanging(int value);
    partial void OnFromStationIDChanged();
    partial void OnToStationIDChanging(int value);
    partial void OnToStationIDChanged();
    partial void OnLengthChanging(System.Nullable<int> value);
    partial void OnLengthChanged();
    partial void OnNoteChanging(string value);
    partial void OnNoteChanged();
    partial void OnIsMaxLengthChanging(System.Nullable<bool> value);
    partial void OnIsMaxLengthChanged();
    partial void OnIsUsedChanging(bool value);
    partial void OnIsUsedChanged();
    #endregion
		
		public LS_Route()
		{
			this._OUT_CheckSmartCards = new EntitySet<OUT_CheckSmartCard>(new Action<OUT_CheckSmartCard>(this.attach_OUT_CheckSmartCards), new Action<OUT_CheckSmartCard>(this.detach_OUT_CheckSmartCards));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int RouteID
		{
			get
			{
				return this._RouteID;
			}
			set
			{
				if ((this._RouteID != value))
				{
					this.OnRouteIDChanging(value);
					this.SendPropertyChanging();
					this._RouteID = value;
					this.SendPropertyChanged("RouteID");
					this.OnRouteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteCode", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string RouteCode
		{
			get
			{
				return this._RouteCode;
			}
			set
			{
				if ((this._RouteCode != value))
				{
					this.OnRouteCodeChanging(value);
					this.SendPropertyChanging();
					this._RouteCode = value;
					this.SendPropertyChanged("RouteCode");
					this.OnRouteCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FromStationID", DbType="Int NOT NULL")]
		public int FromStationID
		{
			get
			{
				return this._FromStationID;
			}
			set
			{
				if ((this._FromStationID != value))
				{
					this.OnFromStationIDChanging(value);
					this.SendPropertyChanging();
					this._FromStationID = value;
					this.SendPropertyChanged("FromStationID");
					this.OnFromStationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ToStationID", DbType="Int NOT NULL")]
		public int ToStationID
		{
			get
			{
				return this._ToStationID;
			}
			set
			{
				if ((this._ToStationID != value))
				{
					this.OnToStationIDChanging(value);
					this.SendPropertyChanging();
					this._ToStationID = value;
					this.SendPropertyChanged("ToStationID");
					this.OnToStationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Length", DbType="Int")]
		public System.Nullable<int> Length
		{
			get
			{
				return this._Length;
			}
			set
			{
				if ((this._Length != value))
				{
					this.OnLengthChanging(value);
					this.SendPropertyChanging();
					this._Length = value;
					this.SendPropertyChanged("Length");
					this.OnLengthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Note", DbType="NVarChar(500)")]
		public string Note
		{
			get
			{
				return this._Note;
			}
			set
			{
				if ((this._Note != value))
				{
					this.OnNoteChanging(value);
					this.SendPropertyChanging();
					this._Note = value;
					this.SendPropertyChanged("Note");
					this.OnNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsMaxLength", DbType="Bit")]
		public System.Nullable<bool> IsMaxLength
		{
			get
			{
				return this._IsMaxLength;
			}
			set
			{
				if ((this._IsMaxLength != value))
				{
					this.OnIsMaxLengthChanging(value);
					this.SendPropertyChanging();
					this._IsMaxLength = value;
					this.SendPropertyChanged("IsMaxLength");
					this.OnIsMaxLengthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsUsed", DbType="Bit NOT NULL")]
		public bool IsUsed
		{
			get
			{
				return this._IsUsed;
			}
			set
			{
				if ((this._IsUsed != value))
				{
					this.OnIsUsedChanging(value);
					this.SendPropertyChanging();
					this._IsUsed = value;
					this.SendPropertyChanged("IsUsed");
					this.OnIsUsedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LS_Route_OUT_CheckSmartCard", Storage="_OUT_CheckSmartCards", ThisKey="RouteID", OtherKey="RouteID")]
		public EntitySet<OUT_CheckSmartCard> OUT_CheckSmartCards
		{
			get
			{
				return this._OUT_CheckSmartCards;
			}
			set
			{
				this._OUT_CheckSmartCards.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_OUT_CheckSmartCards(OUT_CheckSmartCard entity)
		{
			this.SendPropertyChanging();
			entity.LS_Route = this;
		}
		
		private void detach_OUT_CheckSmartCards(OUT_CheckSmartCard entity)
		{
			this.SendPropertyChanging();
			entity.LS_Route = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LS_Lane")]
	public partial class LS_Lane : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _LaneID;
		
		private int _StationID;
		
		private string _LaneCode;
		
		private string _Name;
		
		private short _DirectionType;
		
		private int _LaneType;
		
		private string _Note;
		
		private bool _IsUsed;
		
		private EntitySet<OUT_CheckSmartCard> _OUT_CheckSmartCards;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLaneIDChanging(int value);
    partial void OnLaneIDChanged();
    partial void OnStationIDChanging(int value);
    partial void OnStationIDChanged();
    partial void OnLaneCodeChanging(string value);
    partial void OnLaneCodeChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnDirectionTypeChanging(short value);
    partial void OnDirectionTypeChanged();
    partial void OnLaneTypeChanging(int value);
    partial void OnLaneTypeChanged();
    partial void OnNoteChanging(string value);
    partial void OnNoteChanged();
    partial void OnIsUsedChanging(bool value);
    partial void OnIsUsedChanged();
    #endregion
		
		public LS_Lane()
		{
			this._OUT_CheckSmartCards = new EntitySet<OUT_CheckSmartCard>(new Action<OUT_CheckSmartCard>(this.attach_OUT_CheckSmartCards), new Action<OUT_CheckSmartCard>(this.detach_OUT_CheckSmartCards));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LaneID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int LaneID
		{
			get
			{
				return this._LaneID;
			}
			set
			{
				if ((this._LaneID != value))
				{
					this.OnLaneIDChanging(value);
					this.SendPropertyChanging();
					this._LaneID = value;
					this.SendPropertyChanged("LaneID");
					this.OnLaneIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StationID", DbType="Int NOT NULL")]
		public int StationID
		{
			get
			{
				return this._StationID;
			}
			set
			{
				if ((this._StationID != value))
				{
					this.OnStationIDChanging(value);
					this.SendPropertyChanging();
					this._StationID = value;
					this.SendPropertyChanged("StationID");
					this.OnStationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LaneCode", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string LaneCode
		{
			get
			{
				return this._LaneCode;
			}
			set
			{
				if ((this._LaneCode != value))
				{
					this.OnLaneCodeChanging(value);
					this.SendPropertyChanging();
					this._LaneCode = value;
					this.SendPropertyChanged("LaneCode");
					this.OnLaneCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DirectionType", DbType="SmallInt NOT NULL")]
		public short DirectionType
		{
			get
			{
				return this._DirectionType;
			}
			set
			{
				if ((this._DirectionType != value))
				{
					this.OnDirectionTypeChanging(value);
					this.SendPropertyChanging();
					this._DirectionType = value;
					this.SendPropertyChanged("DirectionType");
					this.OnDirectionTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LaneType", DbType="Int NOT NULL")]
		public int LaneType
		{
			get
			{
				return this._LaneType;
			}
			set
			{
				if ((this._LaneType != value))
				{
					this.OnLaneTypeChanging(value);
					this.SendPropertyChanging();
					this._LaneType = value;
					this.SendPropertyChanged("LaneType");
					this.OnLaneTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Note", DbType="NVarChar(500)")]
		public string Note
		{
			get
			{
				return this._Note;
			}
			set
			{
				if ((this._Note != value))
				{
					this.OnNoteChanging(value);
					this.SendPropertyChanging();
					this._Note = value;
					this.SendPropertyChanged("Note");
					this.OnNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsUsed", DbType="Bit NOT NULL")]
		public bool IsUsed
		{
			get
			{
				return this._IsUsed;
			}
			set
			{
				if ((this._IsUsed != value))
				{
					this.OnIsUsedChanging(value);
					this.SendPropertyChanging();
					this._IsUsed = value;
					this.SendPropertyChanged("IsUsed");
					this.OnIsUsedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LS_Lane_OUT_CheckSmartCard", Storage="_OUT_CheckSmartCards", ThisKey="LaneID", OtherKey="LaneID")]
		public EntitySet<OUT_CheckSmartCard> OUT_CheckSmartCards
		{
			get
			{
				return this._OUT_CheckSmartCards;
			}
			set
			{
				this._OUT_CheckSmartCards.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_OUT_CheckSmartCards(OUT_CheckSmartCard entity)
		{
			this.SendPropertyChanging();
			entity.LS_Lane = this;
		}
		
		private void detach_OUT_CheckSmartCards(OUT_CheckSmartCard entity)
		{
			this.SendPropertyChanging();
			entity.LS_Lane = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.OUT_CheckSmartCard")]
	public partial class OUT_CheckSmartCard : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _OutCheckSmartCardID;
		
		private string _TransactionID;
		
		private string _ReceiptNo;
		
		private string _SmartCardID;
		
		private System.Nullable<System.Guid> _InCheckSmartCardID;
		
		private System.Nullable<System.Guid> _InCheckSmartCardIDManual;
		
		private System.DateTime _CheckDate;
		
		private System.Nullable<int> _BeginBalance;
		
		private System.Nullable<int> _ChargeAmount;
		
		private System.Nullable<int> _Balance;
		
		private System.Nullable<int> _TicketTypeID;
		
		private System.Nullable<int> _VehicleTypeID;
		
		private System.Nullable<int> _RouteID;
		
		private System.Nullable<int> _EmployeeID;
		
		private System.Nullable<int> _ShiftID;
		
		private System.Nullable<int> _LaneID;
		
		private System.Nullable<int> _StationID;
		
		private string _ImageID;
		
		private string _RecogPlateNumber;
		
		private System.Nullable<short> _RecogResultType;
		
		private System.Nullable<short> _TransactionStatus;
		
		private System.Nullable<short> _PrecheckStatus;
		
		private System.Nullable<short> _PreSupervisionStatus;
		
		private System.Nullable<short> _SupervisionStatus;
		
		private System.Nullable<int> _ErrorID;
		
		private string _Note;
		
		private string _EntryPlateNumber;
		
		private System.Nullable<int> _EntryLaneID;
		
		private string _F1;
		
		private string _F2;
		
		private EntityRef<LS_Lane> _LS_Lane;
		
		private EntityRef<LS_Route> _LS_Route;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnOutCheckSmartCardIDChanging(System.Guid value);
    partial void OnOutCheckSmartCardIDChanged();
    partial void OnTransactionIDChanging(string value);
    partial void OnTransactionIDChanged();
    partial void OnReceiptNoChanging(string value);
    partial void OnReceiptNoChanged();
    partial void OnSmartCardIDChanging(string value);
    partial void OnSmartCardIDChanged();
    partial void OnInCheckSmartCardIDChanging(System.Nullable<System.Guid> value);
    partial void OnInCheckSmartCardIDChanged();
    partial void OnInCheckSmartCardIDManualChanging(System.Nullable<System.Guid> value);
    partial void OnInCheckSmartCardIDManualChanged();
    partial void OnCheckDateChanging(System.DateTime value);
    partial void OnCheckDateChanged();
    partial void OnBeginBalanceChanging(System.Nullable<int> value);
    partial void OnBeginBalanceChanged();
    partial void OnChargeAmountChanging(System.Nullable<int> value);
    partial void OnChargeAmountChanged();
    partial void OnBalanceChanging(System.Nullable<int> value);
    partial void OnBalanceChanged();
    partial void OnTicketTypeIDChanging(System.Nullable<int> value);
    partial void OnTicketTypeIDChanged();
    partial void OnVehicleTypeIDChanging(System.Nullable<int> value);
    partial void OnVehicleTypeIDChanged();
    partial void OnRouteIDChanging(System.Nullable<int> value);
    partial void OnRouteIDChanged();
    partial void OnEmployeeIDChanging(System.Nullable<int> value);
    partial void OnEmployeeIDChanged();
    partial void OnShiftIDChanging(System.Nullable<int> value);
    partial void OnShiftIDChanged();
    partial void OnLaneIDChanging(System.Nullable<int> value);
    partial void OnLaneIDChanged();
    partial void OnStationIDChanging(System.Nullable<int> value);
    partial void OnStationIDChanged();
    partial void OnImageIDChanging(string value);
    partial void OnImageIDChanged();
    partial void OnRecogPlateNumberChanging(string value);
    partial void OnRecogPlateNumberChanged();
    partial void OnRecogResultTypeChanging(System.Nullable<short> value);
    partial void OnRecogResultTypeChanged();
    partial void OnTransactionStatusChanging(System.Nullable<short> value);
    partial void OnTransactionStatusChanged();
    partial void OnPrecheckStatusChanging(System.Nullable<short> value);
    partial void OnPrecheckStatusChanged();
    partial void OnPreSupervisionStatusChanging(System.Nullable<short> value);
    partial void OnPreSupervisionStatusChanged();
    partial void OnSupervisionStatusChanging(System.Nullable<short> value);
    partial void OnSupervisionStatusChanged();
    partial void OnErrorIDChanging(System.Nullable<int> value);
    partial void OnErrorIDChanged();
    partial void OnNoteChanging(string value);
    partial void OnNoteChanged();
    partial void OnEntryPlateNumberChanging(string value);
    partial void OnEntryPlateNumberChanged();
    partial void OnEntryLaneIDChanging(System.Nullable<int> value);
    partial void OnEntryLaneIDChanged();
    partial void OnF1Changing(string value);
    partial void OnF1Changed();
    partial void OnF2Changing(string value);
    partial void OnF2Changed();
    #endregion
		
		public OUT_CheckSmartCard()
		{
			this._LS_Lane = default(EntityRef<LS_Lane>);
			this._LS_Route = default(EntityRef<LS_Route>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OutCheckSmartCardID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid OutCheckSmartCardID
		{
			get
			{
				return this._OutCheckSmartCardID;
			}
			set
			{
				if ((this._OutCheckSmartCardID != value))
				{
					this.OnOutCheckSmartCardIDChanging(value);
					this.SendPropertyChanging();
					this._OutCheckSmartCardID = value;
					this.SendPropertyChanged("OutCheckSmartCardID");
					this.OnOutCheckSmartCardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionID", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
		public string TransactionID
		{
			get
			{
				return this._TransactionID;
			}
			set
			{
				if ((this._TransactionID != value))
				{
					this.OnTransactionIDChanging(value);
					this.SendPropertyChanging();
					this._TransactionID = value;
					this.SendPropertyChanged("TransactionID");
					this.OnTransactionIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ReceiptNo", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string ReceiptNo
		{
			get
			{
				return this._ReceiptNo;
			}
			set
			{
				if ((this._ReceiptNo != value))
				{
					this.OnReceiptNoChanging(value);
					this.SendPropertyChanging();
					this._ReceiptNo = value;
					this.SendPropertyChanged("ReceiptNo");
					this.OnReceiptNoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SmartCardID", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string SmartCardID
		{
			get
			{
				return this._SmartCardID;
			}
			set
			{
				if ((this._SmartCardID != value))
				{
					this.OnSmartCardIDChanging(value);
					this.SendPropertyChanging();
					this._SmartCardID = value;
					this.SendPropertyChanged("SmartCardID");
					this.OnSmartCardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InCheckSmartCardID", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> InCheckSmartCardID
		{
			get
			{
				return this._InCheckSmartCardID;
			}
			set
			{
				if ((this._InCheckSmartCardID != value))
				{
					this.OnInCheckSmartCardIDChanging(value);
					this.SendPropertyChanging();
					this._InCheckSmartCardID = value;
					this.SendPropertyChanged("InCheckSmartCardID");
					this.OnInCheckSmartCardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InCheckSmartCardIDManual", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> InCheckSmartCardIDManual
		{
			get
			{
				return this._InCheckSmartCardIDManual;
			}
			set
			{
				if ((this._InCheckSmartCardIDManual != value))
				{
					this.OnInCheckSmartCardIDManualChanging(value);
					this.SendPropertyChanging();
					this._InCheckSmartCardIDManual = value;
					this.SendPropertyChanged("InCheckSmartCardIDManual");
					this.OnInCheckSmartCardIDManualChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CheckDate", DbType="DateTime NOT NULL")]
		public System.DateTime CheckDate
		{
			get
			{
				return this._CheckDate;
			}
			set
			{
				if ((this._CheckDate != value))
				{
					this.OnCheckDateChanging(value);
					this.SendPropertyChanging();
					this._CheckDate = value;
					this.SendPropertyChanged("CheckDate");
					this.OnCheckDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BeginBalance", DbType="Int")]
		public System.Nullable<int> BeginBalance
		{
			get
			{
				return this._BeginBalance;
			}
			set
			{
				if ((this._BeginBalance != value))
				{
					this.OnBeginBalanceChanging(value);
					this.SendPropertyChanging();
					this._BeginBalance = value;
					this.SendPropertyChanged("BeginBalance");
					this.OnBeginBalanceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChargeAmount", DbType="Int")]
		public System.Nullable<int> ChargeAmount
		{
			get
			{
				return this._ChargeAmount;
			}
			set
			{
				if ((this._ChargeAmount != value))
				{
					this.OnChargeAmountChanging(value);
					this.SendPropertyChanging();
					this._ChargeAmount = value;
					this.SendPropertyChanged("ChargeAmount");
					this.OnChargeAmountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Balance", DbType="Int")]
		public System.Nullable<int> Balance
		{
			get
			{
				return this._Balance;
			}
			set
			{
				if ((this._Balance != value))
				{
					this.OnBalanceChanging(value);
					this.SendPropertyChanging();
					this._Balance = value;
					this.SendPropertyChanged("Balance");
					this.OnBalanceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TicketTypeID", DbType="Int")]
		public System.Nullable<int> TicketTypeID
		{
			get
			{
				return this._TicketTypeID;
			}
			set
			{
				if ((this._TicketTypeID != value))
				{
					this.OnTicketTypeIDChanging(value);
					this.SendPropertyChanging();
					this._TicketTypeID = value;
					this.SendPropertyChanged("TicketTypeID");
					this.OnTicketTypeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_VehicleTypeID", DbType="Int")]
		public System.Nullable<int> VehicleTypeID
		{
			get
			{
				return this._VehicleTypeID;
			}
			set
			{
				if ((this._VehicleTypeID != value))
				{
					this.OnVehicleTypeIDChanging(value);
					this.SendPropertyChanging();
					this._VehicleTypeID = value;
					this.SendPropertyChanged("VehicleTypeID");
					this.OnVehicleTypeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RouteID", DbType="Int")]
		public System.Nullable<int> RouteID
		{
			get
			{
				return this._RouteID;
			}
			set
			{
				if ((this._RouteID != value))
				{
					if (this._LS_Route.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnRouteIDChanging(value);
					this.SendPropertyChanging();
					this._RouteID = value;
					this.SendPropertyChanged("RouteID");
					this.OnRouteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmployeeID", DbType="Int")]
		public System.Nullable<int> EmployeeID
		{
			get
			{
				return this._EmployeeID;
			}
			set
			{
				if ((this._EmployeeID != value))
				{
					this.OnEmployeeIDChanging(value);
					this.SendPropertyChanging();
					this._EmployeeID = value;
					this.SendPropertyChanged("EmployeeID");
					this.OnEmployeeIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShiftID", DbType="Int")]
		public System.Nullable<int> ShiftID
		{
			get
			{
				return this._ShiftID;
			}
			set
			{
				if ((this._ShiftID != value))
				{
					this.OnShiftIDChanging(value);
					this.SendPropertyChanging();
					this._ShiftID = value;
					this.SendPropertyChanged("ShiftID");
					this.OnShiftIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LaneID", DbType="Int")]
		public System.Nullable<int> LaneID
		{
			get
			{
				return this._LaneID;
			}
			set
			{
				if ((this._LaneID != value))
				{
					if (this._LS_Lane.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnLaneIDChanging(value);
					this.SendPropertyChanging();
					this._LaneID = value;
					this.SendPropertyChanged("LaneID");
					this.OnLaneIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StationID", DbType="Int")]
		public System.Nullable<int> StationID
		{
			get
			{
				return this._StationID;
			}
			set
			{
				if ((this._StationID != value))
				{
					this.OnStationIDChanging(value);
					this.SendPropertyChanging();
					this._StationID = value;
					this.SendPropertyChanged("StationID");
					this.OnStationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageID", DbType="NVarChar(50)")]
		public string ImageID
		{
			get
			{
				return this._ImageID;
			}
			set
			{
				if ((this._ImageID != value))
				{
					this.OnImageIDChanging(value);
					this.SendPropertyChanging();
					this._ImageID = value;
					this.SendPropertyChanged("ImageID");
					this.OnImageIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecogPlateNumber", DbType="NVarChar(15)")]
		public string RecogPlateNumber
		{
			get
			{
				return this._RecogPlateNumber;
			}
			set
			{
				if ((this._RecogPlateNumber != value))
				{
					this.OnRecogPlateNumberChanging(value);
					this.SendPropertyChanging();
					this._RecogPlateNumber = value;
					this.SendPropertyChanged("RecogPlateNumber");
					this.OnRecogPlateNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RecogResultType", DbType="SmallInt")]
		public System.Nullable<short> RecogResultType
		{
			get
			{
				return this._RecogResultType;
			}
			set
			{
				if ((this._RecogResultType != value))
				{
					this.OnRecogResultTypeChanging(value);
					this.SendPropertyChanging();
					this._RecogResultType = value;
					this.SendPropertyChanged("RecogResultType");
					this.OnRecogResultTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TransactionStatus", DbType="SmallInt")]
		public System.Nullable<short> TransactionStatus
		{
			get
			{
				return this._TransactionStatus;
			}
			set
			{
				if ((this._TransactionStatus != value))
				{
					this.OnTransactionStatusChanging(value);
					this.SendPropertyChanging();
					this._TransactionStatus = value;
					this.SendPropertyChanged("TransactionStatus");
					this.OnTransactionStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PrecheckStatus", DbType="SmallInt")]
		public System.Nullable<short> PrecheckStatus
		{
			get
			{
				return this._PrecheckStatus;
			}
			set
			{
				if ((this._PrecheckStatus != value))
				{
					this.OnPrecheckStatusChanging(value);
					this.SendPropertyChanging();
					this._PrecheckStatus = value;
					this.SendPropertyChanged("PrecheckStatus");
					this.OnPrecheckStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PreSupervisionStatus", DbType="SmallInt")]
		public System.Nullable<short> PreSupervisionStatus
		{
			get
			{
				return this._PreSupervisionStatus;
			}
			set
			{
				if ((this._PreSupervisionStatus != value))
				{
					this.OnPreSupervisionStatusChanging(value);
					this.SendPropertyChanging();
					this._PreSupervisionStatus = value;
					this.SendPropertyChanged("PreSupervisionStatus");
					this.OnPreSupervisionStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SupervisionStatus", DbType="SmallInt")]
		public System.Nullable<short> SupervisionStatus
		{
			get
			{
				return this._SupervisionStatus;
			}
			set
			{
				if ((this._SupervisionStatus != value))
				{
					this.OnSupervisionStatusChanging(value);
					this.SendPropertyChanging();
					this._SupervisionStatus = value;
					this.SendPropertyChanged("SupervisionStatus");
					this.OnSupervisionStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ErrorID", DbType="Int")]
		public System.Nullable<int> ErrorID
		{
			get
			{
				return this._ErrorID;
			}
			set
			{
				if ((this._ErrorID != value))
				{
					this.OnErrorIDChanging(value);
					this.SendPropertyChanging();
					this._ErrorID = value;
					this.SendPropertyChanged("ErrorID");
					this.OnErrorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Note", DbType="NVarChar(100)")]
		public string Note
		{
			get
			{
				return this._Note;
			}
			set
			{
				if ((this._Note != value))
				{
					this.OnNoteChanging(value);
					this.SendPropertyChanging();
					this._Note = value;
					this.SendPropertyChanged("Note");
					this.OnNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryPlateNumber", DbType="NVarChar(15)")]
		public string EntryPlateNumber
		{
			get
			{
				return this._EntryPlateNumber;
			}
			set
			{
				if ((this._EntryPlateNumber != value))
				{
					this.OnEntryPlateNumberChanging(value);
					this.SendPropertyChanging();
					this._EntryPlateNumber = value;
					this.SendPropertyChanged("EntryPlateNumber");
					this.OnEntryPlateNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EntryLaneID", DbType="Int")]
		public System.Nullable<int> EntryLaneID
		{
			get
			{
				return this._EntryLaneID;
			}
			set
			{
				if ((this._EntryLaneID != value))
				{
					this.OnEntryLaneIDChanging(value);
					this.SendPropertyChanging();
					this._EntryLaneID = value;
					this.SendPropertyChanged("EntryLaneID");
					this.OnEntryLaneIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_F1", DbType="NVarChar(50)")]
		public string F1
		{
			get
			{
				return this._F1;
			}
			set
			{
				if ((this._F1 != value))
				{
					this.OnF1Changing(value);
					this.SendPropertyChanging();
					this._F1 = value;
					this.SendPropertyChanged("F1");
					this.OnF1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_F2", DbType="NVarChar(50)")]
		public string F2
		{
			get
			{
				return this._F2;
			}
			set
			{
				if ((this._F2 != value))
				{
					this.OnF2Changing(value);
					this.SendPropertyChanging();
					this._F2 = value;
					this.SendPropertyChanged("F2");
					this.OnF2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LS_Lane_OUT_CheckSmartCard", Storage="_LS_Lane", ThisKey="LaneID", OtherKey="LaneID", IsForeignKey=true)]
		public LS_Lane LS_Lane
		{
			get
			{
				return this._LS_Lane.Entity;
			}
			set
			{
				LS_Lane previousValue = this._LS_Lane.Entity;
				if (((previousValue != value) 
							|| (this._LS_Lane.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LS_Lane.Entity = null;
						previousValue.OUT_CheckSmartCards.Remove(this);
					}
					this._LS_Lane.Entity = value;
					if ((value != null))
					{
						value.OUT_CheckSmartCards.Add(this);
						this._LaneID = value.LaneID;
					}
					else
					{
						this._LaneID = default(Nullable<int>);
					}
					this.SendPropertyChanged("LS_Lane");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LS_Route_OUT_CheckSmartCard", Storage="_LS_Route", ThisKey="RouteID", OtherKey="RouteID", IsForeignKey=true)]
		public LS_Route LS_Route
		{
			get
			{
				return this._LS_Route.Entity;
			}
			set
			{
				LS_Route previousValue = this._LS_Route.Entity;
				if (((previousValue != value) 
							|| (this._LS_Route.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LS_Route.Entity = null;
						previousValue.OUT_CheckSmartCards.Remove(this);
					}
					this._LS_Route.Entity = value;
					if ((value != null))
					{
						value.OUT_CheckSmartCards.Add(this);
						this._RouteID = value.RouteID;
					}
					else
					{
						this._RouteID = default(Nullable<int>);
					}
					this.SendPropertyChanged("LS_Route");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
