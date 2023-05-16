using Assets.CodeBase.Services;
using NUnit.Framework;
using System.IO;

public class PersistentDataServiceTest
{
    private readonly string testDataPath = "TestData";
    private PersistentDataService _persistentDataService;

    [OneTimeSetUp]
    public void Start()
    {
        DeleteFileIfExist();
        _persistentDataService = new PersistentDataService(new JsonDataService(), testDataPath);
    }

    [OneTimeTearDown]
    public void Stop()
    {
        DeleteFileIfExist();
    }

    private void DeleteFileIfExist()
    {        
        if (File.Exists(testDataPath))
            File.Delete(testDataPath);   
    }

    [Test]
    public void PersistentFileDoesnotExist()
    {
        _persistentDataService.Load();
        if (_persistentDataService.PersistentGameData == null)
            Assert.True(true);
        else
            Assert.Fail();
    }
}
