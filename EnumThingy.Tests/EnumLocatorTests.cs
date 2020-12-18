using EnumThingy.Exceptions;
using ExternalDllWithEnums.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumThingy.Tests
{
	[TestClass]
	public class EnumLocatorTests
	{
		private readonly EnumLocator _enumLocator = new EnumLocator();


		[TestMethod]
		[ExpectedException(typeof(EnumNotFoundException))]
		public void NonExistantEnumNameThrowsException()
		{
			_enumLocator.GetEnumValue("AlmostOrangeCatEnum", "Small");
		}

		[TestMethod]
		public void EnumNameAndValueNameReturnsCorrectValue()
		{
			int result = _enumLocator.GetEnumValue("OrangeCatEnum", "Small");
			Assert.AreEqual((int)OrangeCatEnum.Small, result);
		}

		[TestMethod]
		public void EnumNameAndDifferentCaseValueNameReturnsCorrectValue()
		{
			int result = _enumLocator.GetEnumValue("OrangeCatEnum", "sMAll");
			Assert.AreEqual((int)OrangeCatEnum.Small, result);
		}

		[TestMethod]
		public void DifferentEnumNameWithSameValueNameReturnsCorrectValue()
		{
			int result = _enumLocator.GetEnumValue("BoringCatEnum", "Small");
			Assert.AreEqual((int)BoringCatEnum.Small, result);
		}
	}
}
