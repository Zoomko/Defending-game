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
    public void PersistentDataServiceTestSimplePasses()
    {
        _persistentDataService.Load();
    }
}
