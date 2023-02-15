using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcel.Models;
using System;

namespace Parcel.Tests
{
  [TestClass]
  public class PackageTests
  {
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
  }
}