using BeeSharp.ApiComponents.ApiModels.BroadcastOps;

namespace BeeSharp.ApiComponents.Condenser.Serialization
{
    /// <summary>
    ///     Classes that implement this interface are broadcast-able transaction operations that can be serialized for
    ///     signature creation.
    /// </summary>
    public interface ISerializableOperation : ISerializableElement
    {
        public HivedOperationId GetOperationId();

        /// <summary>
        ///     Get the operation name. Required, since some operations may use the same name for different operations.
        /// </summary>
        /// <returns>The operation name.</returns>
        public string GetOperationName();

        /// <summary>
        ///     Get the operation model. Required, since some operations require additional serialization wrappers (and
        ///     reasonable constructors) around them.
        /// </summary>
        /// <returns>The operation model as object.</returns>
        public object GetOperationModel();
    }
}