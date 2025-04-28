using NUnit.Framework;

public class SingleInstanceCheckerTests
{
	[Test]
	public void SingleInstance_ShouldBeTrue_ForFirstInstance()
	{
		using var checker = new SingleInstanceChecker("TestAppMutex_First");
		Assert.IsTrue(checker.IsSingleInstance);
	}

	[Test]
	public void SingleInstance_ShouldBeFalse_ForSecondInstance()
	{
		using var checker1 = new SingleInstanceChecker("TestAppMutex_Second");
		using var checker2 = new SingleInstanceChecker("TestAppMutex_Second");
		Assert.IsTrue(checker1.IsSingleInstance);
		Assert.IsFalse(checker2.IsSingleInstance);
	}

	[Test]
	public void ShouldThrowException_WhenMutexNameIsEmpty()
	{
		var ex = Assert.Throws<ArgumentException>(() => new SingleInstanceChecker(""));
		Assert.That(ex.Message, Does.StartWith("Mutex name must not be empty."));
	}
}
