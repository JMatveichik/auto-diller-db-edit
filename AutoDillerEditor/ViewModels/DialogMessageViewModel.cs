using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.ViewModels
{
    public class DialogMessageViewModel : ReactiveObject
    {
        [Reactive]
        public string MessageTitle { get; set; }

        [Reactive]
        public string MessageBody { get; set; } = string.Empty;

		public DialogMessageViewModel(string title, string body)
        {
            MessageTitle = title;
            MessageBody = body;
        }
	}
}
