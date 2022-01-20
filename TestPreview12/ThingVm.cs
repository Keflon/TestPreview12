namespace TestPreview12
{
    public class ThingVm : BaseVm
    {
        public ThingVm(string name)
        {
            Name = name;
        }
        public string Name { get; }

        private double _offset;
        public double Offset
        {
            get => _offset;
            set => SetProperty(ref _offset, value);
        }
    }
}