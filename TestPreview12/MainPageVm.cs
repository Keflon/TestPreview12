using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TestPreview12
{
    public class MainPageVm : BaseVm
    {
        public MainPageVm()
        {
            ThingCollection = new ObservableCollection<ThingVm>();

            ThingCollection.Add(new ThingVm("Zero"));
            ThingCollection.Add(new ThingVm("One"));
            ThingCollection.Add(new ThingVm("Two"));

            Device.StartTimer(TimeSpan.FromMilliseconds(40), MainPageTimerCallback);
        }

        public ObservableCollection<ThingVm> ThingCollection { get; }

        private double _offset;
        public double Offset
        {
            get => _offset;
            set => SetProperty(ref _offset, value);
        }

        private int _count;
        public int Count 
        {
            get => _count;
            set=>SetProperty(ref _count, value);
        }

        private bool MainPageTimerCallback()
        {
            Count++;

            Offset = Math.Sin(Count / 30.0) * 40 + 50;

            ThingCollection[0].Offset = Math.Sin(Count / 30.0) * 40 + 50;
            ThingCollection[1].Offset = Math.Sin(Count / 20.0) * 40 + 50;
            ThingCollection[2].Offset = Math.Sin(Count / 10.0) * 40 + 50;

            return true;
        }
    }
}