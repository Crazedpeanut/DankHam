using System;
using Mono.Data.Sqlite;
using System.Data;
using System.Collections;
using System.Threading;

public class DataAdapter {

	IDbConnection dbConn;
	IDbCommand command;
	IDataReader readr;

	string query;

	public bool isDone = false;
	public ArrayList results;

	public DataAdapter(string filePath)
	{
		dbConn = new SqliteConnection (filePath);
		results = new ArrayList ();
	}

	public void setQuery(string query)
	{
		this.query = query;
	}

	public void executeQuery()
	{
		dbConn.Open ();

		command = dbConn.CreateCommand ();
		command.CommandText = query;
		readr = command.ExecuteReader ();

		while (readr.Read ()) 
		{
			results.Add(readr.GetString(1));
		}

		isDone = true;

		while (true) 
		{
			Thread.Sleep(100);
		}
	}
}
