using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntermediateExercises
{
  public class Section5
  {
    // Exercise 1: Design a database connection
    /*
    To access a database, we need to open a connection to it first and close it once our job is done.
    Connecting to a database depends on the type of the target database and the database
    management system (DBMS). For example, connecting to a SQL Server database is different
    from connecting to an Oracle database. But both these connections have a few things in
    common:
    • They have a connection string
    • They can be opened
    • They can be closed
    • They may have a timeout attribute (so if the connection could not be opened within the
      timeout, an exception will be thrown).

    Your job is to represent these commonalities in a base class called DbConnection. This class
    should have two properties:
      ConnectionString : string
      Timeout : TimeSpan

    A DbConnection will not be in a valid state if it doesn’t have a connection string. So you need to
    pass a connection string in the constructor of this class. Also, take into account the scenarios
    where null or an empty string is sent as the connection string. Make sure to throw an exception
    to guarantee that your class will always be in a valid state.

    Our DbConnection should also have two methods for opening and closing a connection. We
    don’t know how to open or close a connection in a DbConnection and this should be left to the
    classes that derive from DbConnection. These classes (eg SqlConnection or OracleConnection)
    will provide the actual implementation. So you need to declare these methods as abstract.

    Derive two classes SqlConnection and OracleConnection from DbConnection and provide a
    simple implementation of opening and closing connections using Console.WriteLine(). In the
    real-world, SQL Server provides an API for opening or closing a connection to a database. But
    for this exercise, we don’t need to worry about it. 
    */
    public void ExerciseOne()
    {
      var sqlConnection = new SqlConnection("sqlConnectionString");
      var oracleConnection = new OracleConnection("oracleConnectionString");
      //var oracleConnection2 = new OracleConnection(null);

      sqlConnection.Open();
      oracleConnection.Open();

      sqlConnection.Close();
      oracleConnection.Close();
    }

    // Exercise 2: Design a database command
    /*
    Now that we have the concept of a DbConnection, let’s work out how to represent a
    DbCommand.

    Design a class called DbCommand for executing an instruction against the database. A
    DbCommand cannot be in a valid state without having a connection. So in the constructor of
    this class, pass a DbConnection. Don’t forget to cater for the null.

    Each DbCommand should also have the instruction to be sent to the database. In case of SQL
    Server, this instruction is expressed in T-SQL language. Use a string to represent this instruction.
    Again, a command cannot be in a valid state without this instruction. So make sure to receive it
    in the constructor and cater for the null reference or an empty string.

    Each command should be executable. So we need to create a method called Execute(). In this
    method, we need a simple implementation as follows:
      Open the connection
      Run the instruction
      Close the connection

    Note that here, inside the DbCommand, we have a reference to DbConnection. Depending on
    the type of DbConnection sent at runtime, opening and closing a connection will be different.
    For example, if we initialize this DbCommand with a SqlConnection, we will open and close a
    connection to a Sql Server database. This is polymorphism. Interestingly, DbCommand doesn’t
    care about how a connection is opened or closed. It’s not the responsibility of the DbCommand.
    All it cares about is to send an instruction to a database.

    For running the instruction, simply output it to the Console. In the real-world, SQL Server (or any
    other DBMS) provides an API for running an instruction against the database. We don’t need to
    worry about it for this exercise.

    In the main method, initialize a DbCommand with some string as the instruction and a
    SqlConnection. Execute the command and see the result on the console.

    Then, swap the SqlConnection with an OracleConnection and see polymorphism in action.
    */
    public void ExerciseTwo()
    {
      var sqlCommand = new DbCommand("sqlCommand", new SqlConnection("sqlConnectionString"));
      sqlCommand.Execute();

      var oracleCommand = new DbCommand("oracleCommand", new OracleConnection("oracleConnectionString"));
      oracleCommand.Execute();

      //var commandTextErrorCommand = new DbCommand(null, new OracleConnection("oracleConnectionString"));
      //var dbConnectionErrorCommand = new DbCommand("command", null);
    }
  }

  public abstract class DbConnection
  {
    public string ConnectionString { get; private set; }
    public TimeSpan Timeout { get; set; }

    public DbConnection(string connectionString)
    {
      if (connectionString != null)
      {
        Console.WriteLine("Creating connection with string: " + connectionString);
        ConnectionString = connectionString;
      }
      else
      {
        throw new InvalidDataException(message: "Connection String cannot be null.");
      }
    }

    public abstract void Open();

    public abstract void Close();

  }

  public class SqlConnection : DbConnection
  {
    public SqlConnection(string connectionString)
      : base(connectionString) { }

    public override void Open()
    {
      Console.WriteLine("Open SQL Connection.");
    }

    public override void Close()
    {
      Console.WriteLine("Close SQL Connection.");
    }
  }

  public class OracleConnection : DbConnection
  {
    public OracleConnection(string connectionString)
      : base (connectionString) { }

    public override void Open()
    {
      Console.WriteLine("Open Oracle Connection.");
    }

    public override void Close()
    {
      Console.WriteLine("Close Oracle Connection.");
    }
  }

  public class DbCommand
  {
    private string commandText;
    private DbConnection dbConnection;

    public DbCommand(string commandText, DbConnection dbConnection)
    {
      if (commandText != null)
      {
        this.commandText = commandText;
      }
      else
      {
        throw new InvalidDataException(message: "Command text cannot be null.");
      }

      if (dbConnection != null)
      {
        this.dbConnection = dbConnection;
      }
      else
      {
        throw new InvalidDataException(message: "Database Connection cannot be null.");
      }
    }

    public void Execute()
    {
      dbConnection.Open();
      Console.WriteLine("Executing Instruction: " + commandText);
      dbConnection.Close();
    }
  }
}
