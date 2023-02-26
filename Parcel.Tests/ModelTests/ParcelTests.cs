using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcel.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Parcel.Tests
{
  [TestClass]
  public class PackageTests : IDisposable
  {
    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      Package.ClearAll();
    }

    public PackageTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    Package testPackage;
    [TestInitialize]
    public void TestInitialize()
    {
      testPackage = new Package(3, 4, 5, 10);
    }

    [TestMethod]
    public void PackageConstructor_CreatesInstanceOfPackage_Package()
    {
      Assert.AreEqual(typeof(Package), testPackage.GetType());
    }
    [TestMethod]
    public void GetLength_ReturnsLength_Int()
    {
      int result = testPackage.Length;
      Assert.AreEqual(3, result);
    }
    [TestMethod]
    public void GetWidth_ReturnsWidth_Int()
    {
      int result = testPackage.Width;
      Assert.AreEqual(4, result);
    }
    [TestMethod]
    public void GetHeight_ReturnsHeight_Int()
    {
      int result = testPackage.Height;
      Assert.AreEqual(5, result);
    }
    [TestMethod]
    public void GetWeight_ReturnsWeight_Int()
    {
      int result = testPackage.Weight;
      Assert.AreEqual(10, result);
    }
    [TestMethod]
    public void GetVolume_ReturnsVolume_Int()
    {
      int volume = 60;
      int result = testPackage.Volume();
      Assert.AreEqual(volume, result);
    }
    [TestMethod]
    public void GetCostToShip_ReturnsCost_Cost()
    {
      int cost = 120;
      int result = testPackage.CostToShip();
      Assert.AreEqual(cost, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_PackageList()
    {
      List<Package> newList = new List<Package> { };
      List<Package> result = Package.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      Package firstPackage = testPackage;
      Package secondPackage = new Package(3, 4, 5, 10);
      Assert.AreEqual(firstPackage, secondPackage);
    }

    [TestMethod]
    public void Save_SavesToDatabase_PackageList()
    {

      testPackage.Save();
      List<Package> result = Package.GetAll();
      List<Package> testList = new List<Package> { testPackage };
      CollectionAssert.AreEqual(testList, result);

    }
  }
}