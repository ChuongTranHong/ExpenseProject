using System;

namespace DXWindowsApplication2.Model 
{   
    
    public class Expense
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

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public bool IsExpense
        {
            get { return _isExpense; }
            set { _isExpense = value; }
        }

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string Field
        {
            get { return _field; }
            set { _field = value; }
        }
        
        public override string ToString()
        {
            return String.Format("field:{0}, description:{1}, value:{2}, expense:{3}, time:{4}",
                                 _field, _description, _value, _isExpense, _time);
        }
    }
}