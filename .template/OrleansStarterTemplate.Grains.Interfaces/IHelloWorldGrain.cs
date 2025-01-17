namespace OrleansStarterTemplate.Grains.Interfaces;

public interface IHelloWorldGrain : IGrainWithStringKey
{
    public const string Key = "HelloWorld";

    Task<HelloMessage> Hello(string name);
}