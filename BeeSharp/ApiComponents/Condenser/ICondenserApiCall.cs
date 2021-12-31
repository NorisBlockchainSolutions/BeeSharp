namespace BeeSharp.ApiComponents.Condenser
{
    public interface ICondenserApiCall<out T, out TU> where TU : class
    {
        string MethodName { get; }
        TU? ExpectedResponseJson { get; }
        T[] QueryParametersJson { get; }
    }
}