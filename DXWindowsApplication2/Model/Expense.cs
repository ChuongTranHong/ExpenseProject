using System;
using System.ComponentModel;

namespace DXWindowsApplication2.Model 
{

    public class Expense : INotifyPropertyChanged 
    {
        private  DateTime _time;
        private  string _field;
        private  string _description;
        private  double _value;
        private  bool _isExpense;

        
        public Expense(string field,string description, double value, Boolean isExpense ,DateTime time)
        {
            _time = time;
            _field = field;
            _description = description;
            _value = value;
            _isExpense = isExpense;
            
        }

        public Expense()
        {
            _time = DateTime.Today;
            _field = "";
            _description = "";
            _value = 0;
            _isExpense = true;
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if(_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                };
            }
        }

        public DateTime Time
        {
            get { return _time; }
            set
            {
                if(_time != value)
                {
                    _time = value;
                    OnPropertyChanged("Time");
                };
            }
        }

        public bool IsExpense
        {
            get { return _isExpense; }
            set
            {
                if(_isExpense != value)
                {
                    _isExpense = value;
                    OnPropertyChanged("IsExpense");
                };
            }
        }

        public double Value
        {
            get { return _value; }
            set
            {
                if(_value != value)
                {
                    _value = value;
                    OnPropertyChanged("Value");
                };
            }
        }

        public string Field
        {
            get { return _field; }
            set 
            {
                if (_field != value)
                {
                    _field = value;
                    OnPropertyChanged("Field"); 
                }
                   
            }
        }
        
        public override string ToString()
        {
            return String.Format("field:{0}, description:{1}, value:{2}, expense:{3}, time:{4}",
                                 _field, _description, _value, _isExpense, _time);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}