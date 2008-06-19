using System;
using System.Data;
using System.Data.OleDb;

namespace MyMeta.ISeries
{

	using System.Runtime.InteropServices;
	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(typeof(ITables))]

	public class ISeriesTables : Tables
	{
		public ISeriesTables()
		{

		}

		override internal void LoadAll()
		{
			try
			{
				string type = this.dbRoot.ShowSystemData ? "SYSTEM TABLE" : "TABLE";
				DataTable metaData = this.LoadData(OleDbSchemaGuid.Tables, new Object[] {null, null, null, type});

				PopulateArray(metaData);
			}
			catch {}
		}
	}
}
