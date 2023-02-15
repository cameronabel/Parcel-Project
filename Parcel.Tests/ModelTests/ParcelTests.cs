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
      Package newPackage = new Package(5);
      Assert.AreEqual(typeof(Package), newPackage.GetType());
    }
    [TestMethod]
    public void GetLength_ReturnsLength_Int()
    {
      int length = 3;
      Package newPackage = new Package(length);
      int result = newPackage.Length;
      Assert.AreEqual(length, result);
    }
  }
}