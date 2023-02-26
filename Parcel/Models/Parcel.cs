using MySqlConnector;
using System.Collections.Generic;

namespace Parcel.Models;

public class Package
{
  public int Length { get; set; }
  public int Width { get; set; }
  public int Height { get; set; }
  public int Weight { get; set; }
  public int ID { get; set; }

  public Package(int length, int width, int height, int weight)
  {
    Length = length;
    Width = width;
    Height = height;
    Weight = weight;
  }
  public Package(int id, int length, int width, int height, int weight)
  {
    ID = id;
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
    // Temporarily returning placeholder Package to get beyond compiler errors until we refactor to work with database.
    Package placeholderPackage = new Package(3, 4, 5, 10);
    return placeholderPackage;
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
}
