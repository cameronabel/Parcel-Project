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
      Package newPackage = new Package();
      Assert.AreEqual(typeof(Package), newPackage.GetType());
    }
  }
}