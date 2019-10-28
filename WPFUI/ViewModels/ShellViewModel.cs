using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.EventModels;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<Screen>, IHandle<LoadEvent>, IHandle<LoadGameEvent>
    {
        IEventAggregator _events;

        public ShellViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);

            _events.PublishOnUIThread(new LoadEvent());
        }

        public void Handle(LoadEvent message)
        {
            ActivateItem(new LoadViewModel(_events));
        }

        public void Handle(LoadGameEvent message)
        {
            ActivateItem(new GameViewModel());
        }
    }
}