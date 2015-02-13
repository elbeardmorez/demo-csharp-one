//
//  ____  _     __  __      _        _
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from test on 2015-02-12 20:33:53Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;


public partial class Test : DataContext
{
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
	
	
	public Test(string connectionString) :
			base(connectionString)
	{
		this.OnCreated();
	}
	
	public Test(IDbConnection connection) :
			base(connection)
	{
		this.OnCreated();
	}
	
	public Test(string connection, MappingSource mappingSource) :
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Test(IDbConnection connection, MappingSource mappingSource) :
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Table<TiesTo> TiesTo
	{
		get
		{
			return this.GetTable <TiesTo>();
		}
	}
}

[Table(Name="public.tiesto")]
public partial class TiesTo
{
	
	private System.Nullable<int> _id;
	
	private string _name;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnIDChanged();
		
		partial void OnIDChanging(System.Nullable<int> value);
		
		partial void OnNameChanged();
		
		partial void OnNameChanging(string value);
		#endregion
	
	
	public TiesTo()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_id", Name="id", DbType="integer(32,0)", AutoSync=AutoSync.Never)]
	[DebuggerNonUserCode()]
	public System.Nullable<int> ID
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((_id != value))
			{
				this.OnIDChanging(value);
				this._id = value;
				this.OnIDChanged();
			}
		}
	}
	
	[Column(Storage="_name", Name="name", DbType="text", AutoSync=AutoSync.Never)]
	[DebuggerNonUserCode()]
	public string Name
	{
		get
		{
			return this._name;
		}
		set
		{
			if (((_name == value) == false))
			{
				this.OnNameChanging(value);
				this._name = value;
				this.OnNameChanged();
			}
		}
	}
}
