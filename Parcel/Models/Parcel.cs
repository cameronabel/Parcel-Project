using MySqlConnector;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace Parcel.Models;

public class Package
{
  public int Length { get; set; }
  public int Width { get; set; }
  public int Height { get; set; }
  public int Weight { get; set; }
  public int Id { get; set; }

  public Package(int length, int width, int height, int weight)
  {
    Length = length;
    Width = width;
    Height = height;
    Weight = weight;
  }
  public Package(int id, int length, int width, int height, int weight)
  {
    Id = id;
    Length = length;
    Width = width;
    Height = height;
    Weight = weight;
  }

  public int Volume()
  {
    return Length * Width * Height;
  }

  public int CostToShip()
  {
    return Volume() * 2;
  }
  public static Package Find(int searchId)
  {
    // We open a connection.
    MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
    conn.Open();

    // We create MySqlCommand object and add a query to its CommandText property. 
    // We always need to do this to make a SQL query.
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = "SELECT * FROM parcels WHERE id = @ThisId;";

    cmd.Parameters.AddWithValue("@ThisId", searchId);

    // We use the ExecuteReader() method because our query will be returning results and 
    // we need this method to read these results. 
    // This is in contrast to the ExecuteNonQuery() method, which 
    // we use for SQL commands that don't return results like our Save() method.
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    int packageId = 0;
    int packageHeight = 0;
    int packageLength = 0;
    int packageWidth = 0;
    int packageWeight = 0;

    while (rdr.Read())
    {
      packageId = rdr.GetInt32(0);
      packageLength = rdr.GetInt32(1);
      packageWidth = rdr.GetInt32(2);
      packageHeight = rdr.GetInt32(3);
      packageWeight = rdr.GetInt32(4);
    }
    Package foundPackage = new Package(packageId, packageLength, packageWidth, packageHeight, packageWeight);

    // We close the connection.
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return foundPackage;
  }
  public static void ClearAll()
  {
    MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
    conn.Open();

    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = "DELETE FROM parcels;";
    cmd.ExecuteNonQuery();

    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
  }
  public static List<Package> GetAll()
  {
    List<Package> allPackages = new List<Package> { };

    MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
    conn.Open();

    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = "SELECT * FROM parcels;";

    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while (rdr.Read())
    {
      int packageId = rdr.GetInt32(0);
      int packageLength = rdr.GetInt32(1);
      int packageWidth = rdr.GetInt32(2);
      int packageHeight = rdr.GetInt32(3);
      int packageWeight = rdr.GetInt32(4);
      Package newPackage = new Package(packageId, packageLength, packageWidth, packageHeight, packageWeight);
      allPackages.Add(newPackage);
    }
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return allPackages;
  }

  public override bool Equals(System.Object otherPackage)
  {
    if (!(otherPackage is Package))
    {
      return false;
    }
    else
    {
      Package newPackage = (Package)otherPackage;
      // bool descriptionEquality = (this.Height == newObject.Height );
      // return descriptionEquality;
      foreach (PropertyInfo prop in newPackage.GetType().GetProperties())
      {

        if ((int)prop.GetValue(this) != (int)prop.GetValue(newPackage))
        {
          return false;
        }
      }
      return true;
    }
  }

  public override int GetHashCode()
  {
    return Id.GetHashCode();
  }

  public void Save()
  {
    MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
    conn.Open();

    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;

    // Begin new code

    cmd.CommandText = "INSERT INTO parcels (length, width, height, weight) VALUES (@PackageLength, @PackageWidth, @PackageHeight, @PackageWeight);";

    cmd.Parameters.AddWithValue("@PackageLength", this.Length);
    cmd.Parameters.AddWithValue("@PackageWidth", this.Width);
    cmd.Parameters.AddWithValue("@PackageHeight", this.Height);
    cmd.Parameters.AddWithValue("@PackageWeight", this.Weight);

    // MySqlParameter param = new MySqlParameter();
    // param.ParameterName = "@ItemDescription";
    // param.Value = this.Description;
    // cmd.Parameters.Add(param); 


    cmd.ExecuteNonQuery();
    Id = (int)cmd.LastInsertedId;

    // End new code

    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
  }
}



