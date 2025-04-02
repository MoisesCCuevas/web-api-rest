public class HwService : IHwService {
    public string SayHello() {
        return "Hello World!";
    }
}

public interface IHwService {
    string SayHello();
}