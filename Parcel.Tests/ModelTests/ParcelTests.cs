using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcel.Models;
using System;

namespace Parcel.Tests
{
  [TestClass]
  public class PackageTests
  {
    [TestMethod]
    public void PackageConstructor_CreatesInstanceOfPackage_Package()
    {
      Package newPackage = new Package(3, 4);
      Assert.AreEqual(typeof(Package), newPackage.GetType());
    }
    [TestMethod]
    public void GetLength_ReturnsLength_Int()
    {
      int length = 3;
      Package newPackage = new Package(length, 4);
      int result = newPackage.Length;
      Assert.AreEqual(length, result);
    }
    [TestMethod]
    public void GetWidth_ReturnsWidth_Int()
    {
      int width = 4;
      Package newPackage = new Package(3, width);
      int result = newPackage.Width;
      Assert.AreEqual(width, result);
    }
  }
}