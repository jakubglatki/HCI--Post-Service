using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI__Post_Service
{
    public class MailFolder
    {
        public String name { get; set; }
        public ObservableCollection<Mail> mailList { get; set; }

        public MailFolder() { }
        public MailFolder(string name)
        {
            this.name = name;
        }

        public MailFolder(string name, ObservableCollection<Mail> mails)
        {
            this.name = name;
            this.mailList = mails;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        private void FolderlSetCurrentFolder(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Manager manager = new Manager();
            manager.SetCurrentFolder(this);
        }
    }
}
