namespace DNet.Builders
{
    public interface IBuilder<BuiltObjectType>
    {
        BuiltObjectType Build();
    }
}
