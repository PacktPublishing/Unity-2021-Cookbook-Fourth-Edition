using NUnit.Framework;

class TestHealth
{
	[Test]
	public void TestReturnsOneWhenCreated()
	{
		// Arrange
		Health h = new Health ();
		float expectedResult = 1;

		// Act
		float result = h.GetHealth ();

		// Assert
        Assert.AreEqual (expectedResult, result);
	}		

    [Test]
    public void TestPointTwoAfterAddPointOneTwiceAfterKill()
    {
        // Arrange
        Health h = new Health();
        float healthToAdd = 0.1f;
        float expectedResult = 0.2f;

        // Act
        h.KillCharacter();
        h.AddHealth(healthToAdd);
        h.AddHealth(healthToAdd);
        float result = h.GetHealth();


        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void TestNoChangeAndReturnsFalseWhenAddNegativeValue()
    {
        // Arrange
        Health h = new Health();
        float healthToAdd = -1;
        bool expectedResultBool = false;
        float expectedResultFloat = 1;

        // Act
        bool resultBool = h.AddHealth(healthToAdd);
        float resultFloat = h.GetHealth();

        // Assert
        Assert.AreEqual(expectedResultBool, resultBool);
        Assert.AreEqual(expectedResultFloat, resultFloat);
    }

    [Test]
    public void TestReturnsZeroWhenKilled()
    {
        // Arrange
        Health h = new Health();
        float expectedResult = 0;

        // Act
        h.KillCharacter();
        float result = h.GetHealth();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }


    [Test]
    public void TestHealthNotGoAboveOne()
    {
        // Arrange
        Health h = new Health();
        float expectedResult = 1;

        // Act
        h.AddHealth(0.1f);
        h.AddHealth(0.5f);
        h.AddHealth(1);
        h.AddHealth(5);
        float result = h.GetHealth();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }


}