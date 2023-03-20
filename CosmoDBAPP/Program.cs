// See https://aka.ms/new-console-template for more information

using Microsoft.Azure.Cosmos;

CreateItem().Wait();

async Task CreateItem()
{
    var cosmosUrl = "https://cosmodblesson.documents.azure.com:443/";
    var cosmoskey = "ti8LTVoQFYpO79xiJV9PB9tQM1OM85UlmgeArYod5OykSZ1kO7EcVfxFkxtItr6MfNfkB6zsupvTACDboyllVg==";
    var databaseName = "DemoDB";

    CosmosClient client = new CosmosClient(cosmosUrl, cosmoskey);
    Database database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
    Container container = await database.CreateContainerIfNotExistsAsync("MyContainerName", "/partitionKeyPath");
    dynamic testItem = new
    {
        id = Guid.NewGuid().ToString(), partitionKeyPath = "MyTestPkValue", details = "it's working"
    };
    var response = await container.CreateItemAsync(testItem);

}