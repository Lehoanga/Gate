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

namespace Gate.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QLPTX")]
	public partial class QLTTXDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTAXITICKET(TAXITICKET instance);
    partial void UpdateTAXITICKET(TAXITICKET instance);
    partial void DeleteTAXITICKET(TAXITICKET instance);
    partial void InsertTAXICARD(TAXICARD instance);
    partial void UpdateTAXICARD(TAXICARD instance);
    partial void DeleteTAXICARD(TAXICARD instance);
    partial void InsertROOM(ROOM instance);
    partial void UpdateROOM(ROOM instance);
    partial void DeleteROOM(ROOM instance);
    partial void InsertROOMTICKET(ROOMTICKET instance);
    partial void UpdateROOMTICKET(ROOMTICKET instance);
    partial void DeleteROOMTICKET(ROOMTICKET instance);
    #endregion
		
		public QLTTXDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["QLPTXConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public QLTTXDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLTTXDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLTTXDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLTTXDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TAXITICKET> TAXITICKETs
		{
			get
			{
				return this.GetTable<TAXITICKET>();
			}
		}
		
		public System.Data.Linq.Table<TAXICARD> TAXICARDs
		{
			get
			{
				return this.GetTable<TAXICARD>();
			}
		}
		
		public System.Data.Linq.Table<ROOM> ROOMs
		{
			get
			{
				return this.GetTable<ROOM>();
			}
		}
		
		public System.Data.Linq.Table<ROOMTICKET> ROOMTICKETs
		{
			get
			{
				return this.GetTable<ROOMTICKET>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TAXITICKET")]
	public partial class TAXITICKET : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<int> _ticketID;
		
		private System.Nullable<System.DateTime> _startDate;
		
		private System.Nullable<System.DateTime> _endDate;
		
		private string _userName;
		
		private string _loggerName;
		
		private System.Nullable<System.DateTime> _takecardDate;
		
		private System.Nullable<System.DateTime> _returncardDate;
		
		private string _borrowerName;
		
		private System.Nullable<bool> _borrowStatus;
		
		private System.Nullable<bool> _returnStatus;
		
		private System.Nullable<int> _cardNum;
		
		private string _Price;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnticketIDChanging(System.Nullable<int> value);
    partial void OnticketIDChanged();
    partial void OnstartDateChanging(System.Nullable<System.DateTime> value);
    partial void OnstartDateChanged();
    partial void OnendDateChanging(System.Nullable<System.DateTime> value);
    partial void OnendDateChanged();
    partial void OnuserNameChanging(string value);
    partial void OnuserNameChanged();
    partial void OnloggerNameChanging(string value);
    partial void OnloggerNameChanged();
    partial void OntakecardDateChanging(System.Nullable<System.DateTime> value);
    partial void OntakecardDateChanged();
    partial void OnreturncardDateChanging(System.Nullable<System.DateTime> value);
    partial void OnreturncardDateChanged();
    partial void OnborrowerNameChanging(string value);
    partial void OnborrowerNameChanged();
    partial void OnborrowStatusChanging(System.Nullable<bool> value);
    partial void OnborrowStatusChanged();
    partial void OnreturnStatusChanging(System.Nullable<bool> value);
    partial void OnreturnStatusChanged();
    partial void OncardNumChanging(System.Nullable<int> value);
    partial void OncardNumChanged();
    partial void OnPriceChanging(string value);
    partial void OnPriceChanged();
    #endregion
		
		public TAXITICKET()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ticketID", DbType="Int")]
		public System.Nullable<int> ticketID
		{
			get
			{
				return this._ticketID;
			}
			set
			{
				if ((this._ticketID != value))
				{
					this.OnticketIDChanging(value);
					this.SendPropertyChanging();
					this._ticketID = value;
					this.SendPropertyChanged("ticketID");
					this.OnticketIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_startDate", DbType="Date")]
		public System.Nullable<System.DateTime> startDate
		{
			get
			{
				return this._startDate;
			}
			set
			{
				if ((this._startDate != value))
				{
					this.OnstartDateChanging(value);
					this.SendPropertyChanging();
					this._startDate = value;
					this.SendPropertyChanged("startDate");
					this.OnstartDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_endDate", DbType="Date")]
		public System.Nullable<System.DateTime> endDate
		{
			get
			{
				return this._endDate;
			}
			set
			{
				if ((this._endDate != value))
				{
					this.OnendDateChanging(value);
					this.SendPropertyChanging();
					this._endDate = value;
					this.SendPropertyChanged("endDate");
					this.OnendDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userName", DbType="NVarChar(50)")]
		public string userName
		{
			get
			{
				return this._userName;
			}
			set
			{
				if ((this._userName != value))
				{
					this.OnuserNameChanging(value);
					this.SendPropertyChanging();
					this._userName = value;
					this.SendPropertyChanged("userName");
					this.OnuserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_loggerName", DbType="NVarChar(50)")]
		public string loggerName
		{
			get
			{
				return this._loggerName;
			}
			set
			{
				if ((this._loggerName != value))
				{
					this.OnloggerNameChanging(value);
					this.SendPropertyChanging();
					this._loggerName = value;
					this.SendPropertyChanged("loggerName");
					this.OnloggerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_takecardDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> takecardDate
		{
			get
			{
				return this._takecardDate;
			}
			set
			{
				if ((this._takecardDate != value))
				{
					this.OntakecardDateChanging(value);
					this.SendPropertyChanging();
					this._takecardDate = value;
					this.SendPropertyChanged("takecardDate");
					this.OntakecardDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_returncardDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> returncardDate
		{
			get
			{
				return this._returncardDate;
			}
			set
			{
				if ((this._returncardDate != value))
				{
					this.OnreturncardDateChanging(value);
					this.SendPropertyChanging();
					this._returncardDate = value;
					this.SendPropertyChanged("returncardDate");
					this.OnreturncardDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_borrowerName", DbType="NVarChar(50)")]
		public string borrowerName
		{
			get
			{
				return this._borrowerName;
			}
			set
			{
				if ((this._borrowerName != value))
				{
					this.OnborrowerNameChanging(value);
					this.SendPropertyChanging();
					this._borrowerName = value;
					this.SendPropertyChanged("borrowerName");
					this.OnborrowerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_borrowStatus", DbType="Bit")]
		public System.Nullable<bool> borrowStatus
		{
			get
			{
				return this._borrowStatus;
			}
			set
			{
				if ((this._borrowStatus != value))
				{
					this.OnborrowStatusChanging(value);
					this.SendPropertyChanging();
					this._borrowStatus = value;
					this.SendPropertyChanged("borrowStatus");
					this.OnborrowStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_returnStatus", DbType="Bit")]
		public System.Nullable<bool> returnStatus
		{
			get
			{
				return this._returnStatus;
			}
			set
			{
				if ((this._returnStatus != value))
				{
					this.OnreturnStatusChanging(value);
					this.SendPropertyChanging();
					this._returnStatus = value;
					this.SendPropertyChanged("returnStatus");
					this.OnreturnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cardNum", DbType="Int")]
		public System.Nullable<int> cardNum
		{
			get
			{
				return this._cardNum;
			}
			set
			{
				if ((this._cardNum != value))
				{
					this.OncardNumChanging(value);
					this.SendPropertyChanging();
					this._cardNum = value;
					this.SendPropertyChanged("cardNum");
					this.OncardNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="VarChar(50)")]
		public string Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TAXICARD")]
	public partial class TAXICARD : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _cardID;
		
		private System.Nullable<int> _cardNum;
		
		private string _taxiCom;
		
		private string _department;
		
		private System.Nullable<bool> _isReady;
		
		private string _ownerName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OncardIDChanging(int value);
    partial void OncardIDChanged();
    partial void OncardNumChanging(System.Nullable<int> value);
    partial void OncardNumChanged();
    partial void OntaxiComChanging(string value);
    partial void OntaxiComChanged();
    partial void OndepartmentChanging(string value);
    partial void OndepartmentChanged();
    partial void OnisReadyChanging(System.Nullable<bool> value);
    partial void OnisReadyChanged();
    partial void OnownerNameChanging(string value);
    partial void OnownerNameChanged();
    #endregion
		
		public TAXICARD()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cardID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int cardID
		{
			get
			{
				return this._cardID;
			}
			set
			{
				if ((this._cardID != value))
				{
					this.OncardIDChanging(value);
					this.SendPropertyChanging();
					this._cardID = value;
					this.SendPropertyChanged("cardID");
					this.OncardIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cardNum", DbType="Int")]
		public System.Nullable<int> cardNum
		{
			get
			{
				return this._cardNum;
			}
			set
			{
				if ((this._cardNum != value))
				{
					this.OncardNumChanging(value);
					this.SendPropertyChanging();
					this._cardNum = value;
					this.SendPropertyChanged("cardNum");
					this.OncardNumChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_taxiCom", DbType="NVarChar(50)")]
		public string taxiCom
		{
			get
			{
				return this._taxiCom;
			}
			set
			{
				if ((this._taxiCom != value))
				{
					this.OntaxiComChanging(value);
					this.SendPropertyChanging();
					this._taxiCom = value;
					this.SendPropertyChanged("taxiCom");
					this.OntaxiComChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_department", DbType="NVarChar(100)")]
		public string department
		{
			get
			{
				return this._department;
			}
			set
			{
				if ((this._department != value))
				{
					this.OndepartmentChanging(value);
					this.SendPropertyChanging();
					this._department = value;
					this.SendPropertyChanged("department");
					this.OndepartmentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isReady", DbType="Bit")]
		public System.Nullable<bool> isReady
		{
			get
			{
				return this._isReady;
			}
			set
			{
				if ((this._isReady != value))
				{
					this.OnisReadyChanging(value);
					this.SendPropertyChanging();
					this._isReady = value;
					this.SendPropertyChanged("isReady");
					this.OnisReadyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ownerName", DbType="NVarChar(50)")]
		public string ownerName
		{
			get
			{
				return this._ownerName;
			}
			set
			{
				if ((this._ownerName != value))
				{
					this.OnownerNameChanging(value);
					this.SendPropertyChanging();
					this._ownerName = value;
					this.SendPropertyChanged("ownerName");
					this.OnownerNameChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ROOM")]
	public partial class ROOM : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _roomID;
		
		private string _inforRom;
		
		private System.Nullable<bool> _isReady;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnroomIDChanging(string value);
    partial void OnroomIDChanged();
    partial void OninforRomChanging(string value);
    partial void OninforRomChanged();
    partial void OnisReadyChanging(System.Nullable<bool> value);
    partial void OnisReadyChanged();
    #endregion
		
		public ROOM()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_roomID", DbType="NChar(20)")]
		public string roomID
		{
			get
			{
				return this._roomID;
			}
			set
			{
				if ((this._roomID != value))
				{
					this.OnroomIDChanging(value);
					this.SendPropertyChanging();
					this._roomID = value;
					this.SendPropertyChanged("roomID");
					this.OnroomIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_inforRom", DbType="NVarChar(100)")]
		public string inforRom
		{
			get
			{
				return this._inforRom;
			}
			set
			{
				if ((this._inforRom != value))
				{
					this.OninforRomChanging(value);
					this.SendPropertyChanging();
					this._inforRom = value;
					this.SendPropertyChanged("inforRom");
					this.OninforRomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isReady", DbType="Bit")]
		public System.Nullable<bool> isReady
		{
			get
			{
				return this._isReady;
			}
			set
			{
				if ((this._isReady != value))
				{
					this.OnisReadyChanging(value);
					this.SendPropertyChanging();
					this._isReady = value;
					this.SendPropertyChanged("isReady");
					this.OnisReadyChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ROOMTICKET")]
	public partial class ROOMTICKET : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private System.Nullable<int> _ticketID;
		
		private string _bookingName;
		
		private string _borrowerName;
		
		private System.Nullable<System.DateTime> _datetimeStart;
		
		private System.Nullable<System.DateTime> _datetimeEnd;
		
		private System.Nullable<System.DateTime> _datetimeCheckin;
		
		private System.Nullable<System.DateTime> _datetimeCheckout;
		
		private System.Nullable<bool> _borrowStatus;
		
		private System.Nullable<bool> _returnStatus;
		
		private string _roomID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnticketIDChanging(System.Nullable<int> value);
    partial void OnticketIDChanged();
    partial void OnbookingNameChanging(string value);
    partial void OnbookingNameChanged();
    partial void OnborrowerNameChanging(string value);
    partial void OnborrowerNameChanged();
    partial void OndatetimeStartChanging(System.Nullable<System.DateTime> value);
    partial void OndatetimeStartChanged();
    partial void OndatetimeEndChanging(System.Nullable<System.DateTime> value);
    partial void OndatetimeEndChanged();
    partial void OndatetimeCheckinChanging(System.Nullable<System.DateTime> value);
    partial void OndatetimeCheckinChanged();
    partial void OndatetimeCheckoutChanging(System.Nullable<System.DateTime> value);
    partial void OndatetimeCheckoutChanged();
    partial void OnborrowStatusChanging(System.Nullable<bool> value);
    partial void OnborrowStatusChanged();
    partial void OnreturnStatusChanging(System.Nullable<bool> value);
    partial void OnreturnStatusChanged();
    partial void OnroomIDChanging(string value);
    partial void OnroomIDChanged();
    #endregion
		
		public ROOMTICKET()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ticketID", DbType="Int")]
		public System.Nullable<int> ticketID
		{
			get
			{
				return this._ticketID;
			}
			set
			{
				if ((this._ticketID != value))
				{
					this.OnticketIDChanging(value);
					this.SendPropertyChanging();
					this._ticketID = value;
					this.SendPropertyChanged("ticketID");
					this.OnticketIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_bookingName", DbType="NChar(10)")]
		public string bookingName
		{
			get
			{
				return this._bookingName;
			}
			set
			{
				if ((this._bookingName != value))
				{
					this.OnbookingNameChanging(value);
					this.SendPropertyChanging();
					this._bookingName = value;
					this.SendPropertyChanged("bookingName");
					this.OnbookingNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_borrowerName", DbType="NChar(10)")]
		public string borrowerName
		{
			get
			{
				return this._borrowerName;
			}
			set
			{
				if ((this._borrowerName != value))
				{
					this.OnborrowerNameChanging(value);
					this.SendPropertyChanging();
					this._borrowerName = value;
					this.SendPropertyChanged("borrowerName");
					this.OnborrowerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datetimeStart", DbType="DateTime")]
		public System.Nullable<System.DateTime> datetimeStart
		{
			get
			{
				return this._datetimeStart;
			}
			set
			{
				if ((this._datetimeStart != value))
				{
					this.OndatetimeStartChanging(value);
					this.SendPropertyChanging();
					this._datetimeStart = value;
					this.SendPropertyChanged("datetimeStart");
					this.OndatetimeStartChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datetimeEnd", DbType="DateTime")]
		public System.Nullable<System.DateTime> datetimeEnd
		{
			get
			{
				return this._datetimeEnd;
			}
			set
			{
				if ((this._datetimeEnd != value))
				{
					this.OndatetimeEndChanging(value);
					this.SendPropertyChanging();
					this._datetimeEnd = value;
					this.SendPropertyChanged("datetimeEnd");
					this.OndatetimeEndChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datetimeCheckin", DbType="DateTime")]
		public System.Nullable<System.DateTime> datetimeCheckin
		{
			get
			{
				return this._datetimeCheckin;
			}
			set
			{
				if ((this._datetimeCheckin != value))
				{
					this.OndatetimeCheckinChanging(value);
					this.SendPropertyChanging();
					this._datetimeCheckin = value;
					this.SendPropertyChanged("datetimeCheckin");
					this.OndatetimeCheckinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_datetimeCheckout", DbType="DateTime")]
		public System.Nullable<System.DateTime> datetimeCheckout
		{
			get
			{
				return this._datetimeCheckout;
			}
			set
			{
				if ((this._datetimeCheckout != value))
				{
					this.OndatetimeCheckoutChanging(value);
					this.SendPropertyChanging();
					this._datetimeCheckout = value;
					this.SendPropertyChanged("datetimeCheckout");
					this.OndatetimeCheckoutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_borrowStatus", DbType="Bit")]
		public System.Nullable<bool> borrowStatus
		{
			get
			{
				return this._borrowStatus;
			}
			set
			{
				if ((this._borrowStatus != value))
				{
					this.OnborrowStatusChanging(value);
					this.SendPropertyChanging();
					this._borrowStatus = value;
					this.SendPropertyChanged("borrowStatus");
					this.OnborrowStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_returnStatus", DbType="Bit")]
		public System.Nullable<bool> returnStatus
		{
			get
			{
				return this._returnStatus;
			}
			set
			{
				if ((this._returnStatus != value))
				{
					this.OnreturnStatusChanging(value);
					this.SendPropertyChanging();
					this._returnStatus = value;
					this.SendPropertyChanged("returnStatus");
					this.OnreturnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_roomID", DbType="NChar(20)")]
		public string roomID
		{
			get
			{
				return this._roomID;
			}
			set
			{
				if ((this._roomID != value))
				{
					this.OnroomIDChanging(value);
					this.SendPropertyChanging();
					this._roomID = value;
					this.SendPropertyChanged("roomID");
					this.OnroomIDChanged();
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
