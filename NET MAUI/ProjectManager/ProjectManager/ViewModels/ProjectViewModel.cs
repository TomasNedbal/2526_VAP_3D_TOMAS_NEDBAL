using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
        
        public string Title
    {
        get => _project.Title;
        set
        {
            _project.Title = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("title"));
        }
    }
    {
        private Project _project;
        
        public event PropertyChangedEventHandler? PropertyChanged;

        public ProjectViewModel(Project project)
        {
            _project = Project;
        }
    }
}
