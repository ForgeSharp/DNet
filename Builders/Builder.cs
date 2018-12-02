namespace DNet.Builders
{
    // TODO: Builders should be able to be casted to generic type provided
    public interface IBuilder<BuiltObjectType>
    {
        BuiltObjectType Build();
    }
}
