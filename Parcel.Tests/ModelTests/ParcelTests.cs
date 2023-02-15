using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcel.Models;
using System;

namespace Parcel.Tests
{
  [TestClass]
  public class ParcelTests
  {
    [TestMethod]
    public void ParcelConstructor_CreatesInstanceOfParcel_Parcel()
    {
      Parcel newParcel = new Parcel();
      Assert.AreEqual(typeof(Parcel), newParcel.GetType());
    }
  }
}