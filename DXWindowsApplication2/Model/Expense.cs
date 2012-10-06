using System;

namespace DXWindowsApplication2.Model 
{   
    
    public class Expense
    {
        private readonly DateTime _time;
        private readonly string _field;
        private readonly string _description;
        private readonly double _value;
        private readonly bool _isExpense;

        
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
        }

        public DateTime Time
        {
            get { return _time; }
        }

        public bool IsExpense
        {
            get { return _isExpense; }
        }

        public double Value
        {
            get { return _value; }
        }

        public string Field
        {
            get { return _field; }
        }
        
        public override string ToString()
        {
            return String.Format("field:{0}, description:{1}, value:{2}, expense:{3}, time:{4}",
                                 _field, _description, _value, _isExpense, _time);
        }
    }
}