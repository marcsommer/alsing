using System;
using System.Data;
using System.Reflection;

namespace MyMeta.VistaDB
{

	using System.Runtime.InteropServices;
	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual), ComDefaultInterface(typeof(IIndexes))]

	public class VistaDBIndexes : Indexes
	{
		public VistaDBIndexes()
		{

		}

		override internal void LoadAll()
		{
			try
			{
				VistaDBDatabase db = (VistaDBDatabase)this.Table.Database;

				DataTable metaData = db._mh.LoadIndexes(this.dbRoot.ConnectionString, this.Table.Database.Name, this.Table.Name);

				PopulateArray(metaData);
			}
			catch {}
		}
	}
}
