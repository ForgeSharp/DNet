namespace DNet.Core
{
    public struct SimpleEmoji
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public override string ToString()
        {
            return $"{this.Name}:{this.Id}";
        }
    }
}
