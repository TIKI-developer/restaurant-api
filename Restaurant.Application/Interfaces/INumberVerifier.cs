namespace Restaurant.Application.Interfaces
{
    public interface INumberVerifier
    {
        string Verify(string[] data, string hash);
    }
}
