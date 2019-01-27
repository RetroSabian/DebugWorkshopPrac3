using Microsoft.VisualStudio.TestTools.UnitTesting;
using debugws3;

namespace Tests
{
  [TestClass]
  public class ErrorHandling
  {
    [TestMethod]
    public void ShouldErrorOnCrap()
    {
      var result = Calc.Calculate(null);
      Assert.IsFalse(result.err.Length == 0, "should not be empty");
    }

    [DataTestMethod]
    [DataRow("")]
    [DataRow("x")]
    [DataRow("2z^2+z+c")]
    [DataRow("0*FF+1")]
    [DataRow("ABC")]
    public void DoErrors(string value)
    {
      var result = Calc.Calculate(value);
      Assert.IsFalse(result.err.Length == 0, $"{value} should yield an error");
    }
  }

  [TestClass]
  public class Basics
  {
    [DataTestMethod]
    [DataRow("3+3")]
    [DataRow("2 + 4")]
    [DataRow(" 4+2 ")]
    [DataRow("5+   1")]
    [DataRow(" 6 + 0 ")]
    public void DoPlus(string value)
    {
      var result = Calc.Calculate(value);
      Assert.IsTrue(result.result == 6, $"{value} should be 6");
    }

    [DataTestMethod]
    [DataRow(" 3-2")]
    [DataRow("2- 1")]
    [DataRow(" 4 - 3 ")]
    [DataRow("5-     4")]
    [DataRow("    6-5")]
    public void DoMinus(string value)
    {
      var result = Calc.Calculate(value);
      Assert.IsTrue(result.result == 1, $"{value} should be 1");
    }

    [DataTestMethod]
    [DataRow(" 4*9")]
    [DataRow("3* 12")]
    [DataRow(" 2 * 18 ")]
    [DataRow("1*     36")]
    [DataRow("    6*6")]
    public void DoMultiply(string value)
    {
      var result = Calc.Calculate(value);
      Assert.IsTrue(result.result == 36, $"{value} should be 36");
    }

    [DataTestMethod]
    [DataRow(" 18/9")]
    [DataRow("24/ 12")]
    [DataRow(" 30 / 15 ")]
    [DataRow("72/     36")]
    [DataRow("    36/18")]
    public void DoDivide(string value)
    {
      var result = Calc.Calculate(value);
      Assert.IsTrue(result.result == 2, $"{value} should be 2");
    }

    [DataTestMethod]
    [DataRow(" 18/9 +3 ")]
    [DataRow("1 * 7 - 2")]
    public void DoInOrder(string value)
    {
      var result = Calc.Calculate(value);
      Assert.IsTrue(result.result == 5, $"{value} should be 5");
    }

    [DataTestMethod]
    [DataRow(" 3 + 4  * 2 ")]
    [DataRow("23 -  24/2")]
    public void DoNotOrder(string value)
    {
      var result = Calc.Calculate(value);
      Assert.IsTrue(result.result == 11, $"{value} should be 11");
    }












  }

}
