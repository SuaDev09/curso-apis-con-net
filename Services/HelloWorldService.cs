public class HelloWorldService : IHelloWorldService
//Para implementar una interfaz a una clase se utiliza IHelloWorldService
{
    public string GetHelloWorld()
    {
        return "Hello World";
    }
}

public interface IHelloWorldService
{
    string GetHelloWorld();
}